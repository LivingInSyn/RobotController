using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotController.obstacles;

namespace RobotControllerTests
{
    [TestClass]
    public class ObstacleTests
    {
        [TestMethod]
        public void CreateRock()
        {
            var rock = new Rock();
            Assert.IsNotNull(rock);
        }

        [TestMethod]
        public void RockNavigateTest()
        {
            var rock = new Rock();
            Assert.AreEqual(false, rock.CanNavigate);
        }

        [TestMethod]
        public void CreateHole()
        {
            var hole = new Hole(2, 2);
            Assert.IsNotNull(hole);
        }

        [TestMethod]
        public void UpdateHole()
        {
            var hole = new Hole(2, 2);
            hole.NewX = 3;
            hole.NewY = 4;
            Assert.AreEqual(3, hole.NewX);
            Assert.AreEqual(4, hole.NewY);
        }

        [TestMethod]
        public void HoleNavigateTest()
        {
            var hole = new Hole(2, 2);
            Assert.AreEqual(true, hole.CanNavigate);
        }

        [TestMethod]
        public void CreateSpinner()
        {
            var spinner = new Spinner(true,1);
            Assert.IsNotNull(spinner);
        }

        [TestMethod]
        public void UpdateSpinnerDirection()
        {
            var spinner = new Spinner(true, 1);
            spinner.Direction = false;
            Assert.AreEqual(false, spinner.Direction);
        }

        [TestMethod]
        public void UpdateSpinnerTurns()
        {
            var spinner = new Spinner(true, 1);
            spinner.Turns = 5;
            Assert.AreEqual(5, spinner.Turns);
        }

        [TestMethod]
        public void SpinnerNavigationTest()
        {
            var spinner = new Spinner(true, 1);
            Assert.AreEqual(true, spinner.CanNavigate);
        }
    }
}
