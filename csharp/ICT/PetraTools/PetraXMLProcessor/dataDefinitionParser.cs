/*************************************************************************
 *
 * DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 *
 * @Authors:
 *       timop
 *
 * Copyright 2004-2009 by OM International
 *
 * This file is part of OpenPetra.org.
 *
 * OpenPetra.org is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * OpenPetra.org is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
 *
 ************************************************************************/
using System;
using Ict.Common.IO;
using System.Xml;
using System.IO;
using System.Data;
using Ict.Common;

namespace Ict.Tools.DBXML
{
    /// <summary>
    /// This is a special XML parser for the datadefinition file for Petra
    /// </summary>
    public class TDataDefinitionParser : TXMLGroupParser
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="filename">the xml file that should be parsed</param>
        /// <param name="withValidation">if true then the xml file will be validated</param>
        public TDataDefinitionParser(string filename, bool withValidation) : base(filename, withValidation)
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="filename">the xml file that should be parsed</param>
        public TDataDefinitionParser(string filename) : base(filename)
        {
        }

        private TDataDefinitionStore myStore;
        private bool FDoValidation;

        /// <summary>
        /// Knows how to parse all the entities in the document.
        /// It reads a group of entities.
        /// </summary>
        /// <param name="cur2">The current node in the document that should be parsed</param>
        /// <param name="groupId">The id of the previous group object of this type</param>
        /// <param name="entity">The name of the elements that make up the group</param>
        /// <param name="newcur">After parsing, the then current node is returned in this parameter</param>
        /// <returns>The group of elements, or null</returns>
        public override TXMLGroup ParseGroup(XmlNode cur2, ref int groupId, string entity, ref XmlNode newcur)
        {
            return null;
        }

        /// <summary>
        /// Knows how to parse all the entities in the document.
        /// Reads one or more entities of the same type.
        /// </summary>
        /// <param name="cur">The current node</param>
        /// <param name="groupId">The id of the current group that the elements will belong to</param>
        /// <param name="entity">The name of the entity that should be read</param>
        /// <returns>the last of the read entities</returns>
        public override TXMLElement Parse(XmlNode cur, ref int groupId, string entity)
        {
            TXMLElement ReturnValue;

            cur = NextNotBlank(cur);
            ReturnValue = null;

            if ((cur == null) || (cur.Name.ToLower() != entity.ToLower()))
            {
                return ReturnValue;
            }

            groupId++;

            if ((cur != null) && (cur.Name.ToLower() == entity.ToLower()))
            {
                if (entity == "table")
                {
                    ReturnValue = ParseTable(cur);
                }
                else
                {
                    if (entity == "tablefield")
                    {
                        ReturnValue = ParseTableField(cur);
                    }
                    else if (entity == "primarykey")
                    {
                        ReturnValue = ParseConstraint(cur, TXMLParser.GetAttribute(cur.ParentNode, "name"));
                    }
                    else if (entity == "foreignkey")
                    {
                        ReturnValue = ParseConstraint(cur, TXMLParser.GetAttribute(cur.ParentNode, "name"));
                    }
                    else if (entity == "uniquekey")
                    {
                        ReturnValue = ParseConstraint(cur, TXMLParser.GetAttribute(cur.ParentNode, "name"));
                    }
                    else if (entity == "index")
                    {
                        ReturnValue = ParseIndex(cur);
                    }
                    else if (entity == "indexfield")
                    {
                        ReturnValue = ParseIndexField(cur);
                    }
                    else if (entity == "sequence")
                    {
                        ReturnValue = ParseSequence(cur);
                    }
                }
            }

            return ReturnValue;
        }

        /// <summary>
        /// This will parse the xml document and store the contents in our Datadefinition Store
        /// </summary>
        /// <param name="myStore">the destination of all the information</param>
        /// <param name="ADoValidation">do we want the XmlDocument to be validated</param>
        /// <param name="AAddAutoGeneratedFields">should some special fields be generated automatically, eg. createdby/datemodified etc</param>
        /// <returns></returns>
        public Boolean ParseDocument(ref TDataDefinitionStore myStore, Boolean ADoValidation, Boolean AAddAutoGeneratedFields)
        {
            Boolean ReturnValue;
            XmlNode startNode;
            XmlNode cur;
            TTable table;

            this.myStore = myStore;
            ReturnValue = false;
            FDoValidation = ADoValidation;
            startNode = myDoc.DocumentElement;

            if (startNode.Name.ToLower() == "database")
            {
                cur = NextNotBlank(startNode.FirstChild);

                if ((cur == null) || (cur.Name != "table"))
                {
                    return ReturnValue;
                }

                while (cur != null)
                {
                    if (cur.Name == "table")
                    {
                        table = ParseTable(cur);
                        myStore.AddTable(table);
                        cur = NextNotBlank(cur.NextSibling);
                    }

                    if (cur.Name == "sequence")
                    {
                        myStore.AddSequence(ParseSequence(cur));
                        cur = NextNotBlank(cur.NextSibling);
                    }
                }
            }

            if (AAddAutoGeneratedFields == true)
            {
                myStore.PrepareAutoGeneratedFields();
            }

            myStore.PrepareLinks();
            return true;
        }

        /// <summary>
        /// overloaded method of ParseDocument, always with adding special fields (createdby etc)
        /// </summary>
        /// <param name="myStore">the destination for all the parsed information</param>
        /// <param name="ADoValidation">should the document be validated</param>
        /// <returns></returns>
        public Boolean ParseDocument(ref TDataDefinitionStore myStore, Boolean ADoValidation)
        {
            return ParseDocument(ref myStore, ADoValidation, true);
        }

        /// <summary>
        /// overloaded version of ParseDocument, always add special fields, and validate the document
        /// </summary>
        /// <param name="myStore">the destination for all the parsed information</param>
        /// <returns></returns>
        public Boolean ParseDocument(ref TDataDefinitionStore myStore)
        {
            return ParseDocument(ref myStore, true, true);
        }

        /// <summary>
        /// Parse the definition of one database table
        /// </summary>
        /// <param name="cur2">the current node</param>
        /// <returns></returns>
        protected TTable ParseTable(XmlNode cur2)
        {
            XmlNode cur;
            TTableField tableField;
            TConstraint myConstraint;
            TIndex myIndex;
            TTable table;
            int groupId;

            cur = cur2;
            table = new TTable();
            table.strName = GetAttribute(cur, "name");
            table.strDumpName = GetAttribute(cur, "dumpname");
            table.strDescription = GetAttribute(cur, "descr");
            table.strArea = GetAttribute(cur, "area");
            table.ExistsStrLabel = HasAttribute(cur, "label");
            table.strLabel = GetAttribute(cur, "label");

            if (!table.ExistsStrLabel)
            {
                table.strLabel = table.strName;
            }

            if ((table.strDumpName.Length == 0) && FDoValidation)
            {
                throw new Exception("Table " + table.strName + " has no dumpname!");
            }

            // created / modified fields
            table.bWithoutCRMDFields = GetAttribute(cur, "withoutcrmd") == "yes";
            table.bCatchUpdateException = GetAttribute(cur, "catchupdateexception") == "yes";
            table.strGroup = GetAttribute(cur, "group");

            if (table.strGroup.Length == 0)
            {
                Console.WriteLine("Missing group name for table " + table.strName);
                Environment.Exit(1);
            }

            cur = cur.FirstChild;

            while (cur != null)
            {
                groupId = -1;
                tableField = (TTableField)Parse(cur, ref groupId, "tablefield");

                if (tableField != null)
                {
                    tableField.strTableName = table.strName;
                    tableField.iOrder = table.grpTableField.List.Count + 1;
                    table.grpTableField.List.Add(tableField);
                }

                myConstraint = (TConstraint)Parse(cur, ref groupId, "foreignkey");

                if (myConstraint == null)
                {
                    myConstraint = (TConstraint)Parse(cur, ref groupId, "primarykey");
                }

                if (myConstraint == null)
                {
                    myConstraint = (TConstraint)Parse(cur, ref groupId, "uniquekey");
                }

                if (myConstraint != null)
                {
                    table.grpConstraint.List.Add(myConstraint);
                }

                myIndex = (TIndex)Parse(cur, ref groupId, "index");

                if (myIndex != null)
                {
                    table.AddIndex(myIndex);
                }

                cur = GetNextEntity(cur);
            }

            return table;
        }

        /// <summary>
        /// parse the definition of one table column
        /// </summary>
        /// <param name="cur2">the current node</param>
        /// <returns></returns>
        protected TTableField ParseTableField(XmlNode cur2)
        {
            TTableField element;

            element = new TTableField();
            element.strName = GetAttribute(cur2, "name");

            if (element.strName.Length > 32)
            {
                throw new Exception("Fieldname is too long (max 32 characters): " + element.strName);
            }

            element.strType = GetAttribute(cur2, "type").ToLower();
            element.strTypeDotNet = GetAttribute(cur2, "typedotnet");
            element.strNameDotNet = GetAttribute(cur2, "namedotnet");
            element.ExistsStrHelp = HasAttribute(cur2, "help");
            element.strHelp = GetAttribute(cur2, "help");
            element.ExistsStrLabel = HasAttribute(cur2, "label");
            element.strLabel = GetAttribute(cur2, "label");

            if (!element.ExistsStrLabel)
            {
                element.strLabel = element.strName;
            }

            element.strFormat = GetAttribute(cur2, "format");
            element.iCharLength = GetIntAttribute(cur2, "charlength");
            element.iLength = GetIntAttribute(cur2, "length");
            element.iDecimals = GetIntAttribute(cur2, "decimals");
            element.bNotNull = (GetAttribute(cur2, "notnull") == "yes");
            element.bAutoIncrement = (GetAttribute(cur2, "autoincrement") == "yes");

            if (GetAttribute(cur2, "mandatory") == "yes")
            {
                element.bNotNull = true;
            }
            else
            {
                element.bNotNull = (GetAttribute(cur2, "notnull") == "yes");
            }

            element.ExistsStrInitialValue = HasAttribute(cur2, "initial");
            element.strInitialValue = GetAttribute(cur2, "initial");

            if (element.ExistsStrInitialValue == true)
            {
                if (element.strType == "bit")
                {
                    if (element.strFormat.ToLower().IndexOf(element.strInitialValue.ToLower()) > 0)
                    {
                        element.strDefault = "0";
                    }
                    else
                    {
                        element.strDefault = "1";
                    }
                }
                else if (element.strInitialValue.ToLower() == "today")
                {
                    element.strDefault = "SYSDATE";
                }
                else if (element.strInitialValue.ToLower() == "?")
                {
                    element.strDefault = "NULL";
                }
                else
                {
                    element.strDefault = element.strInitialValue;
                }
            }

            element.strSequence = GetAttribute(cur2, "sequence");
            element.strDescription = GetAttribute(cur2, "descr");
            element.ExistsStrColLabel = HasAttribute(cur2, "columnlabel");
            element.strColLabel = GetAttribute(cur2, "columnlabel");
            element.ExistsStrCheck = HasAttribute(cur2, "check");
            element.strCheck = GetAttribute(cur2, "check");
            element.strValExp = GetAttribute(cur2, "valueexpression");
            element.strValMsg = GetAttribute(cur2, "valuemessage");
            element.strTableName = "";

            if (element.strType == "varchar")
            {
                element.iLength = 0;

                if ((element.strFormat.Length > 0) && (element.strFormat.IndexOf("(") == -1))
                {
                    // number of x, e.g. xxxxx or xx99999
                    element.iLength = element.strFormat.Length;
                }
                else if (element.strFormat.Length > 1)
                {
                    element.iLength = Convert.ToInt32(element.strFormat.Substring(2, element.strFormat.Length - 3));
                }

                if (element.iCharLength > 0)
                {
                    element.iLength = element.iCharLength;
                }

                if (element.iCharLength <= 0)
                {
                    element.iCharLength = element.iLength;
                }

                element.iLength = element.iLength * 2;
            }

            return element;
        }

        /// <summary>
        /// parse the definition of one constraint (unique, primary or foreign key)
        /// </summary>
        /// <param name="cur2">the current node</param>
        /// <param name="AThisTableName">the name of the table that this constraint belongs to</param>
        /// <returns>the constraint</returns>
        protected TConstraint ParseConstraint(XmlNode cur2, String AThisTableName)
        {
            TConstraint element;

            element = new TConstraint();
            element.strName = GetAttribute(cur2, "name");

            // foreignkey, uniquekey, primarykey
            element.strType = cur2.Name;
            element.strThisTable = AThisTableName;
            element.strThisFields = StringHelper.StrSplit(GetAttribute(cur2, "thisFields"), ",");
            element.strOtherTable = GetAttribute(cur2, "otherTable");
            element.strOtherFields = StringHelper.StrSplit(GetAttribute(cur2, "otherFields"), ",");
            return element;
        }

        /// <summary>
        /// Parse the definition of one index in the database
        /// </summary>
        /// <param name="cur2">the current node</param>
        /// <returns></returns>
        protected TIndex ParseIndex(XmlNode cur2)
        {
            TIndex element;
            XmlNode cur;
            TIndexField myIndexField;
            int groupId;

            element = new TIndex();
            element.strName = GetAttribute(cur2, "name");
            element.strDescr = GetAttribute(cur2, "descr");
            element.strArea = GetAttribute(cur2, "area");
            element.bPrimary = (GetAttribute(cur2, "primary") == "yes");
            element.bUnique = (GetAttribute(cur2, "unique") == "yes");
            element.bImplicit = (GetAttribute(cur2, "implicit") == "yes");
            cur = cur2.FirstChild;

            while (cur != null)
            {
                groupId = -1;
                myIndexField = (TIndexField)Parse(cur, ref groupId, "indexfield");

                if (myIndexField != null)
                {
                    element.grpIndexField.List.Add(myIndexField);
                }

                cur = GetNextEntity(cur);
            }

            return element;
        }

        /// <summary>
        /// parse the field that is part of an index definition
        /// </summary>
        /// <param name="cur2">the current node</param>
        /// <returns></returns>
        protected TIndexField ParseIndexField(XmlNode cur2)
        {
            TIndexField element;

            element = new TIndexField();
            element.strName = GetAttribute(cur2, "name");
            element.strOrder = GetAttribute(cur2, "order");
            return element;
        }

        /// <summary>
        /// parse the definition of a database sequence
        /// </summary>
        /// <param name="cur2">the current node</param>
        /// <returns></returns>
        protected TSequence ParseSequence(XmlNode cur2)
        {
            TSequence element;

            element = new TSequence();
            element.strName = GetAttribute(cur2, "name");
            element.strDescription = GetAttribute(cur2, "descr");
            element.strArea = GetAttribute(cur2, "area");
            element.bCycleOnLimit = GetAttribute(cur2, "cycleonlimit") == "yes";
            element.iInitial = GetIntAttribute(cur2, "initial");
            element.iMinVal = GetIntAttribute(cur2, "minval");
            element.iMaxVal = GetIntAttribute(cur2, "maxval");
            element.iIncrement = GetIntAttribute(cur2, "increment");
            return element;
        }
    }
}