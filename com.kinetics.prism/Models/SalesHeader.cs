using Android.Util;
using com.kinetics.prism.DBstorage;
using com.kinetics.prism.Models.JsonObjs;
using com.kinetics.prism.RepoUtil;
using Java.Util;
using SQLite;
using System;
using System.Collections.Generic;

namespace com.kinetics.prism.Models
{
    [Table("SalesHeader")]
    public class SalesHeader : BaseModel
    {
        [PrimaryKey, Column("DocNo")]
        public string DocNo { get; set; }
        [Column("DocType")]
        public int DocType { get; set; }
        [Column("Customer")]
        public string Customer { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("ExternalDoc")]
        public string ExternalDoc { get; set; }
        [Column("VATType")]
        public string VATType { get; set; }
        [Column("OrderAmt")]
        public decimal OrderAmt { get; set; }
        [Column("DiscountPerc")]
        public decimal DiscountPerc { get; set; }
        [Column("DiscountAmt")]
        public decimal DiscountAmt { get; set; }
        [Column("PaidAmt")]
        public decimal PaidAmt { get; set; }
        [Column("Balance")]
        public decimal Balance { get; set; }
        [Column("OrderDate")]
        public DateTime OrderDate { get; set; }
        [Column("RecSynced")]
        public int RecSynced { get; set; }

        public SalesHeader()
        {
            RecSynced = 0; //default the synced property to false on creating a new record
        }
        public bool insertSalesHeaderList(List<SalesHeader> newSalesHeader) //modify this to use base methods from BaseModel classes ?? do we make this static
        {
            bool recordCreated = false;
            SalesHeader tempSalesHeader = new SalesHeader();
            string tag = "SalesHeadersTSQL: ";
            try
            {
                lock (locker)
                {
                    tempSalesHeader.currDBConn.InsertAllAsync(newSalesHeader);                                         
                }
                Log.Info(tag, "Created " + newSalesHeader.Count.ToString () + " SalesHeaders");
            }
            catch (SQLiteException sqlEx)
            {
                Log.Error(tag, "Failure in creating a SalesHeader " + sqlEx.Message);
            }

            return recordCreated;
        }
        public bool insertSalesHeaderSingle(SalesHeader newSalesHeader) //modify this to use base methods from BaseModel classes ?? do we make this static
        {
            bool recordCreated = false;
            SalesHeader tempSalesHeader = new SalesHeader();
            string tag = "SalesHeadersTSQL: ";
            try
            {
                lock (locker)
                {
                    newSalesHeader.currDBConn.InsertAsync(newSalesHeader);
                }
                Log.Info(tag, "Created SalesHeader " + newSalesHeader.DocNo);
            }
            catch (SQLiteException sqlEx)
            {
                Log.Error(tag, "Failure in creating a SalesHeader " + sqlEx.Message);
            }

            return recordCreated;
        }
        public static SalesHeader genSalesHeaders(SalesHeader newHeader) //modify this to use base methods from BaseModel classes ?? do we make this static
        {
            string tag = "Package Order: ";
            var db = new SQLiteConnection(DatabaseHelper.getDbPath());
            double fakerDelay = 5;
            try
            {
                System.Random xDocNo = new System.Random();
                newHeader.DocNo         = "X" + xDocNo.Next(1000, 9999).ToString();
                newHeader.DocType       = 0;
                List <Customer> randCustomers = db.Query<Customer>("SELECT * FROM CUSTOMERS ORDER BY RANDOM () LIMIT 1");
                foreach (Customer s in randCustomers)
                {
                    newHeader.Customer = s.CustomerID;
                }
                newHeader.Description   = "Demo Order " + newHeader.DocNo.ToString ();
                newHeader.ExternalDoc   = "ED-"+xDocNo.Next(15550,98655).ToString ();
                newHeader.VATType       = "VAT16";
                newHeader.OrderAmt      = xDocNo.Next(150000, 285000);
                newHeader.DiscountPerc  = 0;
                newHeader.DiscountAmt   = 0;
                newHeader.PaidAmt       = 0;
                newHeader.Balance       = newHeader.OrderAmt;
                newHeader.OrderDate     = DateTime.Now.AddMinutes (fakerDelay) ;
                Log.Info(tag, "Packaged SalesOrder " + newHeader.DocNo);
            }
            catch (Exception ex)
            {
                Log.Error(tag, "Failure in Packaging SalesOrder " + ex.Message);
            }
            return newHeader;
        }

        public JsonSOrder CreateOrdeToJson(SalesHeader Order)
        {
            JsonSOrder orderDoc = new JsonSOrder();
            //do some default stuff if necessary ****CAN WE CHANGE THIS TO BE DONE BY REFLECTION
            orderDoc.DocNo          =   Order.DocNo          ;
            orderDoc.DocType        =   Order.DocType        ;
            orderDoc.Customer       =   Order.Customer       ;
            orderDoc.Description    =   Order.Description    ;
            orderDoc.ExternalDoc    =   Order.ExternalDoc    ;
            orderDoc.VATType        =   Order.VATType        ;
            orderDoc.OrderAmt       =   Order.OrderAmt       ;
            orderDoc.DiscountPerc   =   Order.DiscountPerc   ;
            orderDoc.DiscountAmt    =   Order.DiscountAmt    ;
            orderDoc.PaidAmt        =   Order.PaidAmt        ;
            orderDoc.Balance        =   Order.Balance        ;
            orderDoc.OrderDate      =   Order.OrderDate;
            return orderDoc;
        }

        public static List<SalesHeader> getSalesHeaders(int DocType)
        {
            string tag = "GETORDERS";
            var db = new SQLiteConnection(DatabaseHelper.getDbPath());
            var SalesHeadersVar = db.Query<SalesHeader>("SELECT * FROM SalesHeader WHERE DocType = ? ORDER BY OrderDate DESC",DocType);

            if (SalesHeadersVar != null) {
                int orderCounter = 0;
                List<SalesHeader> SalesHeaders = new List<SalesHeader>();
                try
                {
                    lock (locker)
                    {
                        foreach (var item in SalesHeadersVar)
                        {
                            SalesHeaders.Add(item);
                            orderCounter += 1;
                        }
                    }
                } catch (Exception sqlEx) {
                    Log.Error(tag, "SalesHeaders Packing Fail: " + sqlEx.Message);
                }
                return SalesHeaders;
            }
            return new List<SalesHeader> ();
        }

    }
}