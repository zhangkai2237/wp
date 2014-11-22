using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace PM25.Model
{
    public class AirModel
    {
        public int AQI { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string Area { get; set; }

        public string  PositionName { get; set; }

        public string StationCode { get; set; }

        public int  SO2 { get; set; }

        public int SO2_24H { get; set; }

        public int No2 { get; set; }

        public int No2_24H { get; set; }

        public int Pm10 { get; set; }

        public int Pm10_24H { get; set; }

        public int CO { get; set; }

        public int CO_24H { get; set; }

        public int O3 { get; set; }

        public int O3_24H { get; set; }

        public int O3_8H { get; set; }

        public int O3_8H_24H { get; set; }

        public int Pm25 { get; set; }

        public int Pm25_24H { get; set; }

        public string PrimaryPollutant { get; set; }

        public string Quality { get; set; }

        public DateTime TimePoint { get; set; }

        public static AirModel Parse(JToken json)
        {
            AirModel model = new AirModel();

            model.AQI = (int)json["aqi"];
            model.Area = (string)json["area"];
            model.CO = json["co"].ToIntValue();
            model.CO_24H = json["co_24h"].ToIntValue();
            model.No2 = json["no2"].ToIntValue();
            model.No2_24H = json["no2_24h"].ToIntValue();
            model.O3 = json["o3"].ToIntValue();
            model.O3_24H = json["o3_24h"].ToIntValue();
            model.O3_8H = json["o3_8h"].ToIntValue();
            model.O3_8H_24H = json["o3_8h_24h"].ToIntValue();
            model.Pm10 = json["pm10"].ToIntValue();
            model.Pm10_24H = json["pm10_24h"].ToIntValue();
            model.Pm25 = json["pm2_5"].ToIntValue();
            model.Pm25_24H = (int)json["pm2_5_24h"].ToIntValue();
            model.PositionName = (string)json["position_name"];
            model.PrimaryPollutant = (string)json["primary_pollutant"];
            model.Quality = (string)json["quality"];
            model.StationCode = (string)json["station_code"];
            model.TimePoint = (DateTime)json["time_point"];

            return model;
        }

    }

    public static class CommonTool
    {
        public static int ToIntValue<T>(this T value)
        {
            int returnValue = 0;
            try
            {
                returnValue = int.Parse(value.ToString());
            }
            catch
            {
                returnValue = 0;
            }
            return returnValue;
        }

        public static string ToStringValue(this int value)
        {
            if (value == 0)
            {
                return "--";
            }
            return value.ToString();
        }

        public static string ToJSON(this object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                //return Encoding.Default.GetString(ms.ToArray());
                return Encoding.UTF8.GetString(ms.ToArray(), 0, ms.Length.ToIntValue());
            }
        }

        public static T ParseJSON<T>(this string str)
        {
            T obj = Activator.CreateInstance<T>();
            //using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(str)))
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

    }
}
