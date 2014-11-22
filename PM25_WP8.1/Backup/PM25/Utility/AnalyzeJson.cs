using Newtonsoft.Json.Linq;
using PM25.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.IO.IsolatedStorage;
using System.IO;

namespace PM25.Utility
{
    public class AnalyzeJson
    {
        public static List<AirModel> JsonToEntityList(string jsonStr)
        {

            List<AirModel> entityList = new List<AirModel>();
            if (!string.IsNullOrEmpty(jsonStr))
            {
                try
                {
                    JArray jsonList = JArray.Parse(jsonStr);
                    AirModel entity = null;
                    foreach (JToken jToken in jsonList)
                    {
                        entity = AirModel.Parse(jToken);
                        entityList.Add(entity);
                    }
                }
                catch(Exception ex) { return entityList; }
            }
            return entityList;
        }

        #region 保存和读取数据
        public static void Save(string jsonList, string fileName)
        {
            using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoFile.FileExists(fileName))
                {
                    FileStream fileStream = isoFile.CreateFile(fileName);
                    fileStream.Close();
                }

                using (IsolatedStorageFileStream isoFileStream = isoFile.OpenFile(fileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    StreamWriter streamWriter = new StreamWriter(isoFileStream);
                    
                    streamWriter.Write(jsonList);
                    streamWriter.Close();//very importent
                }
            }
        }

        public static string Read(string fileName)
        {
            using (IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoFile.FileExists(fileName))
                {
                    return null;
                }
                using (IsolatedStorageFileStream isoFileStream = isoFile.OpenFile(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    //List<AirModel> entityList = new List<AirModel>();
                    StreamReader streamReader = new StreamReader(isoFileStream);
                    string jsonStr = streamReader.ReadToEnd().ToString();
                    streamReader.Close();
                    return jsonStr;
                }
            }
        }
        #endregion
    }
}
