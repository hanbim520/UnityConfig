/// <summary> 
/// ListStringData
/// 作者：NavyZhang 
/// 日期：2018-06-01 
/// </summary> 
using System.Collections.Generic;

namespace GameConfig
{
    public class JsonListConfig
    {
        public List<string> ListStringData { get; set; }

        public void SetListStringData(string data, bool needRepeat = false)
        {
            if (ListStringData.Contains(data) && !needRepeat)
            {
                UnityEngine.Debug.LogWarning("数据不能重复，若需要重复请开启");
                return;
            }
            ListStringData.Add(data);
        }

        public List<string> GetListStringData()
        {
            return ListStringData;
        }

        public void RemoveData(string value)
        {
            if (ListStringData.Contains(value))
                ListStringData.Remove(value);
        }
    }

}
