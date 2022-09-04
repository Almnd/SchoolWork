using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceLib;
using Microsoft.EntityFrameworkCore;

namespace WebService.Dbfunction
{
    public class StringSearch
    {/*
        UseEntityFramework(connectionString);

        private static void UseEntityFramework(connectionString)
        {
            var connectionString = "host=rawdata.ruc.dk;port=5432;db=raw12;uid=raw12;pwd=uWISa4yb";
            

            Console.WriteLine("Stringsearch db function");
            var ctx = new Raw12Context();

            //var result = ctx.SearchResults.FromSqlRaw("select * from search({0})", "%ab%");
            var result = ctx.SearchHistory.FromSqlInterpolated($"select * from string_search({"%ab%"})");

            foreach (var searchResult in result)
            {
                Console.WriteLine($"{searchResult.UserId}, {searchResult.Timestamp}, {searchResult.Keyword}");
            }

        }*/
    }
}
