using System;
using Newtonsoft.Json;

namespace com.kinetics.prism.Models.JsonObjs
{
    //MAPS DIRECTLY TO THE JSON OBJECT THAT IS RETURNED FROM THE SOURCE WEB URL - MATCH THESE TWO ALWAYS!!
    [Serializable]
    [JsonObject]
    public class JsonSOrderLine
    {
        public int LineNo { get; set; }
        public string DocNo { get; set; }
        public int DocType { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }
        public string Item { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double DiscountAmt { get; set; }
        public double LineTotalAmt { get; set; }
        public double VATAmount { get; set; }
        public int RecSynced { get; set; }
    }
}
