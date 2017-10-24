using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StockVisionConsole.Models;

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
                    var rawdataresult = JsonConvert.DeserializeObject<List<FullContact>>(stringResult);
                    return rawdataresult;
                }
                else
                {
                    return rawdata;
                }
            }
        }
        
        
        public static async Task<ArticlesObj> Articles(string source)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://newsapi.org");
             
                var response = await client.GetAsync($"/v1/articles?source={source}&apiKey=74d96e5aa0a148fcb67abb16b935e4ff");
                var stringResult = await response.Content.ReadAsStringAsync();
                var rawdata = new ArticlesObj();
                if (response.IsSuccessStatusCode)
                {
                    var rawdataresult = JsonConvert.DeserializeObject <ArticlesObj>(stringResult);
                    return rawdataresult;
                }
                else
                {
                    return rawdata;
                }
            }
        }


        public void ProcessArticles(List<string> source)
        {
                foreach (var s in source)
                {
                    var aa = Articles(s);

                    foreach (var c in aa.Result.Article)
                    {
                   
                    }
                
                }
            
        }

        public void ProcessCompanies()
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

                    List<FullContact> kk = Tiker(c.Name).Result;

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