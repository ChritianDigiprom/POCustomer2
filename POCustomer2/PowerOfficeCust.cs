namespace POCustomers
{
    public class PowerOfficeCust
    {
        public string firstname;
        public string lastname;
        public string username;
        public string middlename;
        public string companyname;
        public string phone;
        public string cell;
        public string title;
        public string department;
        public string email;
        public string city;
        public string country;
        public string streetaddress;
        public string postalcode;
        public string location;
        public string uniqueid;
        public string notes;
        public string companyemail;
        public string companyphone;
        public string orgnumber;
        public string website;
        public string supportwebsite;
        public string companynotes;
        public string customernumber;

        public PowerOfficeCust(
string firstName,
string lastName,
string username, 
string middlename,
string name,
string phoneNumber1,
string cell,
string title,
string department,
string contactEmailAddress,
string city,
string country,
string address1,
string zipCode,
string location,
string uniqueid, 
string notes,
string emailAddress2,
string phoneNumber2,
string vatNumber,
string website,
string supportwebsite,
string companynotes,
string customernumber)

        {
            this.firstname = firstName;
            this.lastname = lastName;
            this.username = username;
            this.middlename = middlename;
            this.companyname = name;
            this.phone = phoneNumber1;
            this.cell = cell;
            this.title = title;
            this.department = department;
            this.email = contactEmailAddress;
            this.city = city;
            this.country = country;
            this.streetaddress = address1;
            this.postalcode = zipCode;
            this.location = location;
            this.uniqueid = uniqueid;
            this.notes = notes;
            this.companyemail = emailAddress2;
            this.companyphone = phoneNumber2;
            this.orgnumber = vatNumber;
            this.website = website;
            this.supportwebsite = supportwebsite;
            this.companynotes = companynotes;
            this.customernumber = customernumber;
           
        }
    }
}