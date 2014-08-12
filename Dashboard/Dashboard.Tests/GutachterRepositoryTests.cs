using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Dashboard.Models;
using FakeDbSet;
using Moq;
using NUnit.Framework;

namespace Dashboard.Tests
{
    [TestFixture]
    public class GutachterRepositoryTests
    {
        private IGutachterRepository _sut;
        private InMemoryDbSet<Gutachter> _inMemoryDbSet;
        private Mock<IDashboardContext> _mockedContext;

        [SetUp]
        public void Init()
        {
            var klaus = new Gutachter { Id= 2, Vorname = "Klaus"};
            klaus.Gutachten.Add(new Gutachten());

            _inMemoryDbSet = new InMemoryDbSet<Gutachter>(true)
                             {
                                 new Gutachter { Id = 1, Vorname = "Hans" },
                                 klaus,
                                 new Gutachter { Id = 3, Vorname = "Inge" }
                             };

            var mockedContext = new Mock<IDashboardContext>();
            mockedContext.Setup(x => x.Gutachter).Returns(_inMemoryDbSet);
            _sut = new GutachterRepository(mockedContext.Object);
        }

        [TestCase("ReadAll returns all values", Result = 3)]
        public int ReadAll()
        {
            return _sut.ReadAll().Count();
        }

        [Test]
        public void ReadAll_returns_all_values()
        {
            IEnumerable<Gutachter> result = _sut.ReadAll();
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void Read_returns_specific_item()
        {
            Gutachter result = _sut.Read(2);
            Assert.That(result.Id, Is.EqualTo(2));
            Assert.That(result.Nachname, Is.EqualTo("Klaus"));
        }

        [Test]
        public void Create_adds_an_item_to_db()
        {
            int result =  _sut.Create("Hans", "Hanson", "test@test.de");

            Assert.That(_inMemoryDbSet.Count(), Is.EqualTo(4), "Create should add an item to DB");
            Assert.That(result, Is.EqualTo(4), "Create should return a new incremented id");
        }

        [Test]
        public void Create_calls_add_and_save()
        {
            var mockSet = new Mock<IDbSet<Gutachter>>();
            var mockedContext = new Mock<IDashboardContext>();
            mockedContext.Setup(x => x.Gutachter).Returns(mockSet.Object);
            _sut = new GutachterRepository(mockedContext.Object);

            _sut.Create("Hans", "Hanson", "test@test.de");

            mockSet.Verify(x => x.Add((It.IsAny<Gutachter>())), Times.Once());
            mockedContext.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public void Update_modifies_item_in_db()
        {
            var changedData = new Gutachter
            {
                Id = 2,
                Nachname = "TEST",
                Vorname = "TEST",
                EMail = "TEST@TEST.DE"
            };

            _sut.Update(changedData);

            Gutachter vorherKlaus = _inMemoryDbSet.First(x => x.Id == 2);

            Assert.That(vorherKlaus.Vorname, Is.EqualTo(changedData.Vorname), "Vorname should change");
            Assert.That(vorherKlaus.Nachname, Is.EqualTo(changedData.Nachname), "Nachname should change");
            Assert.That(vorherKlaus.EMail, Is.EqualTo(changedData.EMail), "EMail should change");
            Assert.That(vorherKlaus.Gutachten.Count, Is.EqualTo(1), "Gutachten should not be changed");

            _mockedContext.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public void Delete_removes_one_item_from_db()
        {
            _sut.Delete(2);

            Gutachter vorherKlaus = _inMemoryDbSet.FirstOrDefault(x => x.Id == 2);

            Assert.That(vorherKlaus, Is.EqualTo(null), "The specified item must be deleted from DB");
            _mockedContext.Verify(x => x.SaveChanges(), Times.Once());
        }
    }
}
