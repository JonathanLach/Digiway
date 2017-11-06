using DigiwayDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DigiwayTest
{
    [TestClass]
    public class UnitTest1
    {
        CompanyContext _context;
        [TestInitialize]

        public void TestMethod1()
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            DbContextOptions options = builder.UseSqlServer(@"Data Source = vm-sql2.iesn.Be\Stu3ig; Initial Catalog=1718_etu31944_DB; User Id=1718_etu31944; Password=ReuVA9^75sw").Options;

            _context = new CompanyContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.EventCategories.Add(new EventCategory()
            {
                Name= "Foire aux livres"
            });
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task TestMethod()
        {
            EventCategory category = await _context.EventCategories.FirstAsync();
        }
    }
}
