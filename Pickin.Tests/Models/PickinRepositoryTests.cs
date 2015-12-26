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
        private Mock<DbSet<PickinUser>> mock_user_set;
        private Mock<DbSet<Tune>> mock_tune_set;
        private PickinRepository repo;

        private void ConnectUserMocksToDataStore(IEnumerable<PickinUser> data_store)
        {
            var data_source = data_store.AsQueryable<PickinUser>();
            // Hint:  var data_source = (data_store as IEnumerable<PickinUser>).AsQueryable();
            // Convice LINQ that the Mock DbSet is a (relational) Data store.
            mock_user_set.As<IQueryable<PickinUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_user_set.As<IQueryable<PickinUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_user_set.As<IQueryable<PickinUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_user_set.As<IQueryable<PickinUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // Stubbing the PickinUsers property getter
            mock_context.Setup(a => a.PickinUsers).Returns(mock_user_set.Object);
        }

        private void ConnectTuneMocksToDataStore(IEnumerable<Tune> data_store)
        {
            var data_source = data_store.AsQueryable<Tune>();
            // Hint:  var data_source = (data_store as IEnumerable<Tune>).AsQueryable();
            // Convice LINQ that the Mock DbSet is a (relational) Data store.
            mock_tune_set.As<IQueryable<Tune>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_tune_set.As<IQueryable<Tune>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_tune_set.As<IQueryable<Tune>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_tune_set.As<IQueryable<Tune>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // Stubbing the PickinUsers property getter
            mock_context.Setup(a => a.Tunes).Returns(mock_tune_set.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<PickinContext>();
            mock_user_set = new Mock<DbSet<PickinUser>>();
            mock_tune_set = new Mock<DbSet<Tune>>();
            repo = new PickinRepository(mock_context.Object);

        }

        [TestCleanup]
        public void Cleanup()
        {
            mock_context = null;
            mock_user_set = null;
            mock_tune_set = null;
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

            mock_user_set.Object.AddRange(expected);

            ConnectUserMocksToDataStore(expected);

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
