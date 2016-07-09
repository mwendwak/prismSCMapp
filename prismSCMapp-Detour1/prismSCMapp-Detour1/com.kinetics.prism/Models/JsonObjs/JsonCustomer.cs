using Newtonsoft.Json;
using System;

namespace com.kinetics.prism.Models.JsonObjs
{
    //MAPS DIRECTLY TO THE JSON OBJECT THAT IS RETURNED FROM THE SOURCE WEB URL - MATCH THESE TWO ALWAYS!!
    [Serializable]
    [JsonObject]
    public class JsonCustomer
    {
        public string CustomerID { get; set; }
        public string CustomerNames { get; set; }
        public string CustomerBusGroup { get; set; }
        public string RouteSalesArea { get; set; }
        public string PINNo { get; set; }
        public string CustomerPhoneNo { get; set; }
        public string PostingGroup { get; set; }
        public string VATGroup { get; set; }
        public decimal CreditLimit { get; set; }
        public string Address { get; set; }
    }
}