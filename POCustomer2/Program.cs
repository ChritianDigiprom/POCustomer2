﻿using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoApi;
using GoApi.Core;
using GoApi.Party;
using CsvHelper;
using System.IO;


namespace POCustomers
{
    class Program
    {
        static void Main(string[] args)
        {
            //read config file
            string strApplicationKey;
            string strClientKey;
            string strDebug;
            string strOutFileName;
            string strOutDelimiter;
            string strMaxRecords;
            int intMaxRecords; 
        



            strApplicationKey = ConfigurationManager.AppSettings["applicationkey"];
            strClientKey = ConfigurationManager.AppSettings["clientkey"];
            strDebug = ConfigurationManager.AppSettings["debug"];
            strOutFileName = ConfigurationManager.AppSettings["outfilename"];
            strOutDelimiter = ConfigurationManager.AppSettings["outdelimiter"];
            strMaxRecords =  ConfigurationManager.AppSettings["maxrecords"];

            intMaxRecords = 50;
            if (!Int32.TryParse(strMaxRecords, out intMaxRecords))
            {
                intMaxRecords = 50;
            }

            


         

            try
            {
                var applicationkey = strApplicationKey; //"b2585956-025f-45a7-8ea4-b386144419b2";
                var clientkey = strClientKey; //"0e7dc82e-32f1-4a02-9f49-a5dce055f5b8";

                GoApi.Global.Settings.Mode = GoApi.Global.Settings.EndPointMode.Demo;
                var authorizationSettings = new AuthorizationSettings
                {

                    ApplicationKey = applicationkey,
                    ClientKey = clientkey,
                    TokenStore = new BasicTokenStore(@"my.tokenstore")
                };

                var authorization = new Authorization(authorizationSettings);
                var api = new Go(authorization);
                //Authorization.CreateAsync (authorization,authorizationSettings, )
                
                //Console.WriteLine("Getting customers starting with A. Max 50");

                var customers = api.Customer.Get()
                //.Where(c => c.Name.StartsWith("A"))
                .Where(c => c.IsPerson == false)
                .Skip(0)
                .Take(50);

                // Create list of Customers class instances 
                var records = new List<PowerOfficeCust>
                {
                };

                foreach (var customer1 in customers)
                {

                    var lstAddress = customer1.StreetAddress;
                    var contactFirstName = "";
                    var contactLastName = "";
                    var contactUserName = "Ukjent";
                    var contactPhoneNumber = "";
                    var contactEmailAddress = "";

                    if (true)
                    {
                        /* Console.WriteLine("1 C Firstname: " + contactFirstName);
                        Console.WriteLine("2 C Lastname: " + contactLastName);
                        Console.WriteLine("3 C Username: " + contactEmailAddress);
                        Console.WriteLine("4 Middlename : " + "");
                        Console.WriteLine("5 CompanyName: " + customer1.Name);
                        Console.WriteLine("6 C PhoneNumber: " + contactPhoneNumber);
                        Console.WriteLine("7 Cell : " + "");
                        Console.WriteLine("8 Title : " + "");
                        Console.WriteLine("9 Department : " + "");                  
                        Console.WriteLine("10 C Email: " + contactEmailAddress);
                        Console.WriteLine("11 City : " + lstAddress.City);
                        Console.WriteLine("12 Country " + lstAddress.CountryCode);
                        Console.WriteLine("13 Adresse 1: " + lstAddress.Address1);
                        //Console.WriteLine("Adresse 2: " + lstAddress.Address2);
                        Console.WriteLine("14 Postal Code: " + lstAddress.ZipCode);
                        Console.WriteLine("15 locaton : " + "");
                        Console.WriteLine("16 id: " + customer1.Id);
                        Console.WriteLine("17 Notes : " + "");
                        Console.WriteLine("18 CompanyEmail: " + customer1.EmailAddress);
                        Console.WriteLine("19 CompanyPhone: " + customer1.PhoneNumber);
                        Console.WriteLine("20 OrgNumber: " + customer1.VatNumber);
                        Console.WriteLine("21 website : " + "");
                        Console.WriteLine("22 suppportwebsite : " + "");
                        Console.WriteLine("23 CompanyNotes : " + "");
                        Console.WriteLine("24 CustomerNumber: " + customer1.Code);
                        Console.WriteLine("-----------------------------------------------------------------------");
                        */
                    }


                    //Get all contacts on current customer record
                    var contacts = api.Customer.ContactPerson.Get(customer1);

                    //Create class instance of customer records, one for each contact on customer
                    foreach (var contact in contacts)
                    {
                        //contactFirstName = contact.FirstName;
                        //contactLastName = contact.LastName;
                        //contactPhoneNumber = contact.PhoneNumber;
                        //contactEmailAddress = contact.EmailAddress;
                        //contactUserName = contactEmailAddress;

                        // Construct class instance of customer record
                        PowerOfficeCust loopCust = new PowerOfficeCust(
                            contact.FirstName,
                            contact.LastName,
                            contact.EmailAddress,
                            "", //middlename
                            customer1.Name,
                            contact.PhoneNumber,
                            "", //cell
                            "",//title
                            "", //department
                            contactEmailAddress,
                            lstAddress.City,
                            lstAddress.CountryCode,
                            lstAddress.Address1,
                            lstAddress.ZipCode,
                            "",//location
                            customer1.Id.ToString(),
                            "", //notes
                            customer1.EmailAddress,
                            customer1.PhoneNumber,
                            customer1.VatNumber,
                            "",
                            "",
                            "",
                            customer1.Code.ToString());

                        // add customer record to list of records 
                        records.Add(loopCust);
                    }
                }

                // Now write all records to text file
                using (StreamWriter sw = new StreamWriter(@"C:\test\testpo.csv", false, Encoding.UTF8))
                {

                    var writer = new CsvWriter(sw);
                    writer.Configuration.ShouldQuote = (field, context) => true;

                    //writer.Configuration.QuoteAllFields = true;
                    writer.WriteRecords(records);
                    writer.Flush();
                }

                Console.WriteLine("Done");
            }
            catch (ApiException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            //Wait for userinput
            Console.WriteLine("\n\nPress any key ...");
            Console.ReadKey();
        }
    }
}