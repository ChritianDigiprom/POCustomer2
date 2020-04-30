
using CsvHelper.Configuration;
namespace POCustomers

{
    public class PowerOfficeCust
    {
        public string firstname;
        public string lastname;
        public string username;
        public string middlename;
        public string disabled;
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
        //public string uniqueid;
        public string importuniquekey;
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
string disabled,
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
string importuniquekey, 
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
            this.disabled = disabled;
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
            this.importuniquekey = importuniquekey;
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

    public sealed class POCustomerMap :ClassMap<PowerOfficeCust>
    {
        public POCustomerMap()
        {

            Map(m => m.firstname).Name("firstname");
            Map(m => m.lastname).Name("lastname");
            Map(m => m.username).Name("username");
            Map(m => m.middlename).Name("middlename");
            Map(m => m.disabled).Name("disabled");
            Map(m => m.companyname).Name("companyname");
            Map(m => m.phone).Name("phone");
            Map(m => m.cell).Name("cell");
            Map(m => m.title).Name("title");
            Map(m => m.department).Name("department");
            Map(m => m.email).Name("email");
            Map(m => m.city).Name("city");
            Map(m => m.country).Name("country");
            Map(m => m.streetaddress).Name("streetaddress");
            Map(m => m.postalcode).Name("postalcode");
            Map(m => m.location).Name("location");
            Map(m => m.importuniquekey).Name("importuniquekey");
            Map(m => m.notes).Name("notes");
            Map(m => m.companyemail).Name("companyemail");
            Map(m => m.companyphone).Name("companyphone");
            Map(m => m.orgnumber).Name("orgnumber");
            Map(m => m.website).Name("website");
            Map(m => m.supportwebsite).Name("supportwebsite");
            Map(m => m.companynotes).Name("companynotes");
            Map(m => m.customernumber).Name("customernumber");

        }
    }
}


