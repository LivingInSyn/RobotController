using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.helpers;
using RobotController.obstacles;

namespace RobotController.robots
{
    public abstract class ARobot
    {
        /// <summary>
        /// maximum x location
        /// </summary>
        protected int _maxX { get; set; }
        /// <summary>
        /// maximum y location
        /// </summary>
        protected int _maxY { get; set; }
        /// <summary>
        /// current location of the robot
        /// </summary>
        protected Point _currentPoint { get; set; }
        /// <summary>
        /// 0 is north, 1 is east, 2 is south, 3 is west
        /// </summary>
        protected int _currentDirection { get; set; }
        /// <summary>
        /// obstacle holder to check against
        /// </summary>
        protected ObstacleHolder _obstacleHolder { get; set; }
        /// <summary>
        /// path history of the robot
        /// </summary>
        protected List<Point> _path { get; set; }
        

        /// <summary>
        /// Builds a robot
        /// </summary>
        /// <param name="startingPoint">Starting point in the grid</param>
        /// <param name="startingDirection">Direction to start in. 0 is north, 1 is east, 2 is south, 3 is west</param>
        /// <param name="obstacleHolder">holder for the obstacles</param>
        /// <param name="maxX">Maximum x location</param>
        /// <param name="maxY">Maximum y location</param>
        public ARobot(Point startingPoint, int startingDirection, ObstacleHolder obstacleHolder, int maxX, int maxY)
        {
            _currentPoint = new Point();
            _currentPoint.XPoint = startingPoint.XPoint;
            _currentPoint.YPoint = startingPoint.YPoint;
            _currentDirection = startingDirection;
            _maxX = maxX;
            _maxY = maxY;
            _path = new List<Point>();
            _path.Add(_currentPoint);
            _obstacleHolder = obstacleHolder;
        }

        /// <summary>
        /// returns the current location of the robot
        /// </summary>
        /// <returns></returns>
        public Point GetLocation()
        {
            return _currentPoint;
        }
        /// <summary>
        /// returns the transversal list of the robot
        /// </summary>
        /// <returns>List of points the robot has visited</returns>
        public List<Point> GetPath()
        {
            return _path;
        }

        /// <summary>
        /// sets a new direction for the robot according to the passed in char.
        /// </summary>
        /// <param name="direction">Accepts F,R,L</param>
        protected void SetNewDirection(char direction)
        {
            switch (direction)
            {
                //so it turns out, that c# % is the remainder function, not the mod function like in python
                //that's why I had to roll my own mod func here
                case 'L':
                    //_currentDirection = (_currentDirection - 1) % 4;
                    _currentDirection = mod((_currentDirection - 1), 4);
                    break;
                case 'R':
                    _currentDirection = (_currentDirection + 1) % 4;
                    break;
                case 'F':
                    //no change to heading
                    break;
                default:
                    throw new ArgumentException("Invalid direction");
            }
        }

        /// <summary>
        /// returns the requested point to move to
        /// </summary>
        /// <returns>A Point Object</returns>
        protected Point GetPossiblePoint()
        {
            Point possiblePoint = new Point();
            switch (_currentDirection)
            {
                case 0:
                    //facing north, go up in Y
                    possiblePoint.XPoint = _currentPoint.XPoint;
                    possiblePoint.YPoint = _currentPoint.YPoint + 1;
                    break;
                case 1:
                    //facing east, go +1 in x
                    possiblePoint.XPoint = _currentPoint.XPoint + 1;
                    possiblePoint.YPoint = _currentPoint.YPoint;                    
                    break;
                case 2:
                    //facing south, go -1 in Y
                    possiblePoint.XPoint = _currentPoint.XPoint;
                    possiblePoint.YPoint = _currentPoint.YPoint - 1;
                    break;
                case 3:
                    //facing west, go -1 in X                    
                    possiblePoint.XPoint = _currentPoint.XPoint - 1;
                    possiblePoint.YPoint = _currentPoint.YPoint;
                    break;
                default:
                    throw new Exception("we shouldn't have arrived here: invalid direction");
            }
            //now we need to check the bounds, if we're out of them, do nothing
            if (possiblePoint.XPoint < 0 || possiblePoint.XPoint >= _maxX || possiblePoint.YPoint < 0 || possiblePoint.YPoint >= _maxY)
            {
                possiblePoint.XPoint = _currentPoint.XPoint;
                possiblePoint.YPoint = _currentPoint.YPoint;
            }
            return possiblePoint;
        }

        /// <summary>
        /// returns a python-esque mod operation, a%b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>integer for a MOD b</returns>
        private int mod(int a, int b)
        {
            var initial = a % b;
            if(initial < 0)
            {
                return b + a;
            }
            return initial;
        }
    }
}
