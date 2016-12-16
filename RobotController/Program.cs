using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotController.obstacles;
using RobotController.robots;
using RobotController.helpers;
using System.IO;
using Newtonsoft.Json;

namespace RobotController
{
    class Program
    {
        static ObstacleHolder _obstacleHolder;
        static char[] _steps;
        static int _maxX;
        static int _maxY;

        static void Main(string[] args)
        {
            string filepath = "";
            //get the file to parse
            if(args.Length == 0)
            {
                //if there's no argument, assume that it's in the same directory as the EXE
                filepath = "RobotSetup.json";
            }
            else
            {
                filepath = args[0];
            }
            //parse the file and store the values
            FileParser parser = new FileParser();
            var setValues = parser.ParseFile(filepath);
            _obstacleHolder = setValues.ObstacleHolder;
            _steps = setValues.Steps;
            _maxX = setValues.MaxX;
            _maxY = setValues.MaxY;

            //make a bot
            Point startingPoint = new Point(0, 0);
            IRobot robot = new SimpleRobot(startingPoint, 0, _obstacleHolder, _maxX, _maxY);

            //start running the bot
            foreach(var step in _steps)
            {
                robot.Move(step);
            }
            //print the path
            int counter = 0;
            foreach(var step in robot.GetPath())
            {                
                Console.WriteLine(String.Format("{0}: ({1},{2})", counter, step.XPoint, step.YPoint));
                counter++;
            }
            Console.WriteLine("\n\nEnter to exit...");
            Console.ReadLine();             
        }       

    }
}

