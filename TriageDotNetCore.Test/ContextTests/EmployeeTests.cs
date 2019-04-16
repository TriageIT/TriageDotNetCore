using System;
using System.Collections.Generic;
using System.Text;
using TriageDotNetCore;
using TriageDotNetCore.Models;
using TriageDotNetCore.Models.Db;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TriageDotNetCore.Test.ContextTests
{
    [Collection("TriageDotNetCore")]

    public class EmployeeTests : IDisposable
    {
        private EmployeeDbContext _db;

        public EmployeeTests()
        {
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _db = new EmployeeDbContext(options);
          
        }


        public void Dispose()
        {
           _db.Dispose();
        }
        private void CheckDbExistence()
        {
            _db.Database.EnsureCreated();
        }

        [Fact]
        public void FirstTest()
        {
            CheckDbExistence();
            Assert.True(true);
        }
    }
}
