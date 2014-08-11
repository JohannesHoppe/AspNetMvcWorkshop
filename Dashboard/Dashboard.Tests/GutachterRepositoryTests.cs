using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Models;
using FakeDbSet;
using Moq;
using NUnit.Framework;

namespace Dashboard.Tests
{
    [TestFixture]
    public class GutachterRepositoryTests
    {
        [Test]
        public void TransferFunds()
        {
            // Arrange
            InMemoryDbSet<Gutachter> inMemoryDbSet = new InMemoryDbSet<Gutachter>(true);

            var mockedContext = new Mock<IDashboardContext>();
            mockedContext.Setup(x => x.Gutachter).Returns(inMemoryDbSet);

            IGutachterRepository sut = new GutachterRepository(mockedContext.Object);
        }
    }
}
