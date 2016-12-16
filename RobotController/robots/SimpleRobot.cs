using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.helpers;
using RobotController.obstacles;

namespace RobotController.robots
{
    public class SimpleRobot : ARobot,IRobot
    {
        /// <summary>
        /// Builds a simple robot
        /// </summary>
        /// <param name="startingPoint">Starting point in the grid</param>
        /// <param name="startingDirection">Direction to start in. 0 is north, 1 is east, 2 is south, 3 is west</param>
        /// <param name="obstacleHolder">holder for the obstacles</param>
        /// <param name="maxX">Maximum x location</param>
        /// <param name="maxY">Maximum y location</param>
        public SimpleRobot(Point startingPoint,int startingDirection, ObstacleHolder obstacleHolder, int maxX, int maxY) : base(startingPoint, startingDirection, obstacleHolder, maxX, maxY) { }
        
        /// <summary>
        /// moves the robot and appends its history to it's path list
        /// </summary>
        /// <param name="direction">char: direction to move in. Accepts F,R,L</param>
        public void Move(char direction)
        {
            //overall idea here is 'turn', then check what's in front of me, if nothing, move there
            //if it's a hole, update our location accordingly 
            //if spinner, move and adjust heading
            //if rock, do nothing
            //if unknown, do nothing

            //adjust direction (turn stage)
            this.SetNewDirection(direction);

            //calculate the 'possible next point'
            Point possiblePoint = this.GetPossiblePoint();            
            //if nothing changed, it was an impossible point, add it to the path
            if(possiblePoint.XPoint == _currentPoint.XPoint && possiblePoint.YPoint == _currentPoint.YPoint)
            {
                _path.Add(possiblePoint);
            }
            //we're in bounds of the grid, start obstacle checking
            else
            {
                //if there's no obstacle, the point is good, adjust our current location, and add the point to the pathlist
                if(_obstacleHolder.GetObstacle(possiblePoint) == null)
                {
                    _currentPoint = possiblePoint;
                    _path.Add(possiblePoint);
                }
                //there is an obstacle, find out the type, and act accordingly
                else
                {
                    var obstacleType = _obstacleHolder.GetObstacle(possiblePoint).GetType();
                    var obstacle = _obstacleHolder.GetObstacle(possiblePoint);
                    //we're goint to say the holes don't change the direction you're facing
                    if (obstacleType == typeof(Hole))
                    {
                        var hole = (Hole)obstacle;
                        _currentPoint = new Point()
                        {
                            XPoint = hole.NewX,
                            YPoint = hole.NewY
                        };
                        //add the possible point (loc of the hole) to the path, as well as the transported (now current) point
                        _path.Add(possiblePoint);
                        _path.Add(_currentPoint);                        
                    }
                    else if (obstacleType == typeof(Rock))
                    {
                        //do nothing, no change in direction, no new steps
                    }
                    else if (obstacleType == typeof(Spinner))
                    {
                        var spinner = (Spinner)obstacle;
                        if(spinner.Direction == true)
                        {
                            _currentDirection = (_currentDirection + spinner.Turns) % 4;
                        }
                        else
                        {
                            _currentDirection = (_currentDirection - spinner.Turns) % 4;
                        }
                        _path.Add(possiblePoint);
                        _currentPoint = possiblePoint;
                    }
                    //if it's unknown, do nothing, stay put
                    else
                    {
                        //do nothing
                    }
                }
            }
        }
    }
}
