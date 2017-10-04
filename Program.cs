using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using StockVisionConsole.Migrations;
using StockVisionConsole.Models;

namespace StockVisionConsole
{
    
    
    class Api
    {   
        public static async Task<IEnumerable> Tiker(string name)
        {

            using (var client = new HttpClient())
            {
                    client.BaseAddress = new Uri("https://api.fullcontact.com");
                    client.DefaultRequestHeaders.Add("X-FullContact-APIKey", "1e7565fbd5947b8e");
                    var response = await client.GetAsync($"/v2/company/search.json?companyName={name}");
                    response.EnsureSuccessStatusCode();
                if (response.StatusCode.Equals(404))
                {
                }
                var stringResult = await response.Content.ReadAsStringAsync();
                    var rawdata = JsonConvert.DeserializeObject<List<FullContact>>(stringResult);
                    return rawdata;

            }
        } 
        
    }
    
    
    class Program
    {
              
        static void Main(string[] args)
        {
            
            using (var context = new EFCoreDemoContext())
            {
                var company = context.Companies.Select(p => new Companies(){ Name = p.Name, Symbol = p.Symbol});

                foreach (var c in company)
                {
                    Console.WriteLine(c.Symbol); 
                }
                
            }
            

//            Api.Tiker("dsfsfdsfds").Wait();

        }
    } 
}