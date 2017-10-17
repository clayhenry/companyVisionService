using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using StockVisionConsole.Migrations;

//
//    var data = GettingStarted.FromJson(jsonString);

namespace StockVisionConsole
{


    class Program
    {

        static void Main(string[] args)
        {
           
//            (new Api()).ProcessCompanies(); 
           (new Api()).ProcessArticles(new List<string>()
           {
               "bloomberg",
               "business-insider",
               "financial-times", 
               "the-wall-street-journal",
               "the-economist",
               "techcrunch",
               "fortune"
           });
        }
    }
}