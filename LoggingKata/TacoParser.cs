using System.Data.Common;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ',' -------DONE
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogInfo("Length is less than 3");
                // Do not fail if one record parsing fails, return null 
                return null; // TODO Implement -------DONE
            }

            // grab the latitude from your array at index 0 -------DONE
            Point latAndLon = new Point();
            latAndLon.Latitude = double.Parse(cells[0]);
            // grab the longitude from your array at index 1 -------DONE
            latAndLon.Longitude = double.Parse(cells[1]);
            // grab the name from your array at index 2 -------DONE
            TacoBell tBell = new TacoBell();
            tBell.Name = cells[2];

            // You're going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int` -------DONE

            // You'll need to create a TacoBell class
            // that conforms to ITrackable -------DONE

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly -------DONE
            tBell.Location = latAndLon;

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable -------DONE

            return tBell;
        }
    }
}