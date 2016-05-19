using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seceret_Sanata
{
    public partial class MainForm : Form
    {
        private List<Person> people;

        private Person selectedLink = null;
        private Person selectedSpouce = null;
        private String Username = null;
        private String UserEmail = null;


        public MainForm()
        {
            InitializeComponent();
            people = new List<Person>();
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            String newName = NameTextBox.Text;
            String newEmail = emailTextBox.Text;
            Person spouce = null;
            

            if (!string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(newEmail))
            {
                Person newPerson = new Person(newName, newEmail);
                
                NameTextBox.Text  = "";
                emailTextBox.Text = "";

                people.Add(newPerson);

                drawNameList();

                linkComboBox.DataSource = people.Select(x => x.Name).ToList();
                SpouseComboBox.DataSource = people.Select(x => x.Name).ToList();

            }
            else
            {
                MessageBox.Show("Error: Person feilds incomplete");
            }

        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            genSantaList();

            foreach(Person giver in people)
            {
                Console.WriteLine(giver.Name + " " + giver.recipcant.Name);
            }
        }


        private void sendEmail(String Message, Person DST, string password)
        {

            var fromAddress = new MailAddress("mrcwk@yahoo.com", "marc week");
            var toAddress = new MailAddress("marcustweek@gmail.com", "marc");

            const string subject = "Secret Santa";

            try {
                var smtp = new SmtpClient
                {
                    Host = "smtp.mail.yahoo.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, password)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = Message
                })
                {
                    smtp.Send(message);
                }
            }
            catch
            {
                MessageBox.Show("Error: could not connect to email");
            }
        }

        private void SpouseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSpouce = people[SpouseComboBox.SelectedIndex];
        }

        private void linkComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLink = people[linkComboBox.SelectedIndex];
        }


        private void genSantaList()
        {
            Random rand = new Random();
            int Size = people.Count;
            Boolean[] used = new bool[Size];
            for (int j = 0; j < Size; ++j) used[j] = false;

            for (int i = 0; i < Size; i++)
            {
                int gift;
               
                if (i == Size - 2 && used[Size - 1])
                {
                    //reset if you get to the end and are both spouces
                    i = 0;
                    for (int j = 0; j < Size; ++j) used[j] = false;
                }
                do
                {
                    gift = rand.Next() % Size;


                } while (!used[gift] || i == gift || people[i].Spouse == people[gift]);


                people[i].recipcant = people[gift];
                used[gift] = true;

            }
        }

        private void drawNameList()
        {
            peoplGridView.Rows.Clear();

            for(int i = 0; i < people.Count; ++i )
            {
                String spouceName = "";
                if (people[i].Spouse != null) spouceName = people[i].Spouse.Name;
                String[] row = { people[i].Name, people[i].Email, spouceName };
                peoplGridView.Rows.Add(row);

            }

            
        }

        private void linkButton_Click(object sender, EventArgs e)
        {
            Person person = selectedLink;
            Person spouce = selectedSpouce;

            if (person != null && spouce != null && person != spouce)
            {
                if (person.Spouse != null)
                    person.Spouse.Spouse = null;
                    
                if (spouce.Spouse != null)
                    spouce.Spouse.Spouse = null;
                person.Spouse = spouce;
                spouce.Spouse = person;
            }
            
           
            emailTextBox.Text = "";
            selectedLink = null;
            selectedSpouce = null;

            drawNameList();
        }

      
    }
}
