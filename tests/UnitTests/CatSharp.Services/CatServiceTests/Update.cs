using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

using CatSharp.Services;
using CatSharp.Services.Extensions;
using CatSharp.Data;
using CatSharp.Data.Entities;
using CatSharp.Services.Dtos;

namespace UnitTests.CatSharp.Services.CatServiceTests
{
    public class Update
    {
        [Fact]
        public void Return_all_cats()
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

                // Insert seed data
                using (var context = new CatSharpContext(options))
                {
                    context.Cats.Add(new Cat() { Name = "Cat 1" });
                    context.SaveChanges();
                }

                // Run test
                using (var context = new CatSharpContext(options))
                {
                    // Get the cat created
                    var cat = context.Cats.AsNoTracking().Single(x => x.Name.Equals("Cat 1"));
                    // Simulate the return value as CatGetDto
                    var oldDto = cat.ToDto();
                    // Create the new CatUpdateDto with the date to be updated
                    var newDto = new CatUpdateDto(oldDto.Id, "Cat B", oldDto.BirthDate, oldDto.Weights);
                    // Update
                    var service = new CatService(context);
                    service.Update(newDto);
                }

                // Verify data
                using (var context = new CatSharpContext(options))
                {
                    Assert.True(context.Cats.Any(x => x.Name.Equals("Cat B")));
                    Assert.False(context.Cats.Any(x => x.Name.Equals("Cat 1")));
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}