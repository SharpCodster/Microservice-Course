namespace VivaioInCloud.Common
{
    public static class SolutionConstants
    {
        public static class ConfigSections
        {
            //    public const string AUTHORIZATION = "Authorization";
            //    public const string LDAP_DOMAINS = "LdapDomains";
            public const string NOTIFICATION = "TODO";
            //    public const string ACCOUNT_REDIRECT_URLS = "AccountRedirectUrls";
            //    public const string JOBS = "Jobs";
            //    public const string MAG_NEWS_PARAMS = "MagNewsParams";
            //    public const string HTTP_CLIENT = "HttpClient";
            //    public const string MEMORY_CACHE = "Cache";
            //    public const string WORKORDER_SERVICE = "WorkOrderService";
            //    public const string LOCALIZATION = "Localization";
            //    public const string KEYVAULT_URL = "KeyVaultUri";
        }

        public static class DatabasesName
        {
            public const string CATALOG = "CatalogDatabase";
            public const string IDENTITY = "IdentityDatabase";
            public const string NOTIFICATION = "NotificationDatabase";
        }

        //public static class EventStream
        //{
        //    public static class Groups
        //    {
        //        public const string GENERAL = "fsm-worker";
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
            public const string ANONIMOUS_USER = "anonimous";

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

        public static class NotificationAction
        {
            public const string EMAIL = "email";
        }

        public static class EmailTemplates
        {
            public const string PASSWORD_RESET = "password-reset-template";
            public const string CONFIRM_ACCOUNT = "confirm-account-template";
        }

        public static class Seeding
        {
            public const string USER = "SEEDER";
            public static DateTime DATE = new DateTime(2022, 10, 1, 0, 0, 0, DateTimeKind.Utc);
        }
    }
}
