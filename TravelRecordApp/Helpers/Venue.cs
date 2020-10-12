using System;
namespace TravelRecordApp.Helpers
{
    public class Venue
    {
        public static string GenearetURL(double latitude, double longitude)
        {
            return string.Format(Constants.VENURE_SEARCH, latitude, longitude, Constants.CLIENT_ID, Constants.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
