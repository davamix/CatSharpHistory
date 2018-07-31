using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

using CatSharp.Data;
using CatSharp.Services;
using CatSharp.Services.Dtos;

namespace UnitTests.CatSharp.Services.CatServiceTests
{
    public class Save
    {
        [Fact]
        public void Save_writes_to_database()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<CatSharpContext>().UseSqlite(connection).Options;

                // Create the schema in the database
                using (var context = new CatSharpContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test
                using (var context = new CatSharpContext(options))
                {
                    var service = new CatService(context);
                    service.Save(new CatDto(1, "Cat 1", new DateTime(2018, 01, 01), null));
                }

                // Verify data
                using (var context = new CatSharpContext(options))
                {
                    Assert.Equal(1, context.Cats.Count());
                    Assert.Equal("Cat 1", context.Cats.Single().Name);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}