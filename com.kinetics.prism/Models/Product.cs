using SQLite;
using com.kinetics.prism.DBstorage;
using System;
using Android.Util;

namespace com.kinetics.prism.Models
{
    [Table("Products")]
    public class Product : BaseModel
    {
        [PrimaryKey , Column("ItemCode")]
        public string ItemCode { get; set; }
        [Column("UOM")]
        public string UOM { get; set; }
        [Column("ProdGroup")]
        public string ProdGroup { get; set; }
        [Column("Pack")]
        public string Pack { get; set; }
        [Column("UnitPrice")]
        public decimal UnitPrice { get; set; }
        [Column("InventGroup")]
        public string InventGroup { get; set; }
        [Column("Location")]
        public string Location { get; set; }
        [Column("ItemTrackingID")]
        public string ItemTrackngID { get; set; }

        public bool  insertProduct(Product newProduct) //modify this to use base methods from BaseModel classes ?? do we make this static
        {
            bool recordCreated = false;
            string tag = "ProductsTSQL: ";
            try
            {
                newProduct.currDBConn.InsertAsync(newProduct);//fix how this can be inherited from the base Model class, instance issue
                Log.Info(tag, "Created a Product " + newProduct.ItemCode);
            }
            catch (SQLiteException sqlEx)
            {
                Log.Error(tag, "Failure in creating a Product " + sqlEx.Message);
            }
            
            return recordCreated;
        }

        public Product updateItemDetails(Product newProd) //modify this to use base methods from BaseModel classes ?? do we make this static
        {
            string tag = "Package Item: ";
            try
            {
                Random xitemCode = new Random();
                newProd.ItemCode = "X" + xitemCode.Next(1000, 9999).ToString();

                newProd.UOM = "Cases";
                newProd.ProdGroup = "SALES";
                newProd.Pack = "200ML";
                newProd.UnitPrice = 150.00M;
                newProd.InventGroup = "FP 500ML";
                newProd.Location = "SITEA";
                newProd.ItemTrackngID = "LOX01";

                Log.Info(tag, "Packaged Item Data " + newProd.ItemCode);
            } catch (Exception ex)
            {
                Log.Error(tag, "Failure in Packaging Item Data " + ex.Message);
            }
            return newProd;
        }
    }
}