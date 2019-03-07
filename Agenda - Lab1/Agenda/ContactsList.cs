using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    [Serializable]
    class ContactsList
    {

        public List<Contact> contacts { get; set; }

        public ContactsList() { contacts = new List<Contact>(); }

        public void AddContact(Contact contact) { this.contacts.Add(contact); }

        public void RemoveContact(Contact contact) { this.contacts.Remove(contact); }

        public Contact SearchByEmail (String email) {
            return this.contacts.FirstOrDefault(item => item.Email.Equals(email));
        }

        public void ModifyContact (Contact contact)
        {
            int index = this.contacts.IndexOf(contact);
            this.contacts[index] = contact;
        }   

        public bool ExcludeContact(Contact contact)
        {
            return contacts.Remove(contact);
        }

    }
}
