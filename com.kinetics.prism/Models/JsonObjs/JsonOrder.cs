using System;
using Newtonsoft.Json;

namespace com.kinetics.prism.Models.JsonObjs
{
    //MAPS DIRECTLY TO THE JSON OBJECT THAT IS RETURNED FROM THE SOURCE WEB URL - MATCH THESE TWO ALWAYS!!
    [Serializable]
    [JsonObject]
    public class JsonSOrder
    {
        public string DocNo { get; set; }
        public int DocType { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }
        public string ExternalDoc { get; set; }
        public string VATType { get; set; }
        public decimal OrderAmt { get; set; }
        public decimal DiscountPerc { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal PaidAmt { get; set; }
        public decimal Balance { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
