using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace StockVisionConsole
{
    public class FullContact
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("lookupDomain")]
        public string LookupDomain { get; set; }

        [JsonProperty("companyApiLink")]
        public string CompanyApiLink { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("orgName")]
        public string OrgName { get; set; }


        public IEnumerable JsonDeserialise(string result)
        {
           return  JsonConvert.DeserializeObject<List<FullContact>>(result);
        }
    }

    public class Location
    {
        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("region")]
        public Country Region { get; set; }
    }

    public  class Country
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }


    
    
}