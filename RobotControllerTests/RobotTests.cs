using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotController.robots;
using RobotController.helpers;
using RobotController.obstacles;

namespace RobotControllerTests
{
    [TestClass]
    public class RobotTests
    {
        ObstacleHolder _holder = new ObstacleHolder(5, 5);
        Hole _hole = new Hole(3,2);
        Rock _rock = new Rock();
        Spinner _spinner = new Spinner(true, 1);

        [TestMethod]
        public void CreateRobot()
        {
            var point = new Point(0, 0);
            var robot = new SimpleRobot(point, 0, _holder, 5, 5);
            Assert.IsNotNull(robot);
        }

        [TestMethod]
        public void MoveForward()
        {
            var point = new Point(0, 0);
            var robot = new SimpleRobot(point, 0, _holder, 5, 5);
            robot.Move('F');
            var newPoint = robot.GetLocation();
            Assert.AreEqual(0, newPoint.XPoint);
            Assert.AreEqual(1, newPoint.YPoint);
        }

        [TestMethod]
        public void MoveRight()
        {
            var point = new Point(0, 0);
            var robot = new SimpleRobot(point, 0, _holder, 5, 5);
            robot.Move('R');
            var newPoint = robot.GetLocation();
            Assert.AreEqual(1, newPoint.XPoint);
            Assert.AreEqual(0, newPoint.YPoint);
        }

        [TestMethod]
        public void TestXBoundry0()
        {
            var point = new Point(0, 0);
            var robot = new SimpleRobot(point, 0, _holder, 5, 5);
            //try to move left from 0,0: make sure we stay there
            robot.Move('L');
            var newPoint = robot.GetLocation();
            Assert.AreEqual(0, newPoint.XPoint);
            Assert.AreEqual(0, newPoint.YPoint);
        }

        [TestMethod]
        public void TestXBountryMax()
        {
            var point = new Point(0, 0);
            var robot = new SimpleRobot(point, 0, _holder, 5, 5);
            //try to move right from 0,0 5 times: make sure we stay at 4,0
            robot.Move('R');
            robot.Move('F');
            robot.Move('F');
            robot.Move('F');
            robot.Move('F');
            var newPoint = robot.GetLocation();
            Assert.AreEqual(4, newPoint.XPoint);
            Assert.AreEqual(0, newPoint.YPoint);
        }

        [TestMethod]
        public void TestYBoundry0()
        {
            var point = new Point(0, 0);
            //set init direction to south (2)
            var robot = new SimpleRobot(point, 2, _holder, 5, 5);
            //move F, make sure we stay @ 00
            robot.Move('F');
            var newPoint = robot.GetLocation();
            Assert.AreEqual(0, newPoint.XPoint);
            Assert.AreEqual(0, newPoint.YPoint);
        }

        [TestMethod]
        public void TestYBoundryMax()
        {
            var point = new Point(0, 0);
            var robot = new SimpleRobot(point, 0, _holder, 5, 5);
            //move F 5 times, make sure we stay at 0,4
            robot.Move('F');
            robot.Move('F');
            robot.Move('F');
            robot.Move('F');
            robot.Move('F');
            var newPoint = robot.GetLocation();
            Assert.AreEqual(0, newPoint.XPoint);
            Assert.AreEqual(4, newPoint.YPoint);
        }        

        [TestMethod]
        public void TestRock()
        {
            var point = new Point(0, 0);
            var robot = new SimpleRobot(point, 0, _holder, 5, 5);
            //put a rock at 0,2, try to move forward 3,  make sure we stay at 0,1
            _holder.SetObstacle(0, 2, _rock);
            robot.Move('F');
            robot.Move('F');
            robot.Move('F');
            var newPoint = robot.GetLocation();
            Assert.AreEqual(0, newPoint.XPoint);
            Assert.AreEqual(1, newPoint.YPoint);
        }

        [TestMethod]
        public void TestHole()
        {
            var point = new Point(4, 0);
            var robot = new SimpleRobot(point, 0, _holder, 5, 5);
            _holder.SetObstacle(4, 2, new Hole(3, 2));
            robot.Move('F');
            robot.Move('F');
            var newPoint = robot.GetLocation();
            Assert.AreEqual(3, newPoint.XPoint);
            Assert.AreEqual(2, newPoint.YPoint);
        }

        [TestMethod]
        public void TestSpinner()
        {
            var point = new Point(2, 0);
            var robot = new SimpleRobot(point, 0, _holder, 5, 5);
            _holder.SetObstacle(2, 1, new Spinner(true, 1));
            robot.Move('F');
            robot.Move('F');
            var newPoint = robot.GetLocation();
            Assert.AreEqual(3, newPoint.XPoint);
            Assert.AreEqual(1, newPoint.YPoint);
        }

    }
}
