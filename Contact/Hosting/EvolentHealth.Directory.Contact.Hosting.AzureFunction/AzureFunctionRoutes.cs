namespace EvolentHealth.Directory.Contact.Hosting.AzureFunction
{
    public static class AzureFunctionRoutes
    {
        public const string GetAllContact = "api/contact";
        public const string ContactById = "api/contact/{id}";
        public const string UpdateContactStatus = "api/contact/{id}/{isActive}";
    }
}