using System.Collections.Generic;
using System.Threading.Tasks;
using EvolentHealth.Directory.Contact.Contract.Interface.DataAccess;
using EvolentHealth.Directory.Contact.Contract.Interface.Repository;
using EvolentHealth.Directory.Contact.Contract.Models.Dto;
using EvolentHealth.Directory.Contact.DataAccess.Mapper;

namespace EvolentHealth.Directory.Contact.DataAccess
{
   
    public class ContactDataAccess : IContactDataAccess
    {
        private readonly IContactRepository _contactRepository;

        public ContactDataAccess(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        /// <summary>
        /// Get all list exist contact
        /// </summary>
        /// <returns>List of contacts</returns>
        public async Task<IEnumerable<Contract.Models.Business.Contact>> GetContactList()
        {
            var contacts = await _contactRepository.GetContactList().ConfigureAwait(false);
            return DataAccessAutoMapper.Mapper
                .Map<IEnumerable<ContactDto>, IEnumerable<Contract.Models.Business.Contact>>(contacts);
        }

        /// <summary>
        /// Get Contact detail by Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>Contact detail</returns>
        public async Task<Contract.Models.Business.Contact> GetContactById(int id)
        {
            var contact = await _contactRepository.GetContactById(id).ConfigureAwait(false);
            return DataAccessAutoMapper.Mapper.Map<ContactDto, Contract.Models.Business.Contact>(contact);
        }

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="newContact">new customer detail</param>
        /// <returns>Customer is added</returns>
        public async Task<bool> CreateContact(Contract.Models.Business.Contact newContact)
        {
            var newContactDto = DataAccessAutoMapper.Mapper.Map<Contract.Models.Business.Contact,ContactDto>(newContact);
            return await _contactRepository.CreateContact(newContactDto).ConfigureAwait(false);
        }

        /// <summary>
        /// Update Contact detail
        /// </summary>
        /// <param name="id">contact Id</param>
        /// <param name="newContact">contact new detail</param>
        /// <returns>Contact detail is updated </returns>
        public async Task<bool> UpdateContact(int id, Contract.Models.Business.Contact newContact)
        {
            var newContactDto = DataAccessAutoMapper.Mapper.Map<Contract.Models.Business.Contact, ContactDto>(newContact);
            return await _contactRepository.UpdateContact(id, newContactDto).ConfigureAwait(false);
        }


        /// <summary>
        /// Update contact status/delete (Active or Inactive)
        /// </summary>
        /// <param name="id">Contact Id</param>
        /// <param name="status">Status</param>
        /// <returns>Is Updated</returns>
        public async Task<bool> UpdateStatusContact(int id, string status)
        {
            return await _contactRepository.UpdateStatusContact(id, status);
        }

    }
}
