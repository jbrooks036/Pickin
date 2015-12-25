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
        [TestMethod]
        public void PickinContextEnsureICanCreateInstance()
        {
            PickinContext context = new PickinContext();
            Assert.IsNotNull(context); 
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
            Mock<PickinContext> mock_context = new Mock<PickinContext>();
            Mock<DbSet<PickinUser>> mock_set = new Mock<DbSet<PickinUser>>();

            mock_set.Object.AddRange(expected);
            var data_source = expected.AsQueryable();

            // Convice LINQ that the Mock DbSet is a (relational) Data store.
            mock_set.As<IQueryable<PickinUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<PickinUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<PickinUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<PickinUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // Stubbing the PickinUsers property getter
            mock_context.Setup(a => a.PickinUsers).Returns(mock_set.Object);
            PickinRepository repo = new PickinRepository(mock_context.Object);

            // Act
            var actual = repo.GetAllUsers();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PickinRepositoryEnsureIHaveAContext()
        {
            // Arrange
            PickinRepository repo = new PickinRepository();

            // Act
            var actual = repo.Context;

            // Assert
            Assert.IsInstanceOfType(actual, typeof(PickinContext));
        }

    }
}
