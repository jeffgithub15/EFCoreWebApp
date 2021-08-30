using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EfTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task GetBooks()
        {
            var strings = new List<string> { "1", "2", "testing" };
            string joined = "";
            foreach (var item in strings)
            {
                joined += $"'' as {item},";
            }

            var a = joined.Substring(0, joined.Length - 1);

            const string connectionString = "Data Source=JEFFREYA-PC2;" +
                       "Database=EfCoreInActionDb2; Integrated Security=True;";
            var optionsBuilder = new DbContextOptionsBuilder<EfCoreContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var options = optionsBuilder.Options;

            using (var context = new EfCoreContext(options))
            {
               var result = await context.Books.ToListAsync();


                Assert.IsTrue(result.Count > 0);
            }
        }
    }
}
                                                                                                                                                      