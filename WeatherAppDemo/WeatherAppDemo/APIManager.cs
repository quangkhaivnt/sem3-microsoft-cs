using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace WeatherAppDemo
{
    public class APIManager
    {
        public async static Task<RootObject> GetWeather(double lat, double lon)
        {
            var http = new HttpClient();
            var url = string.Format("http://api.openweathermap.org/data/2.5/find?lat={0}&lon={1}&appid=96381a872b1b405c5bf83b2ed63d9561&units=metric&fbclid=IwAR1CgZHE8cV8Jl1kH0d-_wXU01O1qGKr46J7enzao8gEoa3E-hN4Soqw9nE",lat,lon);
            var response = await http.GetAsync(url); // Nhận data json từ weathermap.org
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            //Khởi tạo ra Stream local để đọc json
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            // Đọc object đã phân tích từ json vào stream local để phân tích
            var data = (RootObject)serializer.ReadObject(ms);
            return data;
        }
    }

    [DataContract]

    public class Coord
    {
        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double lon { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember]
        public int temp { get; set; }
        [DataMember]
        public int pressure { get; set; }
        [DataMember]
        public int humidity { get; set; }
        [DataMember]
        public int temp_min { get; set; }
        [DataMember]
        public int temp_max { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }
        [DataMember]
        public int deg { get; set; }
    }
    [DataContract]
    public class Sys
    {
        [DataMember]
        public string country { get; set; }
    }
    [DataContract]
    public class Clouds
    {
        [DataMember]
        public int all { get; set; }
    }
    [DataContract]
    public class Weather
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string main { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string icon { get; set; }
    }

    [DataContract]
    public class List
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Coord coord { get; set; }
        [DataMember]
        public Main main { get; set; }
        [DataMember]
        public int dt { get; set; }
        [DataMember]
        public Wind wind { get; set; }
        [DataMember]
        public Sys sys { get; set; }
        [DataMember]
        public object rain { get; set; }
        [DataMember]
        public object snow { get; set; }
        [DataMember]
        public Clouds clouds { get; set; }
        [DataMember]
        public List<Weather> weather { get; set; }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string cod { get; set; }
        [DataMember]
        public int count { get; set; }
        [DataMember]
        public List<List> list { get; set; }
        
        public string name { get; set; }

        public Main main { get; set; }

        public int temp { get; set; }
        [DataMember]
        public List<Weather> weather { get; set; }
    }
}
