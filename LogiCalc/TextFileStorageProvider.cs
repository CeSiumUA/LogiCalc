using LogiCalc.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCalc
{
    public class TextFileStorageProvider : IStorageProvider
    {
        private readonly string fileName;
        public TextFileStorageProvider(string fileName = "storage.json")
        {
            this.fileName = fileName;
        }

        public T Load<T>()
        {
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    var rawText = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(rawText);
                }
            }
            return default;
        }

        public void Save<T>(T obj)
        {
            var jsonText = JsonConvert.SerializeObject(obj);
            File.WriteAllText(this.fileName, jsonText);
        }
    }
}
