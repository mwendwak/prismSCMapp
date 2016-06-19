using System;
using Newtonsoft.Json;

namespace com.kinetics.prism.Models.JsonObjs
{
    //MAPS DIRECTLY TO THE JSON OBJECT THAT IS RETURNED FROM THE SOURCE WEB URL - MATCH THESE TWO ALWAYS!!
    [Serializable]
    [JsonObject]
    public class JsonProduct
    {
        public string Family { get; set; }
        public string InventGroup { get; set; }
        public string ItemTrackngID { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Pack { get; set; }
        public string ProdGroup { get; set; }
        public string ProductID { get; set; }
        public string UOM { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
