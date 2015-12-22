using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pickin.Models;

namespace Pickin.Tests.Models
{
    [TestClass]
    public class TuneTests
    {
        [TestMethod]
        public void TuneEnsureICanCreateInstance()
        {
            Tune a_tune = new Tune();
            Assert.IsNotNull(a_tune);
        }

        [TestMethod]
        public void TuneEnsureTuneHasAllTheThings()
        {
            // Arrange
            Tune a_tune = new Tune();

            // Act
            a_tune.TuneId = 1;
            a_tune.Artist = "Earl Scruggs";
            a_tune.Title = "Foggy Mountain Breakdown";
            a_tune.Year = 1971;

            // Assert
            Assert.AreEqual(1, a_tune.TuneId);
            Assert.AreEqual("Earl Scruggs", a_tune.Artist);
            Assert.AreEqual("Foggy Mountain Breakdown", a_tune.Title);
            Assert.AreEqual(1971, a_tune.Year);

        }

        [TestMethod]
        public void TuneEnsureICanUseObjectInitializerSyntax()
        {
            // Arrange

            // Act
            Tune a_tune = new Tune { TuneId = 1, Artist = "Earl Scruggs", Title = "Foggy Mountain Breakdown", Year = 1971 };

            // Assert
            Assert.AreEqual(1, a_tune.TuneId);
            Assert.AreEqual("Earl Scruggs", a_tune.Artist);
            Assert.AreEqual("Foggy Mountain Breakdown", a_tune.Title);
            Assert.AreEqual(1971, a_tune.Year);
        }
    }
}
