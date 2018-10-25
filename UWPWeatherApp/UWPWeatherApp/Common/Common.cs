using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPWeatherApp.Common
{
    public class Common
    {
        public static string API_LINK = "http://api.openweathermap.org/data/2.5/weather";
        public static string API_KEY = "05a6911ed367fd34b3be94ba57d25ce3";

        public static string APIRequest(string lat, string lon)
        {
            StringBuilder strBuilder = new StringBuilder(API_LINK);
            //units= metric to convert temp to Celsius
            strBuilder.AppendFormat("?lat={0}&lon={1}&APPID={2}&units=metric", lat, lon, API_KEY);
            return strBuilder.ToString();

        }

        public static DateTime ConvertUnixTimeToDateTime(double unix)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dt = dt.AddSeconds(unix).ToLocalTime();
            return dt;
        }
    }
}
