using Android.Util;
using com.kinetics.prism.DBstorage;
using com.kinetics.prism.Models.JsonObjs;
using com.kinetics.prism.RepoUtil;
using SQLite;
using System;
using System.Collections.Generic;


namespace com.kinetics.prism.Models
{
    [Table("Customers")]
    class Customer : BaseModel
    {
        [PrimaryKey, Column("CustomerID")]
        public string CustomerID { get; set; }
        [Column("CustomerNames")]
        public string CustomerNames { get; set; }
        [Column("CustomerBusGroup")]
        public string CustomerBusGroup { get; set; }
        [Column("RouteSalesArea")]
        public string RouteSalesArea { get; set; }
        [Column("PINNo")]
        public string PINNo { get; set; }
        [Column("CustomerPhoneNo")]
        public string CustomerPhoneNo { get; set; }
        [Column("PostingGroup")]
        public string PostingGroup { get; set; }
        [Column("VATGroup")]
        public string VATGroup { get; set; }
        [Column("CreditLimit")]
        public decimal CreditLimit { get; set; }
        [Column("Address")]
        public string Address { get; set; }

        public bool insertCustomer(Customer newCustomer) //modify this to use base methods from BaseModel classes ?? do we make this static
        {
            bool recordCreated = false;
            string tag = "CustomersTSQL: ";
            try
            {
                lock (locker)
                {
                    newCustomer.currDBConn.InsertAsync(newCustomer);//fix how this can be inherited from the base Model class, instance issue
                }
                Log.Info(tag, "Created a Customer " + newCustomer.CustomerID);
            }
            catch (SQLiteException sqlEx)
            {
                Log.Error(tag, "Failure in creating a Customer " + sqlEx.Message);
            }

            return recordCreated;
        }

        public List<Customer> getAllNavCustomers()
        {
            List<Customer> NavCustomers = new List<Customer>();

            return NavCustomers;
        }

        public Customer CreateCustFromJson(JsonCustomer Cust)
        {
            Customer custHolder = new Customer();
            //do some default stuff if necessary ****CAN WE CHANGE THIS TO BE DONE BY REFLECTION
            custHolder.CustomerID = Cust.CustomerID;
            custHolder.CustomerNames = PriscmUtil.formatNameToUpper(Cust.CustomerNames);
            custHolder.CustomerBusGroup = Cust.CustomerBusGroup;
            custHolder.RouteSalesArea = PriscmUtil.formatNameToUpper(Cust.RouteSalesArea);
            custHolder.PINNo = Cust.PINNo;
            custHolder.CustomerPhoneNo = Cust.CustomerPhoneNo;
            custHolder.PostingGroup = Cust.PostingGroup;
            custHolder.VATGroup = Cust.VATGroup;
            custHolder.CreditLimit = Cust.CreditLimit;
            custHolder.Address = Cust.Address;
            return custHolder;
        }

        public static Customer[] getCustomers()
        {
            string tag = "GETCUSTS";
            var db = new SQLiteConnection(DatabaseHelper.getDbPath());

            var customersVar = db.Table<Customer>();
            int NoOfCusts = customersVar.Count();
            int custCounter = 0;

            Customer[] customers = new Customer[NoOfCusts];
            try
            {
                lock (locker)
                {
                    foreach (var customer in customersVar)
                    {
                        customers[custCounter] = customer;
                        custCounter += 1;
                    }
                }
            }
            catch (Exception sqlEx)
            {
                Log.Error(tag, "Customers Packing Fail: " + sqlEx.Message);
            }

            return customers;
        }

        public decimal getCustomerBalance()
        {
            Random randQty = new Random();
            decimal custBalance = randQty.Next(100, 999);

            return custBalance;
        }

    }
}