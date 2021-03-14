using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EvolentHealth.Directory.Contact.Contract.Interface.Business;
using EvolentHealth.Directory.Contact.Contract.Models.Dto;
using EvolentHealth.Directory.Contact.Hosting.AzureFunction.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;

namespace EvolentHealth.Directory.Contact.Hosting.AzureFunction
{
    public class ContactAzureFunction
    {
        private readonly IContacts _contacts;

        public ContactAzureFunction(IContacts contacts)
        {
            _contacts = contacts;
        }

        [FunctionName("ContactList")]
        public async Task<IActionResult> GetContactList(
            [HttpTrigger(AuthorizationLevel.Function,"get",Route = AzureFunctionRoutes.GetAllContact)] HttpRequest req)
        {
            var contacts = await _contacts.GetContactList().ConfigureAwait(false);
            return new OkObjectResult(
                AzureFunctionAutoMapper.Mapper.Map<IEnumerable<Contract.Models.Business.Contact>, IEnumerable<ContactDto>>(contacts)
                );
        }

        [FunctionName("GetContact")]
        public async Task<IActionResult> GetContactById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = AzureFunctionRoutes.ContactById)] HttpRequest req, string id)
        {
            var contactId = int.Parse(id);
            if (contactId == 0)
            {
                return new BadRequestResult();
            }
            var contact = await _contacts.GetContactById(contactId).ConfigureAwait(false);
            return new OkObjectResult(
                AzureFunctionAutoMapper.Mapper.Map<Contract.Models.Business.Contact, ContactDto>(contact)
            );
        }

        [FunctionName("AddContact")]
        public async Task<IActionResult> CreateContact(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = AzureFunctionRoutes.ContactById)] ContactDto contact)
        {

            var newContact =AzureFunctionAutoMapper.Mapper.Map<ContactDto, Contract.Models.Business.Contact>(contact);

            var isCreated = await _contacts.CreateContact(newContact).ConfigureAwait(false);
            return new OkObjectResult(isCreated);
        }

        [FunctionName("UpdateContact")]
        public async Task<IActionResult> UpdateContact(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = AzureFunctionRoutes.ContactById)] HttpRequest req, string id)
        {
            var contactId = int.Parse(id);
            string requestBody = String.Empty;
            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }
            dynamic contact = JsonConvert.DeserializeObject<ContactDto>(requestBody);

            if (contactId == 0 || contact == null)
            {
                return new BadRequestResult();
            }
            

            var newContact = AzureFunctionAutoMapper.Mapper.Map<ContactDto, Contract.Models.Business.Contact>(contact);

            var isUpdated = await _contacts.UpdateContact(contactId, newContact).ConfigureAwait(false);
            return new OkObjectResult(isUpdated);
        }

        [FunctionName("UpdateStatusContact")]
        public async Task<IActionResult> UpdateStatusContact(
            [HttpTrigger(AuthorizationLevel.Function, "patch", Route = AzureFunctionRoutes.UpdateContactStatus)]HttpRequest req, string id, string isActive)
        {
            var contactId = int.Parse(id);
            if (contactId == 0)
            {
                return new BadRequestResult();
            }
            var status = bool.Parse(isActive) ? StatusValue.Active : StatusValue.InActive;
            var isUpdated = await _contacts.UpdateStatusContact(contactId, status).ConfigureAwait(false);
            return new OkObjectResult(isUpdated);
        }
    }
}