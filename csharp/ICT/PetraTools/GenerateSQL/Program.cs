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
using Ict.Common;
using Ict.Tools.DBXML;

namespace GenerateSQL
{
class Program
{
    public static void Main(string[] args)
    {
        TCmdOpts cmdLine = new TCmdOpts();
        string operation, xmlfile, outputfile;

        try
        {
            operation = cmdLine.GetOptValue("do");
            xmlfile = cmdLine.GetOptValue("petraxml");
            outputfile = cmdLine.GetOptValue("outputFile");
            TWriteSQL.eDatabaseType dbms = TWriteSQL.StringToDBMS(cmdLine.GetOptValue("dbms"));

            if (operation == "sql")
            {
                TDataDefinitionParser parser = new TDataDefinitionParser(xmlfile);
                TDataDefinitionStore store = new TDataDefinitionStore();
                System.Console.WriteLine("Reading xml file {0}...", xmlfile);

                if (parser.ParseDocument(ref store))
                {
                    if (dbms == TWriteSQL.eDatabaseType.Sqlite)
                    {
                        // we want to write directly to the database
                        TSQLiteWriter.CreateDatabase(store, outputfile, cmdLine.GetOptValue("password"));
                    }
                    else
                    {
                        // create an sql script that will be loaded into the database later
                        TWriteSQL.WriteSQL(store, dbms, outputfile);
                    }
                }
            }

            if (operation == "load")
            {
                TDataDefinitionParser parser = new TDataDefinitionParser(xmlfile);
                TDataDefinitionStore store = new TDataDefinitionStore();
                System.Console.WriteLine("Reading xml file {0}...", xmlfile);

                if (parser.ParseDocument(ref store))
                {
                    if (dbms == TWriteSQL.eDatabaseType.Sqlite)
                    {
                        // we want to write directly to the database
                        TSQLiteWriter.ExecuteLoadScript(store, outputfile,
                            cmdLine.GetOptValue("datapath"),
                            cmdLine.GetOptValue("sqlfile"),
                            cmdLine.GetOptValue("password"));
                    }
                }
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Error: " + e.Message);
            System.Console.WriteLine(e.StackTrace);
            System.Console.WriteLine();
            System.Console.WriteLine("generate the SQL files to create the database in SQL");
            System.Console.WriteLine(
                "usage: GenerateSQL -do:<operation> -dbms:<type of database system> -petraxml:<path and filename of petra.xml> -outputFile:<path and filename of the output file>");
            System.Console.WriteLine("operations available:");
            System.Console.WriteLine("  sql ");
            System.Console.WriteLine("    sample call: ");
            System.Console.WriteLine(
                "        GenerateSQL -do:sql -dbms:postgresql -petraxml:u:/sql/datadefinition/petra.xml -outputFile:U:/setup/petra0300/petra.sql");
            System.Console.WriteLine("Available database managment systems and their code:");
            System.Console.WriteLine("  postgresql (Recommended)");
            System.Console.WriteLine("  mysql (experimental)");
            System.Console.WriteLine("  sqlite (for the light version)");
            System.Environment.Exit(-1);
        }
    }
}
}