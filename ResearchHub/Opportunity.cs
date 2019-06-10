using System;
using System.Globalization;
using System.Net.Mail;

namespace ResearchHub
{
    public class Opportunity : IComparable
    {
        string[] temp;
        string title;
        string[] areas;
        string description;
        string[] requirements;
        string timeCommitment;
        string compensation;
        string nameOfContact;
        string emailAddress;
        string materials;
        DateTime expirationDate;

        public Opportunity(string[] args)
        {
            temp = args;
            // title field set
            title = args[1];
            // area field set
            areas = new string[3];
            areas[0] = args[2];
            areas[1] = args[3];
            areas[2] = args[4];
            // description field set
            description = args[5];
            // requirements field set
            requirements = new string[4];
            requirements[0] = args[6];
            requirements[1] = args[7];
            requirements[2] = args[8];
            requirements[3] = args[9];
            // timeCommitment field set
            timeCommitment = args[10];
            // compensation field set
            compensation = args[11];
            // expirationDate field set
            expirationDate = DateTime.Parse(args[12]);
            // nameOfContact field set
            nameOfContact = args[13];
            // emailAddress field set
            emailAddress = args[14];
            // materials field set
            materials = args[15];
            
        }

        public void mail(String address)
        {
            MailAddress from = new MailAddress(address);
            MailAddress to = new MailAddress(address);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Research Opportunity: " + title;
            message.Body = "Title: " + title
                + "\nDescription: " + description
                + "\nRequirements: ";
            foreach (string require in requirements)
            {
                if (require.Length > 0) message.Body += "\n\t" + require;
            }
            message.Body += "\nCommitment: " + timeCommitment
                + "\nCompensation: " + compensation
                + "\nContact: " + nameOfContact + " " + emailAddress
                + "\nMaterials Required: " + materials
                + "\nApply By: " + expirationDate.ToString();

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateBccTestMessage(): {0}", ex.ToString());
            }
        }

        public string GetTitle() { return title; }

        public string[] getAreas() { return areas; }

        public string getDescription() { return description; }

        public string[] getRequirements() { return requirements; }

        public string getTimeCommitment() { return timeCommitment; }

        public string getCompemsation() { return compensation; }

        public string getNameOfContact() { return nameOfContact; }

        public string getEmailAddress() { return emailAddress; }

        public string getMaterials() { return materials; }

        public DateTime getExpirationDate() { return expirationDate; }

        public int CompareTo(object obj)
        {
            return expirationDate.CompareTo(obj);
        }
    }
}
