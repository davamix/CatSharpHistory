using System;
using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

using CatSharp.Data;

namespace UnitTests.CatSharp.Services.CatServiceTests
{

    public interface IServiceTest
    {
        IServiceTest Start();
        IServiceTest SeedData();
        IServiceTest Execute();
        IServiceTest Verify();
        void End();
    }

    public interface IServiceTest<TResult> : IServiceTest
    {
        TResult Result { get; set; }
    }

    public abstract class ServiceTestABase<TResult> : IServiceTest<TResult>
    {
        public TResult Result { get; set; }

        protected DbContextOptions<CatSharpContext> Options { get; private set; }
        protected SqliteConnection Connection { get; private set; }

        public virtual IServiceTest Start()
        {
            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            Options = new DbContextOptionsBuilder<CatSharpContext>().UseSqlite(Connection).Options;

            // Create the schema in the database
            using (var context = new CatSharpContext(Options))
            {
                context.Database.EnsureCreated();
            }

            return this;
        }

        public virtual IServiceTest SeedData()
        {
            return this;
        }
        public virtual IServiceTest Execute()
        {
            return this;
        }
        public virtual IServiceTest Verify()
        {
            return this;
        }

        public virtual void End()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}