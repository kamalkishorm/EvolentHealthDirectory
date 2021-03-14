using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvolentHealth.Directory.Contact.Contract.Interface.Business
{
    public interface IContacts
    {
        /// <summary>
        /// Get all list exist contact
        /// </summary>
        /// <returns>List of contacts</returns>
        Task<IEnumerable<Contract.Models.Business.Contact>> GetContactList();

        /// <summary>
        /// Get Contact detail by Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Contact detail</returns>
        Task<Contract.Models.Business.Contact> GetContactById(int id);

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="newContact">new customer detail</param>
        /// <returns>Customer is added</returns>
        Task<bool> CreateContact(Contract.Models.Business.Contact newContact);

        /// <summary>
        /// Update Contact detail
        /// </summary>
        /// <param name="id">contact Id</param>
        /// <param name="newContact">contact new detail</param>
        /// <returns>Contact detail is updated </returns>
        Task<bool> UpdateContact(int id, Contract.Models.Business.Contact newContact);

        /// <summary>
        /// Update contact status/delete (Active or Inactive)
        /// </summary>
        /// <param name="id">Contact Id</param>
        /// <param name="status">Status</param>
        /// <returns>Is Updated</returns>
        Task<bool> UpdateStatusContact(int id, string status);
    }

}
