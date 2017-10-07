using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using StockVisionConsole.Migrations;
using StockVisionConsole.Models;

//
//    var data = GettingStarted.FromJson(jsonString);

namespace StockVisionConsole
{

    class Api
    {
        public static async Task<List<FullContact>> Tiker(string name)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.fullcontact.com");
                client.DefaultRequestHeaders.Add("X-FullContact-APIKey", "1e7565fbd5947b8e");
                var response = await client.GetAsync($"/v2/company/search.json?companyName={name}");


                var stringResult = await response.Content.ReadAsStringAsync();
                var rawdata = new List<FullContact>();
                if (response.IsSuccessStatusCode)
                {
//                var rawdata = new FullContact().JsonDeserialise(stringResult);
                    var rawdataresult = JsonConvert.DeserializeObject<List<FullContact>>(stringResult);
                    return rawdataresult;
                }
                else
                {
                    return rawdata;
                }
            }
        }

    }


    class Program
    {

        static void Main(string[] args)
        {

            using (var context = new EFCoreDemoContext())
            {
                var companies = context.Companies.Where(p => p.Updated.Equals(0)).Select(p => new Companies()
                {
                    Name = p.Name,
                    Symbol = p.Symbol,
                    City = p.City,
                    Country = p.Country
                }).ToList();


                foreach (var c in companies)
                {

                    List<FullContact> kk = Api.Tiker(c.Name).Result;

                    for (int i = 0; i < kk.Count; i++)
                    {
                        try
                        {
                            var company = new Company()
                            {
                                FullName = c.Name,
                                City = (kk[i].Location != null) ? kk[i].Location.Locality : "na",
                                Symbol = c.Symbol,
                                Name = kk[i].OrgName,
                                Country = (kk[i].Location != null) ? kk[i].Location.Country.Name : "na",
                                State = (kk[i].Location != null) ? kk[i].Location.Region.Name : "na",
                                Logo = kk[i].Logo
                            };
                            var update = context.Companies.FirstOrDefault(g => g.Symbol.Equals(c.Symbol));
                            update.Updated = 1;

                            context.Company.Add(company);
                            context.SaveChanges();
                        }
                        catch (NullReferenceException n)
                        {
                            continue;
                        }



                    }

                }

            }




        }
    }
}