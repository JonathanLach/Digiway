using DigiwayWebapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DigiwayDBGenerator
{
    [TestClass]
    public class DBGenerator
    {
        DigiwayContext _context;
        [TestInitialize]

        public void DBGeneration()
        {
            //string deleteFriendship = "CREATE TRIGGER digiway.cascadeFriendship ON digiway.Users AFTER DELETE AS DELETE FROM digiway.Friendships WHERE FriendUserId IS NULL;";
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            DbContextOptions options = builder.UseSqlServer("Server=tcp:digiway.database.windows.net,1433;Initial Catalog=Digiway;Persist Security Info=False;User ID=jlachapelle;Password=ig2017Digiway;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;").Options;
            _context = new DigiwayContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            User testUser = new User()
            {
                FirstName= "Jonathan",
                LastName="Lachapelle",
                Address="Rue du puit 18",
                ZIP=6000,
                City="CHarleroi",
                Login="jlachapelle",
                Password= "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff",
                AccessRights =7,
                IBANAccount=null,
                Money=0,
                TelNumber=0476064613,
                Hashcode="pqk1451ds45",
            };
            User testUser2 = new User()
            {
                FirstName="Antoine",
                LastName="Maréchal",
                Address="Rue de Namur",
                ZIP=5000,
                City="Namur",
                Login="amarechal",
                Password= "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff",
                AccessRights=7,
                IBANAccount=null,
                Money=0,
                TelNumber=0476064613,
                Hashcode="emach14751dqad4"
            };
            /*Friendship testFriendship = new Friendship()
            {
                User = testUser,
                Friend = testUser2,
                IsAwaiting = false
            };*/
            ActionRecord testActionRecord = new ActionRecord()
            {
                RecordDate = new System.DateTime(2017, 11, 11),
                User = testUser
            };

            Company testCompany = new Company()
            {
                Name = "Digiway",
                Address = "19 rue du puit",
                ZIP = 6000,
                City = "Charleroi",
                Country = "Belgium",
                TelNum = 0476064613,
            };

            EventCategory testEventCateg = new EventCategory()
            {
                Name = "Convention",
            };

            Event testEvent = new Event()
            {
                Name = "Digiway opening 2017",
                EventDate = new System.DateTime(2017, 11, 19),
                EventCategory = testEventCateg,
                Address = "19 rue du tunnel",
                ZIP = 6010,
                City = "Couillet",
                Company = testCompany,
                Description = "Pour tout le monde",
                TicketPrice = 10,
            };

            PointOfInterest testPOI = new PointOfInterest()
            {
                Name = "Stand de nourriture",
                Description = "Où on peut se nourrir",
                Latitude = 10,
                Longitude = 10,
                Event = testEvent,
            };

            ProductCategory testProdCateg = new ProductCategory()
            {
                Name = "Nourriture"
            };

            Product testProduct = new Product()
            {
                Name = "Sandwich",
                ProductCategory = testProdCateg,
                IsCustom = false
            };

            PurchaseRecord testPurchaseRec = new PurchaseRecord()
            {
                Quantity = 10,
                UnitPrice = 10,
                ActionRecord = testActionRecord,
                Event = testEvent,
                Product = testProduct,
            };

            TransferRecord testTransferRec = new TransferRecord()
            {
                TransferedValue = 10,
                ActionRecord = testActionRecord
            };

            UserCompany testUserCompany = new UserCompany()
            {
                Company = testCompany,
                User = testUser
            };

            _context.Users.Add(testUser);
            _context.Users.Add(testUser2);
            _context.ActionRecords.Add(testActionRecord);
            _context.Companies.Add(testCompany);
            _context.EventCategories.Add(testEventCateg);
            _context.Events.Add(testEvent);
            _context.PointsOfInterest.Add(testPOI);
            _context.ProductCategories.Add(testProdCateg);
            _context.Products.Add(testProduct);
            _context.PurchaseRecords.Add(testPurchaseRec);
            _context.TransferRecords.Add(testTransferRec);
            _context.UserCompanies.Add(testUserCompany);
            //_context.Friendships.Add(testFriendship);
            //_context.Database.ExecuteSqlCommand(deleteFriendship);
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task TestMethod()
        {
            EventCategory category = await _context.EventCategories.FirstAsync();
        }
    }
}
