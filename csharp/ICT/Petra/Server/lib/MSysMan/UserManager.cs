//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       christiank, timop
//
// Copyright 2004-2016 by OM International
//
// This file is part of OpenPetra.org.
//
// OpenPetra.org is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra.org is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Security.Principal;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

using Ict.Common;
using Ict.Common.DB;
using Ict.Common.Exceptions;
using Ict.Common.Verification;
using Ict.Common.Remoting.Server;
using Ict.Common.Remoting.Shared;
using Ict.Common.Session;
using Ict.Petra.Shared;
using Ict.Petra.Shared.Security;
using Ict.Petra.Shared.Interfaces.Plugins.MSysMan;
using Ict.Petra.Shared.MSysMan.Data;
using Ict.Petra.Server.App.Core.Security;
using Ict.Petra.Server.MSysMan.Data.Access;
using Ict.Petra.Server.MSysMan.Maintenance.SystemDefaults.WebConnectors;
using Ict.Petra.Server.MSysMan.Maintenance.WebConnectors;
using Ict.Petra.Server.MSysMan.Security.UserManager.WebConnectors;

namespace Ict.Petra.Server.MSysMan.Security.UserManager.WebConnectors
{
    /// <summary>
    /// The TUserManager class provides access to the security-related information
    /// of Users of a Petra DB.
    /// </summary>
    /// <remarks>
    /// Calls methods that have the same name in the
    /// Ict.Petra.Server.App.Core.Security.UserManager Namespace to perform its
    /// functionality!
    ///
    /// This is required in two places,
    /// because it is needed before the appdomain is loaded and therefore cannot be in MSysMan;
    /// and it is needed here to make it available to the client via MSysMan remotely
    /// </remarks>
    public class TUserManagerWebConnector
    {
        private static IUserAuthentication FUserAuthenticationClass = null;

        /// <summary>
        /// load the plugin assembly for authentication
        /// </summary>
        [NoRemoting]
        public static IUserAuthentication LoadAuthAssembly(string AUserAuthenticationMethod)
        {
            if (FUserAuthenticationClass == null)
            {
                // namespace of the class TUserAuthentication, eg. Plugin.AuthenticationPhpBB
                // the dll has to be in the normal application directory
                string Namespace = AUserAuthenticationMethod;
                string NameOfDll = TAppSettingsManager.ApplicationDirectory + Path.DirectorySeparatorChar + Namespace + ".dll";
                string NameOfClass = Namespace + ".TUserAuthentication";

                // dynamic loading of dll
                System.Reflection.Assembly assemblyToUse = System.Reflection.Assembly.LoadFrom(NameOfDll);
                System.Type CustomClass = assemblyToUse.GetType(NameOfClass);

                FUserAuthenticationClass = (IUserAuthentication)Activator.CreateInstance(CustomClass);
            }

            return FUserAuthenticationClass;
        }

        /// <summary>
        /// load details of user
        /// </summary>
        [NoRemoting]
        internal static SUserRow LoadUser(String AUserID, out TPetraPrincipal APetraPrincipal, TDBTransaction ATransaction)
        {
            SUserRow ReturnValue;

            TPetraIdentity PetraIdentity;

            ReturnValue = LoadUser(AUserID, out PetraIdentity, ATransaction);

            APetraPrincipal = new TPetraPrincipal(PetraIdentity, TGroupManager.LoadUserGroups(
                    AUserID, ATransaction), TTableAccessPermissionManager.LoadTableAccessPermissions(
                    AUserID, ATransaction), TModuleAccessManager.LoadUserModules(AUserID, ATransaction));

/*
 *          TLogging.LogAtLevel (8, "APetraPrincipal.IsTableAccessOK(tapMODIFY, 'p_person'): " +
 *                  APetraPrincipal.IsTableAccessOK(TTableAccessPermission.tapMODIFY, "p_person").ToString());
 */
            return ReturnValue;
        }

        /// <summary>
        /// Loads the details of the user from the s_user DB Table.
        /// </summary>
        /// <param name="AUserID">User ID to load the details for.</param>
        /// <param name="APetraIdentity">An instance of <see cref="TPetraIdentity"/> that is populated according
        /// to data in the s_user record.</param>
        /// <param name="ATransaction">Instantiated DB Transaction.</param>
        /// <returns>s_user record of the User (if the user exists).</returns>
        /// <exception cref="EUserNotExistantException">Throws <see cref="EUserNotExistantException"/> if the user
        /// doesn't exist!</exception>
        [NoRemoting]
        private static SUserRow LoadUser(String AUserID, out TPetraIdentity APetraIdentity, TDBTransaction ATransaction)
        {
            SUserRow ReturnValue;
            SUserTable UserDT = null;
            SUserRow UserDR;
            DateTime LastLoginDateTime;
            DateTime FailedLoginDateTime;

            // Check if user exists in s_user DB Table
            if (!SUserAccess.Exists(AUserID, ATransaction))
            {
                throw new EUserNotExistantException(StrInvalidUserIDPassword);
            }

            // User exists, so load User record
            UserDT = SUserAccess.LoadByPrimaryKey(AUserID, ATransaction);

            UserDR = UserDT[0];

            if (!UserDR.IsFailedLoginDateNull())
            {
                FailedLoginDateTime = UserDR.FailedLoginDate.Value;
                FailedLoginDateTime = FailedLoginDateTime.AddSeconds(Convert.ToDouble(UserDR.FailedLoginTime));
            }
            else
            {
                FailedLoginDateTime = DateTime.MinValue;
            }

            if (!UserDR.IsLastLoginDateNull())
            {
                LastLoginDateTime = UserDR.LastLoginDate.Value;
                LastLoginDateTime = LastLoginDateTime.AddSeconds(Convert.ToDouble(UserDR.LastLoginTime));
            }
            else
            {
                LastLoginDateTime = DateTime.MinValue;
            }

            Int64 PartnerKey;

            if (!UserDR.IsPartnerKeyNull())
            {
                PartnerKey = UserDR.PartnerKey;
            }
            else
            {
                // to make it not match PartnerKey 0, which might be stored in the DB or in a variable
                PartnerKey = -1;
            }

            // Create PetraIdentity
            APetraIdentity = new Ict.Petra.Shared.Security.TPetraIdentity(
                AUserID.ToUpper(), UserDR.LastName, UserDR.FirstName, UserDR.LanguageCode, UserDR.AcquisitionCode, DateTime.MinValue,
                LastLoginDateTime, FailedLoginDateTime, UserDR.FailedLogins, PartnerKey, UserDR.DefaultLedgerNumber, UserDR.AccountLocked,
                UserDR.Retired, UserDR.CanModify);
            ReturnValue = UserDR;

            return ReturnValue;
        }

        /// <summary>
        /// Authenticate a user.
        /// </summary>
        /// <param name="AUserID">User ID.</param>
        /// <param name="APassword">Password.</param>
        /// <param name="AClientComputerName">Name of the Client Computer that the authentication request came from.</param>
        /// <param name="AClientIPAddress">IP Address of the Client Computer that the authentication request came from.</param>
        /// <param name="ASystemEnabled">True if the system is enabled, otherwise false.</param>
        /// <param name="ATransaction">Instantiated DB Transaction.</param>
        /// <returns>An instance of <see cref="TPetraPrincipal"/> if the authentication was successful, otherwise null.</returns>
        [NoRemoting]
        public static TPetraPrincipal PerformUserAuthentication(String AUserID, String APassword,
            string AClientComputerName, string AClientIPAddress, out Boolean ASystemEnabled,
            TDBTransaction ATransaction)
        {
            SUserRow UserDR;
            DateTime LoginDateTime;
            TPetraPrincipal PetraPrincipal = null;
            string UserAuthenticationMethod = TAppSettingsManager.GetValue("UserAuthenticationMethod", "OpenPetraDBSUser", false);
            IUserAuthentication AuthenticationAssembly;
            string AuthAssemblyErrorMessage;

            Int32 AProcessID = -1;

            ASystemEnabled = true;

            string EmailAddress = AUserID;

            if (AUserID.Contains("@"))
            {
                AUserID = AUserID.Substring(0, AUserID.IndexOf("@")).
                          Replace(".", string.Empty).
                          Replace("_", string.Empty).ToUpper();
            }

            try
            {
                UserDR = LoadUser(AUserID, out PetraPrincipal, ATransaction);
            }
            catch (EUserNotExistantException)
            {
                // Logging
                TLoginLog.AddLoginLogEntry(AUserID, TLoginLog.LOGIN_STATUS_TYPE_LOGIN_ATTEMPT_FOR_NONEXISTING_USER,
                    String.Format(Catalog.GetString(
                            "User with User ID '{0}' attempted to log in, but there is no user account for this user! "),
                        AUserID) + String.Format(ResourceTexts.StrRequestCallerInfo, AClientComputerName, AClientIPAddress),
                    out AProcessID, ATransaction);

                // Only now throw the Exception!
                throw;
            }

            UserInfo.GUserInfo = PetraPrincipal;

            if ((AUserID == "SYSADMIN") && TSession.HasVariable("ServerAdminToken"))
            {
                // Login via server admin console authenticated by file token
            }
            //
            // (1) Check user-supplied password
            //
            else if (UserAuthenticationMethod == "OpenPetraDBSUser")
            {
                if (!TPasswordHelper.EqualsAntiTimingAttack(
                             Convert.FromBase64String(
                                  CreateHashOfPassword(APassword, UserDR.PasswordSalt, UserDR.PwdSchemeVersion)), 
                             Convert.FromBase64String(UserDR.PasswordHash)))
                {
                    // The password that the user supplied is wrong!!! --> Save failed user login attempt!
                    // If the number of permitted failed logins in a row gets exceeded then also lock the user account!
                    SaveFailedLogin(AUserID, UserDR, AClientComputerName, AClientIPAddress, ATransaction);

                    if (UserDR.AccountLocked
                        && (Convert.ToBoolean(UserDR[SUserTable.GetAccountLockedDBName(), DataRowVersion.Original]) != UserDR.AccountLocked))
                    {
                        // User Account just got locked!
                        throw new EUserAccountGotLockedException(StrInvalidUserIDPassword);
                    }
                    else
                    {
                        throw new EPasswordWrongException(StrInvalidUserIDPassword);
                    }
                }
            }
            else
            {
                AuthenticationAssembly = LoadAuthAssembly(UserAuthenticationMethod);

                if (!AuthenticationAssembly.AuthenticateUser(EmailAddress, APassword, out AuthAssemblyErrorMessage))
                {
                    // The password that the user supplied is wrong!!! --> Save failed user login attempt!
                    // If the number of permitted failed logins in a row gets exceeded then also lock the user account!
                    SaveFailedLogin(AUserID, UserDR, AClientComputerName, AClientIPAddress, ATransaction);

                    if (UserDR.AccountLocked
                        && (Convert.ToBoolean(UserDR[SUserTable.GetAccountLockedDBName(), DataRowVersion.Original]) != UserDR.AccountLocked))
                    {
                        // User Account just got locked!
                        throw new EUserAccountGotLockedException(StrInvalidUserIDPassword);
                    }
                    else
                    {
                        throw new EPasswordWrongException(AuthAssemblyErrorMessage);
                    }
                }
            }

            //
            // (2) Check if the User Account is Locked or if the user is 'Retired'. If either is true then deny the login!!!
            //
            // IMPORTANT: We perform these checks only AFTER the check for the correctness of the password so that every
            // log-in attempt that gets rejected on grounds of a wrong password takes the same amount of time (to help prevent
            // an attack vector called 'timing attack')
            if (PetraPrincipal.PetraIdentity.AccountLocked || PetraPrincipal.PetraIdentity.Retired)
            {
                if (PetraPrincipal.PetraIdentity.AccountLocked)
                {
                    // Logging
                    TLoginLog.AddLoginLogEntry(AUserID, TLoginLog.LOGIN_STATUS_TYPE_LOGIN_ATTEMPT_FOR_LOCKED_USER,
                        Catalog.GetString("User attempted to log in, but the user account was locked! ") +
                        String.Format(ResourceTexts.StrRequestCallerInfo, AClientComputerName, AClientIPAddress),
                        out AProcessID, ATransaction);

                    // Only now throw the Exception!
                    throw new EUserAccountLockedException(StrInvalidUserIDPassword);
                }
                else
                {
                    // Logging
                    TLoginLog.AddLoginLogEntry(AUserID, TLoginLog.LOGIN_STATUS_TYPE_LOGIN_ATTEMPT_FOR_RETIRED_USER,
                        Catalog.GetString("User attempted to log in, but the user is retired! ") +
                        String.Format(ResourceTexts.StrRequestCallerInfo, AClientComputerName, AClientIPAddress),
                        out AProcessID, ATransaction);

                    // Only now throw the Exception!
                    throw new EUserRetiredException(StrInvalidUserIDPassword);
                }
            }

            //
            // (3) Check SystemLoginStatus (whether the general use of the OpenPetra application is enabled/disabled) in the
            // SystemStatus table (this table always holds only a single record)
            //
            Boolean NewTransaction = false;
            SSystemStatusTable SystemStatusDT;

            SystemStatusDT = SSystemStatusAccess.LoadAll(ATransaction);

            if (SystemStatusDT[0].SystemLoginStatus)
            {
                ASystemEnabled = true;
            }
            else
            {
                ASystemEnabled = false;

                // TODO: Check for Security Group membership might need reviewal when security model of OpenPetra might get reviewed...
                if (PetraPrincipal.IsInGroup("SYSADMIN"))
                {
                    PetraPrincipal.LoginMessage =
                        String.Format(StrSystemDisabled1,
                            SystemStatusDT[0].SystemDisabledReason) + Environment.NewLine + Environment.NewLine +
                        StrSystemDisabled2Admin;
                }
                else
                {
                    TLoginLog.AddLoginLogEntry(AUserID, TLoginLog.LOGIN_STATUS_TYPE_LOGIN_ATTEMPT_WHEN_SYSTEM_WAS_DISABLED,
                        Catalog.GetString("User wanted to log in, but the System was disabled. ") +
                        String.Format(ResourceTexts.StrRequestCallerInfo, AClientComputerName, AClientIPAddress),
                        out AProcessID, ATransaction);

                    TLoginLog.RecordUserLogout(AUserID, AProcessID, ATransaction);

                    throw new ESystemDisabledException(String.Format(StrSystemDisabled1,
                            SystemStatusDT[0].SystemDisabledReason) + Environment.NewLine + Environment.NewLine +
                        String.Format(StrSystemDisabled2, StringHelper.DateToLocalizedString(SystemStatusDT[0].SystemAvailableDate.Value),
                            SystemStatusDT[0].SystemAvailableDate.Value.AddSeconds(SystemStatusDT[0].SystemAvailableTime).ToShortTimeString()));
                }
            }

            //
            // (4) Save successful login!
            //
            LoginDateTime = DateTime.Now;
            UserDR.LastLoginDate = LoginDateTime;
            UserDR.LastLoginTime = Conversions.DateTimeToInt32Time(LoginDateTime);
            UserDR.FailedLogins = 0;  // this needs resetting!

            // Upgrade the user's password hashing scheme if it is older than the current password hashing scheme
            if (UserDR.PwdSchemeVersion < TPasswordHelper.CurrentPasswordSchemeNumber)
            {
                TMaintenanceWebConnector.SetNewPasswordHashAndSaltForUser(UserDR, APassword,
                    AClientComputerName, AClientIPAddress, ATransaction);
            }

            SaveUser(AUserID, (SUserTable)UserDR.Table, ATransaction);

            PetraPrincipal.PetraIdentity.CurrentLogin = LoginDateTime;

            //PetraPrincipal.PetraIdentity.FailedLogins = 0;

            // TODO: Check for Security Group membership might need reviewal when security model of OpenPetra might get reviewed...

            if (PetraPrincipal.IsInGroup("SYSADMIN"))
            {
                TLoginLog.AddLoginLogEntry(AUserID, TLoginLog.LOGIN_STATUS_TYPE_LOGIN_SUCCESSFUL_SYSADMIN,
                    Catalog.GetString("User login - SYSADMIN privileges. ") +
                    String.Format(ResourceTexts.StrRequestCallerInfo, AClientComputerName, AClientIPAddress),
                    out AProcessID, ATransaction);
            }
            else
            {
                TLoginLog.AddLoginLogEntry(AUserID, TLoginLog.LOGIN_STATUS_TYPE_LOGIN_SUCCESSFUL,
                    Catalog.GetString("User login. ") +
                    String.Format(ResourceTexts.StrRequestCallerInfo, AClientComputerName, AClientIPAddress),
                    out AProcessID, ATransaction);
            }

            PetraPrincipal.ProcessID = AProcessID;
            AProcessID = 0;

            //
            // (5) Check if a password change is requested for this user
            //
            if (UserDR.PasswordNeedsChange)
            {
                // The user needs to change their password before they can use OpenPetra
                PetraPrincipal.LoginMessage = SharedConstants.LOGINMUSTCHANGEPASSWORD;
            }

            return PetraPrincipal;
        }

        /// <summary>
        /// Save a failed user login attempt. If the number of permitted failed logins in a row gets exceeded then the
        /// user account gets Locked, too!
        /// </summary>
        /// <param name="AUserID">User ID.</param>
        /// <param name="UserDR">s_user DataRow of the user.</param>
        /// <param name="AClientComputerName">Name of the Client Computer that the authentication request came from.</param>
        /// <param name="AClientIPAddress">IP Address of the Client Computer that the authentication request came from.</param>
        /// <param name="ATransaction">Instantiated DB Transaction.</param>
        private static void SaveFailedLogin(string AUserID, SUserRow UserDR,
            string AClientComputerName, string AClientIPAddress, TDBTransaction ATransaction)
        {
            int AProcessID;
            int FailedLoginsUntilAccountGetsLocked =
                TSystemDefaults.GetInt32Default(SharedConstants.SYSDEFAULT_FAILEDLOGINS_UNTIL_ACCOUNT_GETS_LOCKED, 10);
            bool AccountLockedAtThisAttempt = false;

            // Console.WriteLine('PetraPrincipal.PetraIdentity.FailedLogins: ' + PetraPrincipal.PetraIdentity.FailedLogins.ToString +
            // '; PetraPrincipal.PetraIdentity.AccountLocked: ' + PetraPrincipal.PetraIdentity.AccountLocked.ToString);

            UserDR.FailedLogins++;
            UserDR.FailedLoginDate = DateTime.Now;
            UserDR.FailedLoginTime = Conversions.DateTimeToInt32Time(UserDR.FailedLoginDate.Value);

            // Check if User Account should be Locked due to too many successive failed log-in attempts
            if ((UserInfo.GUserInfo.PetraIdentity.FailedLogins >= FailedLoginsUntilAccountGetsLocked)
                && ((!UserInfo.GUserInfo.PetraIdentity.AccountLocked)))
            {
                // Lock User Account (this user will no longer be able to log in until a Sysadmin resets this flag!)
                UserDR.AccountLocked = true;
                AccountLockedAtThisAttempt = true;

                TUserAccountActivityLog.AddUserAccountActivityLogEntry(UserDR.UserId,
                    TUserAccountActivityLog.USER_ACTIVITY_PERMITTED_FAILED_LOGINS_EXCEEDED,
                    String.Format(Catalog.GetString(
                            "The permitted number of failed logins in a row got exceeded and the user account for the user {0} got locked! ") +
                        String.Format(ResourceTexts.StrRequestCallerInfo, AClientComputerName, AClientIPAddress),
                        UserDR.UserId), ATransaction);
            }

            // Logging
            TLoginLog.AddLoginLogEntry(AUserID,
                AccountLockedAtThisAttempt ? TLoginLog.LOGIN_STATUS_TYPE_LOGIN_ATTEMPT_PWD_WRONG_ACCOUNT_GOT_LOCKED :
                TLoginLog.LOGIN_STATUS_TYPE_LOGIN_ATTEMPT_PWD_WRONG,
                String.Format(Catalog.GetString("User supplied wrong password{0}!  (Failed Logins: now {1}; " +
                        "Account Locked: now {2}, User Retired: {3}) "),
                    (AccountLockedAtThisAttempt ?
                     Catalog.GetString("; because the permitted number of failed logins in a row got exceeded the user account " +
                         "for the user got locked! ") : String.Empty),
                    UserDR.FailedLogins, UserDR.AccountLocked, UserDR.Retired) +
                String.Format(ResourceTexts.StrRequestCallerInfo, AClientComputerName, AClientIPAddress),
                out AProcessID, ATransaction);

            SaveUser(AUserID, (SUserTable)UserDR.Table, ATransaction);
        }

        /// <summary>
        /// Call this Method when a log-in is attempted for a non-existing user (!) so that the time that is spent on
        /// 'authenticating' them is as long as is spent on authenticating existing users. This is done so that an attacker
        /// that tries to perform user authentication with 'username guessing' cannot easily tell that the user doesn't exist by
        /// checking the time in which the server returns an error (this is an attack vector called 'timing attack')!
        /// </summary>
        [NoRemoting]
        public static void SimulatePasswordAuthenticationForNonExistingUser()
        {
            string UserAuthenticationMethod = TAppSettingsManager.GetValue("UserAuthenticationMethod", "OpenPetraDBSUser", false);

            if (UserAuthenticationMethod == "OpenPetraDBSUser")
            {
                TUserManagerWebConnector.CreateHashOfPassword("wrongPassword",
                    Convert.ToBase64String(TPasswordHelper.CurrentPasswordScheme.GetNewPasswordSalt()),
                    TPasswordHelper.CurrentPasswordSchemeNumber);
            }
            else
            {
                IUserAuthentication auth = TUserManagerWebConnector.LoadAuthAssembly(UserAuthenticationMethod);

                string ErrorMessage;

                auth.AuthenticateUser("wrongUser", "wrongPassword", out ErrorMessage);
            }
        }

        #region Resourcestrings

        private static readonly string StrSystemDisabled1 = Catalog.GetString("OpenPetra is currently disabled due to {0}.");

        private static readonly string StrSystemDisabled2 = Catalog.GetString("It will be available on {0} at {1}.");

        private static readonly string StrSystemDisabled2Admin = Catalog.GetString("Proceed with caution.");

        private static readonly string StrInvalidUserIDPassword = Catalog.GetString("Invalid User ID or Password.");

        #endregion

        /// <summary>
        /// create hash of password and the salt.
        /// replacement for FormsAuthentication.HashPasswordForStoringInConfigFile
        /// which is part of System.Web.dll and not available in the client profile of .net v4.0
        /// </summary>
        /// <param name="APassword">Password (plain-text).</param>
        /// <param name="ASalt">Salt for 'salting' the password hash. MUST be obtained from the same Password Helper
        /// Class version that gets called in this Method - the Class gets chosen in this Method by evaluating
        /// <paramref name="APasswordSchemeVersion"/></param>.
        /// <param name="APasswordSchemeVersion">Version of the Password Hashing Scheme.</param>
        /// <returns>Password Hash of <paramref name="APassword"/> according to
        /// <paramref name="APasswordSchemeVersion"/> and the passed-in <paramref name="ASalt"/>.</returns>
        [NoRemoting]
        public static string CreateHashOfPassword(string APassword, string ASalt, int APasswordSchemeVersion)
        {
            if (APasswordSchemeVersion == 0)
            {
                // MD5 - DO NOT USE ANYMORE as this password hash is completely unsafe nowadays!
                return BitConverter.ToString(
                    MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(String.Concat(APassword,
                                                       ASalt)))).Replace("-", "");
            }
            else
            {
                return TPasswordHelper.GetPasswordSchemeHelperForVersion(APasswordSchemeVersion).GetPasswordHash(
                        APassword, Convert.FromBase64String(ASalt));
            }
        }

        /// <summary>
        /// Causes an immediately reload of the UserInfo that is stored in a global
        /// variable.
        /// </summary>
        [RequireModulePermission("NONE")]
        public static TPetraPrincipal ReloadCachedUserInfo()
        {
            TDBTransaction ReadTransaction = null;
            TPetraPrincipal UserDetails = null;

            try
            {
                DBAccess.SimpleAutoReadTransactionWrapper("ReloadCachedUserInfo", out ReadTransaction, delegate
                    {
                        LoadUser(UserInfo.GUserInfo.UserID, out UserDetails, ReadTransaction);
                    });

                UserInfo.GUserInfo = UserDetails;
            }
            catch (Exception Exp)
            {
                TLogging.Log("Exception occured in ReloadCachedUserInfo: " + Exp.ToString());
                throw;
            }

            return UserInfo.GUserInfo;
        }

        /// <summary>
        /// save user details (last login time, failed logins etc)
        /// </summary>
        [NoRemoting]
        private static Boolean SaveUser(String AUserID, SUserTable AUserDataTable, TDBTransaction ATransaction)
        {
            if ((AUserDataTable != null) && (AUserDataTable.Rows.Count > 0))
            {
                try
                {
                    SUserAccess.SubmitChanges(AUserDataTable, ATransaction);
                }
                catch (Exception Exc)
                {
                    TLogging.Log("An Exception occured during the saving of a User:" + Environment.NewLine + Exc.ToString());

                    throw;
                }
            }
            else
            {
                // nothing to save!
                return false;
            }

            return true;
        }

        /// <summary>
        /// Queues a ClientTask for reloading of the UserInfo for all connected Clients
        /// with a certain UserID.
        ///
        /// </summary>
        /// <param name="AUserID">UserID for which the ClientTask should be queued
        /// </param>
        [RequireModulePermission("NONE")]
        public static void SignalReloadCachedUserInfo(String AUserID)
        {
            TClientManager.QueueClientTask(AUserID,
                SharedConstants.CLIENTTASKGROUP_USERINFOREFRESH,
                "",
                null, null, null, null,
                1,
                -1);
        }
    }
}

namespace Ict.Petra.Server.MSysMan.Maintenance.UserManagement
{
    /// <summary>
    /// this manager is called from Server.App.Core
    /// </summary>
    public class TUserManager : IUserManager
    {
        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <remarks>Gets called from TServerManager.AddUser() Method, which in turn gets utilised by the
        /// PetraMultiStart.exe application for the creation of test users for that application.</remarks>
        public bool AddUser(string AUserID, string APassword = "")
        {
            return TMaintenanceWebConnector.CreateUser(AUserID,
                APassword,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                TMaintenanceWebConnector.DEMOMODULEPERMISSIONS);
        }

        /// <summary>
        /// Authenticate a user.
        /// </summary>
        /// <param name="AUserID">User ID.</param>
        /// <param name="APassword">Password.</param>
        /// <param name="AClientComputerName">Name of the Client Computer that the authentication request came from.</param>
        /// <param name="AClientIPAddress">IP Address of the Client Computer that the authentication request came from.</param>
        /// <param name="ASystemEnabled">True if the system is enabled, otherwise false.</param>
        /// <param name="ATransaction">Instantiated DB Transaction.</param>
        /// <returns>An instance of <see cref="TPetraPrincipal"/> if the authentication was successful, otherwise null.</returns>
        public IPrincipal PerformUserAuthentication(string AUserID, string APassword,
            string AClientComputerName, string AClientIPAddress,
            out Boolean ASystemEnabled,
            TDBTransaction ATransaction)
        {
            return TUserManagerWebConnector.PerformUserAuthentication(AUserID, APassword, AClientComputerName, AClientIPAddress,
                out ASystemEnabled, ATransaction);
        }

        /// <summary>
        /// Call this Method when a log-in is attempted for a non-existing user (!) so that the time that is spent on
        /// 'authenticating' them is as long as is spent on authenticating existing users. This is done so that an attacker
        /// that tries to perform user authentication with 'username guessing' cannot easily tell that the user doesn't exist by
        /// checking the time in which the server returns an error (this is an attack vector called 'timing attack')!
        /// </summary>
        public void SimulatePasswordAuthenticationForNonExistingUser()
        {
            TUserManagerWebConnector.SimulatePasswordAuthenticationForNonExistingUser();
         }
    }
}
