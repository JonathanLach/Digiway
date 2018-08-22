using DigiwayWebapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
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
            string deleteFriendship = "CREATE TRIGGER digiway.cascadeFriendship ON digiway.Users AFTER DELETE AS DELETE FROM digiway.Friendships WHERE FriendUserId IS NULL;";
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            DbContextOptions options = builder.UseSqlServer("Server=tcp:digiway.database.windows.net,1433;Initial Catalog=digiway;Persist Security Info=False;User ID=jlachapelle;Password=Mobile2018;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;").Options;
            _context = new DigiwayContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
         
            /*Friendship testFriendship = new Friendship()
            {
                User = testUser,
                Friend = testUser2,
                IsAwaiting = false
            };*/

            Company testCompany = new Company()
            {
                Name = "Digiway",
                Address = "19 rue du puit",
                ZIP = "6000",
                City = "Charleroi",
                Country = "Belgium",
                TelNum = 0476064613,
            };

            User testUser = new User()
            {
                FirstName = "Jonathan",
                LastName = "Lachapelle",
                Address = "Rue du puit 18",
                ZIP = "6000",
                City = "CHarleroi",
                Login = "jlachapelle",
                Password = "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff",
                AccessRights = 7,
                //Money = 0,
                BirthDate = new DateTime(1996, 10, 30),
                IBANAccount = null,
                TelNumber = "9774d56d682e549d",
            };
            User testUser2 = new User()
            {
                FirstName = "Antoine",
                LastName = "Maréchal",
                Address = "Rue de Namur",
                ZIP = "5000",
                //Money = 0,
                City = "Namur",
                Login = "amarechal",
                Password = "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff",
                AccessRights = 7,
                BirthDate = new DateTime(2010, 10, 10),
                IBANAccount = null,
                TelNumber = "9774d56d682e549c",
            };

            EventCategory testEventCateg = new EventCategory()
            {
                Name = "Convention",
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

            UserCompany testUserCompany = new UserCompany()
            {
                Company = testCompany,
                User = testUser
            };

            _context.Users.Add(testUser);
            _context.Users.Add(testUser2);
            _context.Companies.Add(testCompany);
            _context.EventCategories.Add(testEventCateg);
            _context.EventCategories.Add(new EventCategory()
            {
                Name = "Festival"
            });
            _context.EventCategories.Add(new EventCategory()
            {
                Name = "Foire"
            });
            _context.EventCategories.Add(new EventCategory()
            {
                Name = "Culturel"
            });
            _context.EventCategories.Add(new EventCategory()
            {
                Name = "Convention"
            });

            Collection<PointOfInterest> pointsOfInterest = new Collection<PointOfInterest>();

            PointOfInterest poi1 = new PointOfInterest()
            {
                Name = "Food stand",
                Description = "For food",
                Longitude = 44.23,
                Latitude = 45.02,
            };
            PointOfInterest poi2 = new PointOfInterest()
            {
                Name = "Food stand",
                Description = "For food",
                Longitude = 43.23,
                Latitude = 46.02,
            };
            pointsOfInterest.Add(poi1);
            pointsOfInterest.Add(poi2);

            Location location = new Location()
            {
                Latitude = 45.02,
                Longitude = 43.23,
            };

            _context.Events.Add(new Event()
            {
                Name = "JonathanFest",
                Address = "45 rue du hameau",
                ZIP = "6000",
                City = "Charleroi",
                EventDate = new DateTime(),
                Location = location,
                TicketPrice = 10.02M,
                Description = "Pour les meilleurs",
                Company = testCompany,
                EventCategory = testEventCateg,
                PointsOfInterest = pointsOfInterest
            });
            _context.ProductCategories.Add(testProdCateg);
            _context.Products.Add(testProduct);
            _context.UserCompanies.Add(testUserCompany);
            //_context.Friendships.Add(testFriendship);
            _context.Database.ExecuteSqlCommand(deleteFriendship);
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task TestMethod()
        {
            EventCategory category = await _context.EventCategories.FirstAsync();
        }
    }
}
