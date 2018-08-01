using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

using CatSharp.Services;
using CatSharp.Services.Dtos.Extensions;
using CatSharp.Data;
using CatSharp.Data.Entities;
using CatSharp.Services.Dtos;

namespace UnitTests.CatSharp.Services.CatServiceTests
{
    public class Update : ServiceTestBase<object>
    {
        [Fact]
        public void Update_cat_name()
        {
            base.Start().SeedData(SeedData).Execute(Execute).Verify(Verify).End();
        }

        private IServiceTest SeedData()
        {
            using (var context = new CatSharpContext(base.Options))
            {
                context.Cats.Add(new Cat() { Name = "Cat 1" });
                context.SaveChanges();
            }

            return this;
        }

        private IServiceTest Execute()
        {
            using (var context = new CatSharpContext(base.Options))
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

            return this;
        }

        private IServiceTest Verify()
        {
            using (var context = new CatSharpContext(base.Options))
            {
                Assert.True(context.Cats.Any(x => x.Name.Equals("Cat B")));
                Assert.False(context.Cats.Any(x => x.Name.Equals("Cat 1")));
            }

            return this;
        }
    }
}