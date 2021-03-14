using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EvolentHealth.Directory.Contact.Business;
using EvolentHealth.Directory.Contact.Contract.Interface.DataAccess;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EvolentHealth.Directory.Contact.UnitTest
{
    [TestClass]
    public class ContactTest
    {

        [TestMethod]
        public async Task Test_GetContactList()
        {
            Mock<IContactDataAccess> contactDataAccessMock = new Mock<IContactDataAccess>();
            Mock<ILogger<Contacts>> loggerMock = new Mock<ILogger<Contacts>>();

            IEnumerable<Contract.Models.Business.Contact> contacts = new List<Contract.Models.Business.Contact>()
            {
                new Contract.Models.Business.Contact()
                {
                    Id=1,
                    FirstName = "Test1",
                    Email = "test@test.com",
                    Status = "Active"
                }
            };
            contactDataAccessMock.Setup(x => x.GetContactList())
                .Returns(Task.FromResult(contacts));

            var contactsBusiness = new Contacts(contactDataAccessMock.Object, loggerMock.Object);
            var contactResponse = await contactsBusiness.GetContactList().ConfigureAwait(false);
            Assert.IsNotNull(contactResponse);
            Assert.IsTrue(contactResponse.First().Id == contacts.First().Id);
        }

        [TestMethod]
        public async Task Test_GetContactById()
        {
            Mock<IContactDataAccess> contactDataAccessMock = new Mock<IContactDataAccess>();
            Mock<ILogger<Contacts>> loggerMock = new Mock<ILogger<Contacts>>();

            const int ContactId = 1;
            Contract.Models.Business.Contact contacts =
                new Contract.Models.Business.Contact()
                {
                    Id = ContactId,
                    FirstName = "Test1",
                    Email = "test@test.com",
                    Status = "Active"
                };
            contactDataAccessMock.Setup(x => x.GetContactById(ContactId))
                .Returns(Task.FromResult(contacts));

            var contactsBusiness = new Contacts(contactDataAccessMock.Object, loggerMock.Object);
            var contactResponse = await contactsBusiness.GetContactById(ContactId).ConfigureAwait(false);
            Assert.IsNotNull(contactResponse);
            Assert.IsTrue(contactResponse.Id == ContactId);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "`Id` can't be zero.")]
        public async Task Test_GetContactById_IdIsZero_InvalidDataException()
        {
            Mock<IContactDataAccess> contactDataAccessMock = new Mock<IContactDataAccess>();
            Mock<ILogger<Contacts>> loggerMock = new Mock<ILogger<Contacts>>();

            const int ContactId = 0;

            var contactsBusiness = new Contacts(contactDataAccessMock.Object, loggerMock.Object);
            var contactResponse = await contactsBusiness.GetContactById(ContactId).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task Test_CreateContact()
        {
            Mock<IContactDataAccess> contactDataAccessMock = new Mock<IContactDataAccess>();
            Mock<ILogger<Contacts>> loggerMock = new Mock<ILogger<Contacts>>();

            const bool isCreated = true;
            Contract.Models.Business.Contact contact =
                new Contract.Models.Business.Contact()
                {
                    Id = 1,
                    FirstName = "Test1",
                    Email = "test@test.com"
                };
            contactDataAccessMock.Setup(x => x.CreateContact(contact))
                .Returns(Task.FromResult(isCreated));

            var contactsBusiness = new Contacts(contactDataAccessMock.Object, loggerMock.Object);
            var contactResponse = await contactsBusiness.CreateContact(contact).ConfigureAwait(false);
            Assert.IsNotNull(contactResponse);
            Assert.IsTrue(contactResponse);
            Assert.IsTrue(contactResponse == isCreated);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "FirstName is required")]
        public async Task Test_CreateContact_FirstNameNull_ArgumentNullException()
        {
            Mock<IContactDataAccess> contactDataAccessMock = new Mock<IContactDataAccess>();
            Mock<ILogger<Contacts>> loggerMock = new Mock<ILogger<Contacts>>();

            const bool isCreated = false;
            Contract.Models.Business.Contact contact =
                new Contract.Models.Business.Contact()
                {
                    Id = 1,
                    FirstName = null,
                    Email = "test@test.com"
                };
            contactDataAccessMock.Setup(x => x.CreateContact(contact))
                .Returns(Task.FromResult(isCreated));

            var contactsBusiness = new Contacts(contactDataAccessMock.Object, loggerMock.Object);
            var contactResponse = await contactsBusiness.CreateContact(contact).ConfigureAwait(false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Email is required")]
        public async Task Test_CreateContact_EmailEmpty_ArgumentNullException()
        {
            Mock<IContactDataAccess> contactDataAccessMock = new Mock<IContactDataAccess>();
            Mock<ILogger<Contacts>> loggerMock = new Mock<ILogger<Contacts>>();

            const bool isCreated = false;
            Contract.Models.Business.Contact contact =
                new Contract.Models.Business.Contact()
                {
                    Id = 1,
                    FirstName = "Test",
                    Email = ""
                };
            contactDataAccessMock.Setup(x => x.CreateContact(contact))
                .Returns(Task.FromResult(isCreated));

            var contactsBusiness = new Contacts(contactDataAccessMock.Object, loggerMock.Object);
            var contactResponse = await contactsBusiness.CreateContact(contact).ConfigureAwait(false);

        }


        [TestMethod]
        public async Task Test_UpdateContact()
        {
            Mock<IContactDataAccess> contactDataAccessMock = new Mock<IContactDataAccess>();
            Mock<ILogger<Contacts>> loggerMock = new Mock<ILogger<Contacts>>();

            const int contactId = 1;
            Contract.Models.Business.Contact contact =
                new Contract.Models.Business.Contact()
                {
                    Id = contactId,
                    FirstName = "Test1",
                    Email = "test@test.com",
                    Status = "Active"
                };
            const bool isUpdated = true;
            contactDataAccessMock.Setup(x => x.UpdateContact(contactId, contact))
                .Returns(Task.FromResult(isUpdated));

            var contactsBusiness = new Contacts(contactDataAccessMock.Object, loggerMock.Object);
            var contactResponse = await contactsBusiness.UpdateContact(contactId,contact).ConfigureAwait(false);
            Assert.IsNotNull(contactResponse);
            Assert.IsTrue(contactResponse);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "`Id` can't be zero.")]
        public async Task Test_UpdateContact_IdIsZero_InvalidDataException()
        {
            Mock<IContactDataAccess> contactDataAccessMock = new Mock<IContactDataAccess>();
            Mock<ILogger<Contacts>> loggerMock = new Mock<ILogger<Contacts>>();

            const int contactId = 0;
            var contact = new Contract.Models.Business.Contact();

            var contactsBusiness = new Contacts(contactDataAccessMock.Object, loggerMock.Object);
            var contactResponse = await contactsBusiness.UpdateContact(contactId, contact).ConfigureAwait(false);
        }


        [TestMethod]
        public async Task Test_UpdateStatusContact()
        {
            Mock<IContactDataAccess> contactDataAccessMock = new Mock<IContactDataAccess>();
            Mock<ILogger<Contacts>> loggerMock = new Mock<ILogger<Contacts>>();

            const int contactId = 1;
            const string status = "Inactive";
            const bool isUpdated = true;

            contactDataAccessMock.Setup(x => x.UpdateStatusContact(contactId,status))
                .Returns(Task.FromResult(isUpdated));

            var contactsBusiness = new Contacts(contactDataAccessMock.Object, loggerMock.Object);
            var contactResponse = await contactsBusiness.UpdateStatusContact(contactId,status).ConfigureAwait(false);
            Assert.IsNotNull(contactResponse);
            Assert.IsTrue(contactResponse);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "`Id` can't be zero.")]
        public async Task Test_UpdateStatusContact_IdIsZero_InvalidDataException()
        {
            Mock<IContactDataAccess> contactDataAccessMock = new Mock<IContactDataAccess>();
            Mock<ILogger<Contacts>> loggerMock = new Mock<ILogger<Contacts>>();

            const int contactId = 0;
            const string status = "Inactive";

            var contactsBusiness = new Contacts(contactDataAccessMock.Object, loggerMock.Object);
            var contactResponse = await contactsBusiness.UpdateStatusContact(contactId, status).ConfigureAwait(false);
        }
    }
}
