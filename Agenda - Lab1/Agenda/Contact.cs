using System;

namespace Agenda
{
    [Serializable]
    class Contact
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }

        public Contact(string name, string email, string number, string age)
        {

            this.Name = name;
            this.Number = number;
            this.Email = email;
            this.Age = age;
        }

        public Contact() : this("", "", "", "")
        { }

        public Contact(string email)
        {
            this.Email = email;
        }

        public override bool Equals(object obj)
        {
            Contact c = (Contact)obj;
            return this.Email.Equals(c.Email);
        }

        public string PrintContact()
        {
            return this.Name + " | " + this.Email + " | " +  this.Number + " | " + this.Age;
        }

    }
}
