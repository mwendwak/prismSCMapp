using SQLite;
using com.kinetics.prism.DBstorage;
using System;

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

        public static bool  insertProduct(Product newProduct) //modify this to use base methods from BaseModel classes
        {
            bool recordCreated = false;
            newProduct.currDBConn.InsertAsync (newProduct);//fix how this can be inherited from the base Model class, instance issue
            return recordCreated;
        }

        public static Product createProduct() //modify this to use base methods from BaseModel classes
        {
            Product newProd = new Product();

            Random xitemCode = new Random();
            newProd.ItemCode = "X" + xitemCode.Next(1000,9999).ToString ();

            newProd.UOM = "Cases";
            newProd.ProdGroup = "SALES";
            newProd.Pack = "200ML";
            newProd.UnitPrice = 150.00M;
            newProd.InventGroup = "FP 500ML";
            newProd.Location = "SITEA";
            newProd.ItemTrackngID = "LOX01";
            return newProd;
        }
    }
}