﻿namespace EvolentHealth.Directory.Contact.Contract.Models.Dto
{
    public class ContactDto
    {
            public int? Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Status { get; set; }
    }
}