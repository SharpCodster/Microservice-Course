using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VivaioInCloud.Common
{
    public static class SolutionConstants
    {
        //public static class ConfigSections
        //{
        //    public const string AUTHORIZATION = "Authorization";
        //    public const string LDAP_DOMAINS = "LdapDomains";
        //    public const string KAFKA = "Kafka";
        //    public const string ACCOUNT_REDIRECT_URLS = "AccountRedirectUrls";
        //    public const string JOBS = "Jobs";
        //    public const string MAG_NEWS_PARAMS = "MagNewsParams";
        //    public const string HTTP_CLIENT = "HttpClient";
        //    public const string MEMORY_CACHE = "Cache";
        //    public const string WORKORDER_SERVICE = "WorkOrderService";
        //    public const string LOCALIZATION = "Localization";
        //    public const string KEYVAULT_URL = "KeyVaultUri";
        //}

        //public static class DatabasesName
        //{
        //    public const string LEGACY = "LegacyDatabase";
        //    public const string SAMPLE = "SampleDatabase";
        //    public const string IDENTITY = "IdentityDatabase";
        //    public const string WORK_ORDER = "WorkOrderDatabase";
        //}

        //public static class EventStream
        //{
        //    public static class Groups
        //    {
        //        public const string GENERAL = "eolo-fsm-worker";
        //    }
        //    public static class Topics
        //    {
        //        public const string SEND_EMAIL = "send-mail";
        //        public const string SEND_SMS = "send-sms";
        //        public const string SEND_NOTIFICATION = "send-notification";
        //    }
        //}

        public static class Authorization
        {
            public static class Roles
            {
                public const string ADMIN = "Admin";
                public const string USER = "User";
            }

            //public static class Scopes
            //{
            //    public const string SAMPLE = "sample-service";
            //}

            public const string DEFAULT_PASSWORD = "Pass@word1";

        }

        //public static class NotificationAction
        //{
        //    public const string EMAIL = "email";
        //}

        //public static class EmailTemplates
        //{
        //    public const string PASSWORD_RESET = "password-reset-template";
        //    public const string CONFIRM_ACCOUNT = "confirm-account-template";
        //}
    }
}
