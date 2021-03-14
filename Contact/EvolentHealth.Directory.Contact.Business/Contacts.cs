using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EvolentHealth.Directory.Contact.Contract.Interface.Business;
using EvolentHealth.Directory.Contact.Contract.Interface.DataAccess;
using EvolentHealth.Directory.Contact.Contract.Models.Dto;
using EvolentHealth.Directory.Core.Utils;
using Microsoft.Extensions.Logging;

namespace EvolentHealth.Directory.Contact.Business
{
    
    public class Contacts : IContacts
    {
        private readonly IContactDataAccess _contactDataAccess;
        private readonly ILogger<Contacts> _logger;

        public Contacts(IContactDataAccess contactDataAccess, ILogger<Contacts> logger)
        {
            _contactDataAccess = contactDataAccess;
            _logger = logger;
        }

        /// <summary>
        /// Get all list exist contact
        /// </summary>
        /// <returns>List of contacts</returns>
        public async Task<IEnumerable<Contract.Models.Business.Contact>> GetContactList()
        {
            return await _contactDataAccess.GetContactList().ConfigureAwait(false);
        }

        /// <summary>
        /// Get Contact detail by Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Contact detail</returns>
        public async Task<Contract.Models.Business.Contact> GetContactById(int id)
        {
            if (id != 0) return await _contactDataAccess.GetContactById(id).ConfigureAwait(false);
            var exception = new InvalidDataException("`Id` can't be zero");
            _logger.LogException(exception);
            throw exception;
        }

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="newContact">new customer detail</param>
        /// <returns>Customer is added</returns>
        public async Task<bool> CreateContact(Contract.Models.Business.Contact newContact)
        {
            newContact.FirstName.ThrowIfNullOrEmpty("FirstName","First Name is required",_logger);
            newContact.Email.ThrowIfNullOrEmpty("Email","Email is required",_logger);
            newContact.Status = StatusValue.Active;
            return await _contactDataAccess.CreateContact(newContact);
        }

        /// <summary>
        /// Update Contact detail
        /// </summary>
        /// <param name="id">contact Id</param>
        /// <param name="newContact">contact new detail</param>
        /// <returns>Contact detail is updated </returns>
        public async Task<bool> UpdateContact(int id, Contract.Models.Business.Contact newContact)
        {
            if (id != 0) return await _contactDataAccess.UpdateContact(id,newContact).ConfigureAwait(false);
            var exception = new InvalidDataException("`Id` can't be zero");
            _logger.LogException(exception);
            throw exception;
        }


        /// <summary>
        /// Update contact status/delete (Active or Inactive)
        /// </summary>
        /// <param name="id">Contact Id</param>
        /// <param name="status">Status</param>
        /// <returns>Is Updated</returns>
        public async Task<bool> UpdateStatusContact(int id, string status)
        {
            status.ThrowIfNullOrEmpty("Status","Status value is required",_logger);
            if (id != 0) return await _contactDataAccess.UpdateStatusContact(id, status).ConfigureAwait(false);
            var exception = new InvalidDataException("`Id` can't be zero");
            _logger.LogException(exception);
            throw exception;
        }

    }
}
