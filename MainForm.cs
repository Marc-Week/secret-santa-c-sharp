using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private String Username = "";
        private String UserEmail = "";


        public MainForm()
        {
            InitializeComponent();
            people = openCSV();
            drawNameList();
            linkComboBox.DataSource = people.Select(x => x.Name).ToList();
            SpouseComboBox.DataSource = people.Select(x => x.Name).ToList();
            openEmail();
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
                Debug.WriteLine(giver.Name + " " + giver.recipcant.Name);
            }
        }


        private void sendEmail(String Message, Person DST, string password)
        {

            var fromAddress = new MailAddress(UserEmail, UserEmail);
            var toAddress = new MailAddress(DST.Email, DST.Name);

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
               
                if (i == Size - 2 && !used[Size - 1] && people[i].Spouse == people[i + 1])
                {
                    //reset if you get to the end and are both spouces and they are the only ones left
                    i = 0;
                    for (int j = 0; j < Size; ++j) used[j] = false;
                }
                do
                {
                    gift = rand.Next() % Size;


                } while (used[gift] || i == gift || people[i].Spouse == people[gift]);


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

        private void peoplGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO CONVERT TO SQLLITE?
            string CSV = "";
            foreach(Person p in people)
            {
                CSV += p.Name + "," + p.Email + Environment.NewLine;

            }
            CSV += "#" + Environment.NewLine;
            foreach (Person p in people)
            {
                if (p.Spouse != null)
                    CSV += people.IndexOf(p) + "," + people.IndexOf(p.Spouse) + Environment.NewLine;

            }
            try {
                FileStream file = new FileStream("sav.csv", FileMode.Create);
                file.Write(System.Text.Encoding.UTF8.GetBytes(CSV), 0, CSV.Length);
                file.Close();
            }
            catch (Exception d)
            {
                MessageBox.Show("Error: " + d);
            }
        }

        private List<Person> openCSV()
        {
            List<Person> savelist = new List<Person>();
            
            if(File.Exists("sav.csv"))
            {
                System.IO.StreamReader file = new System.IO.StreamReader("sav.csv");
                string line = file.ReadLine().TrimEnd(Environment.NewLine.ToCharArray());
                
                if (!string.IsNullOrEmpty(line)) line = line.TrimEnd(Environment.NewLine.ToCharArray());
                while (!string.IsNullOrEmpty(line) && line != "#") 
                {
                    String[] person = line.Split(',');
                    if (person.Length == 2 && !string.IsNullOrEmpty(person[0]) && !string.IsNullOrEmpty(person[1]))
                        savelist.Add(new Person(person[0], person[1]));

                    line = file.ReadLine();
                    if (!string.IsNullOrEmpty(line)) line = line.TrimEnd(Environment.NewLine.ToCharArray()); 
                }
                

                while (!file.EndOfStream &&  !string.IsNullOrEmpty(line)) 
                {
                    String[] link = line.Split(',');
                    int person, spouce;
                    if (link.Length == 2 && int.TryParse(link[0], out person) && int.TryParse(link[1], out spouce))
                        savelist[person].Spouse = savelist[spouce];
                        
                    line = file.ReadLine().TrimEnd(Environment.NewLine.ToCharArray());
                    if (!string.IsNullOrEmpty(line)) line = line.TrimEnd(Environment.NewLine.ToCharArray());

                }
                
                String[] link1 = line.Split(',');
                int person2, spouce2;
                if (link1.Length == 2 && int.TryParse(link1[0], out person2) && int.TryParse(link1[1], out spouce2))
                    savelist[person2].Spouse = savelist[spouce2];

                file.Close();
            }

            return savelist;
        }

        private void emailSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form emailform = new Form();
            
            emailform.Text = "Enter username and password";
            Label ulabel = new Label();
            ulabel.Text = "Username:";
            ulabel.Location = new Point(5, 5);
            TextBox username = new TextBox();
            username.Location = new Point(5, 30);
            Label elabel = new Label();
            elabel.Text = "Email:";
            elabel.Location = new Point(5, 55);

            TextBox email = new TextBox();
            email.Location = new Point(5, 80);

            Button button = new Button();
            button.Text = "Accept";
            button.Location = new Point(30, 105);
            button.Click += (o, i) =>
            {
                Username = username.Text;
                UserEmail = email.Text;
                usernametoolStripStatusLabel.Text = Username;
                emailtoolStripStatusLabel.Text = UserEmail;

                emailform.Dispose();
                saveEmail();
            };


            emailform.Size = new Size(90, 200);
            emailform.Controls.Add(ulabel);
            emailform.Controls.Add(elabel);
            emailform.Controls.Add(username);
            emailform.Controls.Add(email);
            emailform.Controls.Add(button);

            emailform.Show();

            


        }

        private void saveEmail()
        {
            string CSV = Username + "," + UserEmail;
            FileStream file = new FileStream("mail.csv", FileMode.Create);
            file.Write(System.Text.Encoding.UTF8.GetBytes(CSV), 0, CSV.Length);
            file.Close();
        }
        private void openEmail()
        {
            if (File.Exists("mail.csv"))
            {
                System.IO.StreamReader file = new System.IO.StreamReader("mail.csv");
                string line = file.ReadLine().TrimEnd(Environment.NewLine.ToCharArray());
                file.Close();
                string[] info = line.Split(',');
                if (info.Length == 2)
                {
                    Username = info[0];
                    UserEmail = info[1];
                    usernametoolStripStatusLabel.Text = Username;
                    emailtoolStripStatusLabel.Text = UserEmail;
                }
            }
        }
    }
}
