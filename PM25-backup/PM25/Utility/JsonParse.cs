using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace PM25.Utility
{
    class JsonParse
    {
        public static T Parse<T>(Stream stream)
        {
            return JsonParse._parse<T>(stream);
        }

        //从Json串解析
        private static T _parse<T>(Stream stream)
        {
            return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(stream);
        }

        //将某个序列类合并成Json串,参见:htt p://m s dn.microsoft.com/en-us/library/bb908432(v=VS.96).aspx
        public static string constructJsonString(object jsonObject)
        {
            using (var ms = new MemoryStream())
            {
                new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);
                byte[] byteArr = ms.ToArray();
                return Encoding.UTF8.GetString(byteArr, 0, byteArr.Length);
            }
        }
    }
}
