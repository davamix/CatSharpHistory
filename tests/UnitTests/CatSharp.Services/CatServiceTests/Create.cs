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
    public class Create : ServiceTestBase<object>
    {
        [Fact]
        public void Create_a_new_cat()
        {
            base.Start().Execute().Verify().End();
        }

        public override IServiceTest Execute()
        {
            using (var context = new CatSharpContext(base.Options))
            {
                var service = new CatService(context);
                service.Create(new CatCreateDto("Cat 1", new DateTime(2018, 01, 01), null));
            }

            return this;
        }

        public override IServiceTest Verify()
        {
            using (var context = new CatSharpContext(base.Options))
            {
                Assert.Equal(1, context.Cats.Count());
                Assert.Equal("Cat 1", context.Cats.Single().Name);
            }

            return this;
        }
    }
}