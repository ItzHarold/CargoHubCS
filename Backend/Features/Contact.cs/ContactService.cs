using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.Contacts
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        // void AddContact(Contact contact);
        // void UpdateContact(Contact contact);
        // void DeleteContact(int id);
    }

    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();

        public IEnumerable<Contact> GetAllContacts()
        {
            return _contacts;
        }
    }
}
