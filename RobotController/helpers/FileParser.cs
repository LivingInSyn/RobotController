using Newtonsoft.Json;
using RobotController.obstacles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.helpers
{
    public class FileParser
    {
        /// <summary>
        /// parses a JSON file to build a configuration object
        /// </summary>
        /// <param name="filePath">Path to the JSON file holding the configuration</param>
        /// <returns>a ParseReturn object</returns>
        public ParserReturn ParseFile(string filePath)
        {            
            string readText;
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("Cannot find the Configuration File");
            }
            readText = File.ReadAllText(filePath);
            return parseString(readText);            
        }

        /// <summary>
        /// parses a JSON string to build a configuration object
        /// </summary>
        /// <param name="parse">JSON string holding the configuration</param>
        /// <returns>a ParseReturn object</returns>
        public ParserReturn parseString(string parse)
        {
            ParserReturn parseReturn = new ParserReturn();
            JsonFileFormat configuration = JsonConvert.DeserializeObject<JsonFileFormat>(parse);
            //set max x and max y
            parseReturn.MaxX = configuration.MaxX;
            parseReturn.MaxY = configuration.MaxY;
            //make the obstacleHolder
            parseReturn.ObstacleHolder = new ObstacleHolder(configuration.MaxX, configuration.MaxY);
            //make the steps
            parseReturn.Steps = configuration.Steps.ToCharArray();
            //build the obstacles
            foreach (var obj in configuration.ObstacleObjects)
            {
                IObstacle obstacle;
                if (obj.Type == "Rock")
                {
                    obstacle = JsonConvert.DeserializeObject<Rock>(obj.Obstacle);
                    parseReturn.ObstacleHolder.SetObstacle(obj.XLoc, obj.YLoc, obstacle);
                }
                else if (obj.Type == "Hole")
                {
                    obstacle = JsonConvert.DeserializeObject<Hole>(obj.Obstacle);
                    parseReturn.ObstacleHolder.SetObstacle(obj.XLoc, obj.YLoc, obstacle);
                }
                else if (obj.Type == "Spinner")
                {
                    obstacle = JsonConvert.DeserializeObject<Spinner>(obj.Obstacle);
                    parseReturn.ObstacleHolder.SetObstacle(obj.XLoc, obj.YLoc, obstacle);
                }
            }
            return parseReturn;
        }
    }
}
