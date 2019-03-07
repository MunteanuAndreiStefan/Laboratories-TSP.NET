using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Form1 : Form
    {
        String oldEmail = "";
        String path = @"C:\contacts.txt";

        ContactsList contactsList;
        public Form1()
        {
            InitializeComponent();
            Init();
            contactsList = new ContactsList();
        }

        public void Init()
        {
            //Eventos ONCLICK

            this.buttonClean.Click += new System.EventHandler(this.EmptyFields);
            this.buttonAdd.Click += new System.EventHandler(Add);
            this.buttonSearch.Click += new System.EventHandler(Search);
            //this.buttonShowList.Click += new System.EventHandler(ActualizeList);
            this.buttonRemove.Click += new System.EventHandler(Exclude);


        }

        public void EmptyFields(object e, EventArgs sender)
        {
            textBoxName.Text = "";
            textBoxEmail.Text = "";
            textBoxPhone.Text = "";

        }

        private void add(String name, String email, String phone, String age)
        {

            if (contactsList.SearchByEmail(email) != null)
            {
                MessageBox.Show("The email already exists!");
            }
            else if (!isNumeric(textBoxPhone.Text))
            {
                MessageBox.Show("The phone must be a number");
            }
            else if(!IsValidEmail(textBoxEmail.Text))
            {
                MessageBox.Show("The email must be a correct format!");
            }
            else if(!isName(textBoxName.Text))
            {
                MessageBox.Show("The name must be a correct format!");
            }
            else if (!isAge(textBoxAge.Text))
            {
                MessageBox.Show("The age must be a correct format!");
            }
            else
            {
                if (name == "" || email == "" || phone == "" || age =="")
                    MessageBox.Show("All fields are mandatory");
                else
                {
                    contactsList.AddContact(new Contact(name, email, phone, age));
                    actualizeList();
                }
            }
        }

        public void Add(object e, EventArgs sender)
        {
            add(this.textBoxName.Text, this.textBoxEmail.Text, this.textBoxPhone.Text, this.textBoxAge.Text);
        }

        private void searchByEmail(String email)
        {
            var x = this.contactsList.SearchByEmail(email);

            if (contactsList.SearchByEmail(email) != null)
            {
                textBoxEmail.Text = x.Email;
                textBoxName.Text = x.Name;
                textBoxPhone.Text = x.Number;
                textBoxAge.Text = x.Age;
            }
            else
                MessageBox.Show("The contact wasn't found!");

        }

        public void Search(object e, EventArgs sender)
        {
            searchByEmail(textBoxEmail.Text);
        }

        private void actualizeList() {
            listBoxOfContacts.Items.Clear();
            contactsList.contacts.ForEach(item => listBoxOfContacts.Items.Add(item.PrintContact()));
        }


        public void ActualizeList(object e, EventArgs sender)
        {
            actualizeList();
        }

        private void clearFields(){
            textBoxEmail.Text = "";
            textBoxName.Text = "";
            textBoxPhone.Text = "";
            textBoxAge.Text = "";
        }

        public void Exclude(object e, EventArgs sender)
        {
            if (textBoxEmail.Text == "")
                MessageBox.Show("Enter the email!");
            else
                removebyEmail(textBoxEmail.Text);
        }

        public void removebyEmail(String email) {
            if (this.contactsList.ExcludeContact(new Contact(email)))
            {
                MessageBox.Show("Deleted/Modified Successfully!");
            }
            else
                MessageBox.Show("Failed to Delete/Modify!");
            actualizeList();
        }


        public void SerializeContacts()
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream fsout = new FileStream("contacts.binary", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, contactsList.contacts);
                }
            }
            catch
            {
                MessageBox.Show("An error has occured");
            }


        }

        public void DeSerializeContacts()
        {

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fsin = new FileStream("contacts.binary", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    contactsList.contacts = (List<Contact>)bf.Deserialize(fsin);
                }
            }
            catch
            {
                MessageBox.Show("An error has occured");
            }
        }

        private void buttonSaveList_Click(object sender, EventArgs e)
        {
            SerializeContacts();
        }

        private void buttonLoadList_Click(object sender, EventArgs e)
        {
            DeSerializeContacts();
            actualizeList();
        }

        private void listBoxOfContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxOfContacts.SelectedItem != null)
            {
                string[] separatingChars = { " | " };
                String email = listBoxOfContacts.SelectedItem.ToString().Split(separatingChars, StringSplitOptions.RemoveEmptyEntries)[1];
                if (String.IsNullOrEmpty(email)) ;
                searchByEmail(email);
                oldEmail = email;
            }
        }

        Boolean IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        Boolean isNumeric(String str)
        {
            try
            {
                double d = int.Parse(str);
            }
            catch
            {
                return false;
            }
            return true;
        }

        Boolean isName(String str)
        {
            if (str.All(Char.IsLetter))
                return true;
            return false;
        }

        Boolean isAge(String str)
        {
            if (isNumeric(str))
                if (str.Length < 3)
                    return true;
            return false;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            removebyEmail(oldEmail);
            add(this.textBoxName.Text, this.textBoxEmail.Text, this.textBoxPhone.Text, this.textBoxAge.Text);
            clearFields();
        }
    }
}
