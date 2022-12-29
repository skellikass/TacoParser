﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.ComponentModel;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        const double metersToMiles = 0.00062137;

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file  -------DONE
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);     //lines is an array now
            if (lines.Length == 0)
            {
                logger.LogError("log error");
            }
            if (lines.Length == 1)
            {
                logger.LogWarning("log warning");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class -------DONE
            TacoParser parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse); -------DONE
            var locations = lines.Select(parser.Parse).ToArray();    //locations is also an array

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other. -------DONE
            ITrackable tBell1 = null;
            ITrackable tBell2 = null;
            // Create a `double` variable to store the distance -------DONE
            double distance = 0;
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;` -------DONE

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tBell1 = locA;
                        tBell2 = locB;
                    }
                }
            }

            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`) -----DONE

            // Create a new Coordinate with your locB's lat and long ------DONE

            // Now, compare the two using `.GetDistanceTo()`, which returns a double -------DONE

            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above ------DONE

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

            Console.WriteLine($"{tBell1.Name} and {tBell2.Name} are {Math.Round((distance * metersToMiles),2)} miles apart.");
            logger.LogInfo($"{tBell1.Name} and {tBell2.Name} are the farthest apart.");


        }
    }
}
