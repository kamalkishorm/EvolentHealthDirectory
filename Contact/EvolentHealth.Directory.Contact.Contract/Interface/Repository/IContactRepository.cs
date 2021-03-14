using System.Collections.Generic;
using System.Threading.Tasks;
using EvolentHealth.Directory.Contact.Contract.Models.Dto;

namespace EvolentHealth.Directory.Contact.Contract.Interface.Repository
{
    public interface IContactRepository
    {
        /// <summary>
        /// Get all list exist contact
        /// </summary>
        /// <returns>List of contacts</returns>
        Task<IEnumerable<ContactDto>> GetContactList();

        /// <summary>
        /// Get Contact detail by Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Contact detail</returns>
        Task<ContactDto> GetContactById(int id);

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="newContact">new customer detail</param>
        /// <returns>Customer is added</returns>
        Task<bool> CreateContact(ContactDto newContact);

        /// <summary>
        /// Update Contact detail
        /// </summary>
        /// <param name="id">contact Id</param>
        /// <param name="newContact">contact new detail</param>
        /// <returns>Contact detail is updated </returns>
        Task<bool> UpdateContact(int id, ContactDto newContact);

        /// <summary>
        /// Update contact status/delete (Active or Inactive)
        /// </summary>
        /// <param name="id">Contact Id</param>
        /// <param name="status">Status</param>
        /// <returns>Is Updated</returns>
        Task<bool> UpdateStatusContact(int id, string status);
    }

}
