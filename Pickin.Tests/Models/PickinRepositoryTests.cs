using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pickin.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace Pickin.Tests.Models
{
    [TestClass]
    public class PickinRepositoryTests
    {
        private Mock<PickinContext> mock_context;
        private Mock<DbSet<PickinUser>> mock_set;
        private PickinRepository repo;

        private void ConnectMocksToDataStore(IEnumerable<PickinUser> data_store)
        {
            var data_source = data_store.AsQueryable<PickinUser>();
            // Hint:  var data_source = (data_store as IEnumerable<PickinUser>).AsQueryable();
            // Convice LINQ that the Mock DbSet is a (relational) Data store.
            mock_set.As<IQueryable<PickinUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<PickinUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<PickinUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<PickinUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // Stubbing the PickinUsers property getter
            mock_context.Setup(a => a.PickinUsers).Returns(mock_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<PickinContext>();
            mock_set = new Mock<DbSet<PickinUser>>();
            repo = new PickinRepository(mock_context.Object);

        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_set = null;
            repo = null;
        }

        [TestMethod]
        public void PickinContextEnsureICanCreateInstance()
        {
            PickinContext context = mock_context.Object;
            Assert.IsNotNull(context); 
        }

        [TestMethod]
        public void PickinRepositoryEnsureICanCreateInstance()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void PickinRepositoryEnsureICanGetAllUsers()
        {
            // Arrange
            var expected = new List<PickinUser>
            {
                new PickinUser { FirstName = "JoAnn" },
                new PickinUser { FirstName = "Tony" }
            };

            mock_set.Object.AddRange(expected);

            ConnectMocksToDataStore(expected);

            // Act
            var actual = repo.GetAllUsers();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PickinRepositoryEnsureIHaveAContext()
        {
            // Arrange

            // Act
            var actual = repo.Context;

            // Assert
            Assert.IsInstanceOfType(actual, typeof(PickinContext));
        }

    }
}
