using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.Contacts
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        Contact? GetContactById(int id);
        void AddContact(Contact contact);
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

        public Contact? GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public void AddContact(Contact contact)
        {
            contact.Id = _contacts.Count > 0 ? _contacts.Max(c => c.Id) + 1 : 1;
            _contacts.Add(contact);
        }
    }
}
