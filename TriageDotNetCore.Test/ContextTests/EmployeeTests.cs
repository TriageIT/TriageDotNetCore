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
        public EmployeeTests(EmployeeDbContext DbContext)
        {
            _db = DbContext;
            CleanDatabase();
        }

        private EmployeeDbContext _db;

        public void Dispose()
        {
            CleanDatabase();
            _db.Dispose();
        }
        private void CleanDatabase()
        {
            _db.Database.ExecuteSqlCommand("Delete van Employee");
        }

        [Fact]
        public void FirstTest()
        {
            Assert.True(true);
        }
    }
}
