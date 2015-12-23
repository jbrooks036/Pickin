using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pickin.Models;
using System.Collections.Generic;

namespace Pickin.Tests.Models
{
    [TestClass]
    public class PickinUserTests
    {
        [TestMethod]
        public void PickinUserEnsureICanCreateInstance()
        {
            PickinUser a_user = new PickinUser();
            Assert.IsNotNull(a_user);
        }

        [TestMethod]
        public void PickinUserEnsurePickinUserHasAllTheThings()
        {
            // Arrange
            PickinUser a_user = new PickinUser();
            a_user.FirstName = "JoAnn";
            a_user.LastName = "Brooks";

            // Assert
            Assert.AreEqual("JoAnn", a_user.FirstName);
            Assert.AreEqual("Brooks", a_user.LastName);
        }

        [TestMethod]
        public void PickinUserEnsurePickinUserHasTunes()
        {
            // Arrange
            List<Tune> list_of_tunes = new List<Tune>
            {
                new Tune { Title = "Little Maggie" },
                new Tune { Title = "Boil dem cabbage" }
            };
            PickinUser a_user = new PickinUser
            {
                FirstName = "JoAnn",
                LastName = "Brooks",
                Tunes = list_of_tunes
            };
        }
    }
}
