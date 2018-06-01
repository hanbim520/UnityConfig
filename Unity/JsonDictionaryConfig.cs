/// <summary> 
/// JsonDictionaryConfig
/// 作者：NavyZhang 
/// 日期：2018-06-01 
/// </summary> 
using System.Collections.Generic;

namespace GameConfig
{
    public class JsonDictionaryConfig
    {
        public Dictionary<string, string> DictionaryStringData { get; set; }

        public void SetDictionaryStringData(string key, string value)
        {
            if (DictionaryStringData.ContainsKey(key))
                DictionaryStringData[key] = value;
            else
                DictionaryStringData.Add(key, value);
        }

        public Dictionary<string, string> GetDictionaryStringData()
        {
            return DictionaryStringData;
        }

        public void RemoveData(string key)
        {
            if (DictionaryStringData.ContainsKey(key))
                DictionaryStringData.Remove(key);
        }
    }
}
