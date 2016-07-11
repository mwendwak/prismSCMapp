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
    [Table("SalesLine")]
    public class SalesLine : BaseModel
    {
        [PrimaryKey, Column("LineNo")]
        public int LineNo { get; set; }
        [Column("DocNo")]
        public string DocNo { get; set; }
        [Column("DocType")]
        public int DocType { get; set; }
        [Column("Customer")]
        public string Customer { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Item")]
        public string Item { get; set; }
        [Column("Quantity")]
        public double Quantity { get; set; }
        [Column("UnitPrice")]
        public double UnitPrice { get; set; }
        [Column("DiscountAmt")]
        public double DiscountAmt { get; set; }
        [Column("LineTotalAmt")]
        public double LineTotalAmt { get; set; }
        [Column("VATAmount")]
        public double VATAmount { get; set; }
        [Column("RecSynced")]
        public int RecSynced { get; set; }

        public SalesLine()
        {
            RecSynced = 0; //default the synced property to false on creating a new record
        }
        public bool insertSalesLineList(List<SalesLine> newSalesLine) //modify this to use base methods from BaseModel classes ?? do we make this static
        {
            bool recordCreated = false;
            SalesLine tempSalesLine = new SalesLine();
            string tag = "SalesLinesTSQL: ";
            try
            {
                lock (locker)
                {
                    tempSalesLine.currDBConn.InsertAllAsync(newSalesLine);                                         
                }
                Log.Info(tag, "Created " + newSalesLine.Count.ToString () + " SalesLines");
            }
            catch (SQLiteException sqlEx)
            {
                Log.Error(tag, "Failure in creating a SalesLine " + sqlEx.Message);
            }

            return recordCreated;
        }
        public bool insertSalesLineSingle(SalesLine newSalesLine) //modify this to use base methods from BaseModel classes ?? do we make this static
        {
            bool recordCreated = false;
            SalesLine tempSalesLine = new SalesLine();
            string tag = "SalesLinesTSQL: ";
            try
            {
                lock (locker)
                {
                    newSalesLine.currDBConn.InsertAsync(newSalesLine);
                }
                Log.Info(tag, "Created SalesLine " + newSalesLine.DocNo);
            }
            catch (SQLiteException sqlEx)
            {
                Log.Error(tag, "Failure in creating a SalesLine " + sqlEx.Message);
            }

            return recordCreated;
        }
        public static List<SalesLine> genSalesLines() //modify this to use base methods from BaseModel classes ?? do we make this static
        {
            string tag = "Package Order Lines: ";
            List<SalesLine> salesLines = new List<SalesLine>();
            var db = new SQLiteConnection(DatabaseHelper.getDbPath());
            try
            {
                System.Random xDocNo = new System.Random();
                List <SalesHeader> SalesOrders = db.Query<SalesHeader>("SELECT * FROM SALESHEADER");
                double vatRate = 0.16;
                for (int x =1; x <=10; x++)
                {
                    SalesLine newOrderLine = new SalesLine();
                    newOrderLine.LineNo = xDocNo.Next(1000, 9999);
                    newOrderLine.DocNo = "X002";
                    newOrderLine.DocType = 0;
                    newOrderLine.Customer = "CKO0OR";
                    newOrderLine.Description = "Dummy Line " + newOrderLine.LineNo.ToString();
                    newOrderLine.Item = "PR0902";
                    newOrderLine.Quantity       = xDocNo.Next(100, 300);
                    newOrderLine.UnitPrice      = xDocNo.Next(210, 240);
                    newOrderLine.LineTotalAmt = newOrderLine.Quantity * newOrderLine.UnitPrice;
                    newOrderLine.DiscountAmt = 0;
                    newOrderLine.VATAmount = vatRate * newOrderLine.LineTotalAmt;
                    salesLines.Add(newOrderLine);
                }
                Log.Info(tag, "Packaged SalesOrder Line ");
            }
            catch (Exception ex)
            {
                Log.Error(tag, "Failure in Packaging SalesOrder Lines " + ex.Message);
            }
            return salesLines;
        }

        public JsonSOrderLine CreateOrderLineToJson(SalesLine OrdLine)
        {
            JsonSOrderLine orderDocLine = new JsonSOrderLine();
            //do some default stuff if necessary ****CAN WE CHANGE THIS TO BE DONE BY REFLECTION          
            orderDocLine.LineNo            =    OrdLine.LineNo            ;   
            orderDocLine.DocNo             =    OrdLine.DocNo             ;
            orderDocLine.DocType           =    OrdLine.DocType           ;
            orderDocLine.Customer          =    OrdLine.Customer          ;
            orderDocLine.Description       =    OrdLine.Description       ;
            orderDocLine.Item              =    OrdLine.Item              ;
            orderDocLine.Quantity          =    OrdLine.Quantity          ;
            orderDocLine.UnitPrice         =    OrdLine.UnitPrice         ;
            orderDocLine.DiscountAmt       =    OrdLine.DiscountAmt       ;
            orderDocLine.LineTotalAmt      =    OrdLine.LineTotalAmt      ;
            orderDocLine.VATAmount         =    OrdLine.VATAmount         ;
            orderDocLine.RecSynced         = OrdLine.RecSynced;

            return orderDocLine;
        }

        public static List<SalesLine> getSalesLines(int DocType, string DocNo)
        {
            string tag = "GETORDERLINES";
            var db = new SQLiteConnection(DatabaseHelper.getDbPath());
            var SalesLinesVar = db.Query<SalesLine>("SELECT * FROM SalesLine WHERE DocType = ? AND DocNo = ? ORDER BY LineNo DESC",DocType,DocNo);

            if (SalesLinesVar != null) {
                int orderCounter = 0;
                List<SalesLine> SalesLines = new List<SalesLine>();
                try
                {
                    lock (locker)
                    {
                        foreach (var item in SalesLinesVar)
                        {
                            SalesLines.Add(item);
                            orderCounter += 1;
                        }
                    }
                } catch (Exception sqlEx) {
                    Log.Error(tag, "SalesLines Packing Fail: " + sqlEx.Message);
                }
                return SalesLines;
            }
            return new List<SalesLine> ();
        }

    }
}