using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

using CatSharp.Services;
using CatSharp.Services.Dtos;
using CatSharp.Data;
using CatSharp.Data.Entities;


namespace UnitTests.CatSharp.Services.CatServiceTests
{
    public class GetAll : ServiceTestBase<IList<CatGetDto>>
    {
        [Fact]
        public void Return_all_cats()
        {
            base.Start().SeedData().Execute().Verify().End();
        }

        public override IServiceTest SeedData()
        {
            using (var context = new CatSharpContext(base.Options))
            {
                context.Cats.Add(new Cat() { Name = "Cat 1" });
                context.Cats.Add(new Cat() { Name = "Cat 2" });
                context.Cats.Add(new Cat() { Name = "Cat 3" });
                context.SaveChanges();
            }

            return this;
        }

        public override IServiceTest Execute()
        {
            using (var context = new CatSharpContext(base.Options))
            {
                var service = new CatService(context);
                base.Result = service.GetAll();
            }

            return this;
        }

        public override IServiceTest Verify()
        {
            Assert.Equal(3, base.Result.Count());

            return this;
        }
    }

}