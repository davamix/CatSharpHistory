using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

using CatSharp.Services;
using CatSharp.Data;
using CatSharp.Data.Entities;


namespace UnitTests.CatSharp.Services.CatServiceTests
{
    public class GetAll
    {
        [Fact]
        public void Return_all_cats()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try{
                var options = new DbContextOptionsBuilder<CatSharpContext>().UseSqlite(connection).Options;

                // Create the schema in the database
                using (var context = new CatSharpContext(options)){
                    context.Database.EnsureCreated();
                }

                // Insert seed data
                using(var context = new CatSharpContext(options)){
                    context.Cats.Add(new Cat(){Name="Cat 1"});
                    context.Cats.Add(new Cat(){Name="Cat 2"});
                    context.Cats.Add(new Cat(){Name="Cat 3"});
                    context.SaveChanges();
                    
                }

                using (var context = new CatSharpContext(options)){
                    var service = new CatService(context);
                    var result = service.GetAll();

                    Assert.Equal(3, result.Count());
                }
            }finally{
                connection.Close();
            }
        }
    }
}