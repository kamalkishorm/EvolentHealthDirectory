using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvolentHealth.Directory.Contact.Contract.Interface.Repository;
using EvolentHealth.Directory.Contact.Contract.Models.Dto;
using EvolentHealth.Directory.Contact.Repository.Context;
using EvolentHealth.Directory.Core.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EvolentHealth.Directory.Contact.Repository
{
    /// <summary>
    /// Performing CRUD operation on Contact Table
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly EvolentHealthDirectoryContext _context;
        private readonly ILogger<ContactRepository> _logger;

        public ContactRepository(EvolentHealthDirectoryContext context, ILogger<ContactRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Get all list exist contact
        /// </summary>
        /// <returns>List of contacts</returns>
        public async Task<IEnumerable<ContactDto>> GetContactList()
        {
            try
            {
                var query = from contact in _context.Contacts
                    select new ContactDto
                    {
                        Id = contact.Id,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        PhoneNumber = contact.PhoneNumber,
                        Email = contact.Email,
                        Status = contact.Status
                    };
                return await query.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return new List<ContactDto>();
            }
        }

        /// <summary>
        /// Get Contact detail by Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Contact detail</returns>
        public async Task<ContactDto> GetContactById(int id)
        {
            try
            {
                var query = from contact in _context.Contacts
                    where contact.Id.Equals(id)
                    select new ContactDto
                    {
                        Id = contact.Id,
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        PhoneNumber = contact.PhoneNumber,
                        Email = contact.Email,
                        Status = contact.Status
                    };

                return await query.FirstOrDefaultAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return new ContactDto();
            }
        }

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="newContact">new customer detail</param>
        /// <returns>Customer is added</returns>
        public async Task<bool> CreateContact(ContactDto newContact)
        {
            try
            {
                _context.Add(new Models.Contact()
                {
                    FirstName = newContact.FirstName,
                    LastName = newContact.LastName,
                    Email = newContact.Email,
                    PhoneNumber = newContact.PhoneNumber,
                    Status = newContact.Status
                });
                var isAdded = await _context.SaveChangesAsync().ConfigureAwait(false);
                return isAdded == 1;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return false;
            }
        }

        /// <summary>
        /// Update Contact detail
        /// </summary>
        /// <param name="id">contact Id</param>
        /// <param name="newContact">contact new detail</param>
        /// <returns>Contact detail is updated </returns>
        public async Task<bool> UpdateContact(int id, ContactDto newContact)
        {
            try
            {
                Models.Contact c = (from contact in _context.Contacts
                    where contact.Id.Equals(id)
                    select contact).First();

                c.FirstName = string.IsNullOrEmpty(newContact.FirstName) ? c.FirstName : newContact.FirstName;
                c.LastName = string.IsNullOrEmpty(newContact.FirstName) ? c.LastName : newContact.LastName;
                c.Email = string.IsNullOrEmpty(newContact.FirstName) ? c.Email : newContact.Email;
                c.PhoneNumber = string.IsNullOrEmpty(newContact.FirstName) ? c.PhoneNumber : newContact.PhoneNumber;

                var isUpdated = await _context.SaveChangesAsync().ConfigureAwait(false);
                return isUpdated == 1;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return false;
            }
        }


        /// <summary>
        /// Update contact status/delete (Active or Inactive)
        /// </summary>
        /// <param name="id">Contact Id</param>
        /// <param name="status">Status</param>
        /// <returns>Is Updated</returns>
        public async Task<bool> UpdateStatusContact(int id, string status)
        {
            try
            {
                Models.Contact c = (from contact in _context.Contacts
                    where contact.Id.Equals(id)
                    select contact).First();

                c.Status = status;

                var isUpdated = await _context.SaveChangesAsync().ConfigureAwait(false);
                return isUpdated == 1;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return false;
            }
        }
    }
}