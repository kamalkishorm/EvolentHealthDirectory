﻿
namespace EvolentHealth.Directory.Contact.Contract.Models.Business
{
    public class Contact
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
    }
}
