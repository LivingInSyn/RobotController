using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotController.helpers;
using RobotController.obstacles;
using Newtonsoft.Json;

namespace RobotControllerTests
{
    [TestClass]
    public class HelperTests
    {
        private ObstacleHolder _obstacleHolder;
        private Point _point;

        [TestMethod]
        public void CreatePoint()
        {
            _point = new Point(1, 2);
            Assert.AreEqual(1, _point.XPoint);
            Assert.AreEqual(2, _point.YPoint);
        }

        [TestMethod]
        public void UpdatePoint()
        {
            _point = new Point(1, 2);
            _point.XPoint = 3;
            _point.YPoint = 4;
            Assert.AreEqual(3, _point.XPoint);
            Assert.AreEqual(4, _point.YPoint);
        }

        [TestMethod]
        public void SetGetObstacleByPoint()
        {
            _obstacleHolder = new ObstacleHolder(5,5);
            _obstacleHolder.SetObstacle(1, 1, new Rock());
            Assert.IsInstanceOfType(_obstacleHolder.GetObstacle(1,1), typeof(IObstacle));
        }

        [TestMethod]
        public void SetGetObstacleByCoords()
        {
            _obstacleHolder = new ObstacleHolder(5, 5);
            _obstacleHolder.SetObstacle(new Point(2, 2), new Rock());
            Assert.IsInstanceOfType(_obstacleHolder.GetObstacle(new Point(2, 2)), typeof(IObstacle));
        }

        [TestMethod]
        public void ParseFile()
        {
            JsonFileFormat format = new JsonFileFormat();
            format.MaxX = 5;
            format.MaxY = 7;
            format.Steps = "FFF";
            format.ObstacleObjects.Add(new ObstacleSetupObj()
            {
                XLoc = 1,
                YLoc = 1,
                Type = "Rock",
                Obstacle = JsonConvert.SerializeObject(new Rock())
            });
            format.ObstacleObjects.Add(new ObstacleSetupObj()
            {
                XLoc = 2,
                YLoc = 2,
                Type = "Hole",
                Obstacle = JsonConvert.SerializeObject(new Hole(3,3))
            });
            format.ObstacleObjects.Add(new ObstacleSetupObj()
            {
                XLoc = 4,
                YLoc = 4,
                Type = "Spinner",
                Obstacle = JsonConvert.SerializeObject(new Spinner(true, 3))
            });
            string serialized = JsonConvert.SerializeObject(format);

            var parser = new FileParser();
            ParserReturn testedObj = parser.parseString(serialized);

            Assert.AreEqual(5, testedObj.MaxX);
            Assert.AreEqual(7, testedObj.MaxY);
            Assert.AreEqual("FFF".ToCharArray()[0], testedObj.Steps[0]);
            Assert.IsInstanceOfType(testedObj.ObstacleHolder.GetObstacle(1, 1), typeof(Rock));
            Assert.IsInstanceOfType(testedObj.ObstacleHolder.GetObstacle(2, 2), typeof(Hole));
            Assert.IsInstanceOfType(testedObj.ObstacleHolder.GetObstacle(4, 4), typeof(Spinner));

        }
    }
}
