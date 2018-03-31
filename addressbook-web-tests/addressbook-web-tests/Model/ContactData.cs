using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData()
        {
        }
        /*
        private string middlename = "";
        private string nickname = "";
        private string photo = @"";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email1 = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private DateTime birthday;
        private DateTime anniversary;
        private List<string> group;
        private string address2 = "";
        private string home2 = "";
        private string notes = "";
        */

        private string allPhones;
        private string allEmails;

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "address")]
        public string  Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                    return allEmails;
                else
                    return CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3).Trim();
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                    return allPhones;
                else
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();

            }
            set
            {
                allPhones = value;
            }
        }

        public string AllPhonesWithPrefix
        {
            get
            {
                if (allPhones != null)
                    return allPhones;
                else
                    return SetPhonePrefix(DoLinefeed(HomePhone), 0) + SetPhonePrefix(DoLinefeed(MobilePhone), 1) + SetPhonePrefix(DoLinefeed(WorkPhone).Trim(), 2);

            }
            set
            {
                allPhones = value;
            }
        }
        private String DoLinefeed(string line)
        {
            if (line == null || line == "")
                return "";
            return line + "\r\n";
        }

        private string SetPhonePrefix(string phone, int index)
        {
            if (phone == null || phone == "")
                return "";
            else
            {
                if (index == 0) return "H: " + phone;
                if (index == 1) return "M: " + phone;
                if (index == 2) return "W: " + phone;
            }
            return "error";
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
                return "";
            return Regex.Replace(phone, "[-()]", "") + "\r\n";
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() + Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return Lastname + " " + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if(Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts where c.Deprecated == "0000-00-00 00:00:00" select c).ToList();
            }
        }
    }
}
