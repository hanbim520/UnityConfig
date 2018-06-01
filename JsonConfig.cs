/// <summary> 
/// JsonConfig
/// 作者：NavyZhang 
/// 日期：2018-06-01 
/// </summary> 
using System.Collections;
using System.Collections.Generic;

namespace SDGame
{
    public class JsonConfig
    {
        //     private Dictionary<string, List<string>> _configStringListDic = new Dictionary<string, List<string>>();
        //     private Dictionary<string, int> _configIntDic = new Dictionary<string, int>();
        //     private Dictionary<string, bool> _configBoolDic = new Dictionary<string, bool>();
        //     private Dictionary<string, string> _configStringDic = new Dictionary<string, string>();
        public Dictionary<string, List<string>> _configStringListDic { get; set; }
        public Dictionary<string, int> _configIntDic { get; set; }
        public Dictionary<string, bool> _configBoolDic { get; set; }
        public Dictionary<string, string> _configStringDic { get; set; }

        public void SetStringListData(string key, string value)
        {
            List<string> content = null;
            if (_configStringListDic.TryGetValue(key, out content))
            {
                if (!content.Contains(value))
                    content.Add(value);
            }
            else
            {
                List<string> values = new List<string>();
                values.Add(value);
                _configStringListDic.Add(key, values);
            }
        }

        public List<string> GetStringListData(string key)
        {
            List<string> content = null;
            if (_configStringListDic.TryGetValue(key, out content))
            {
                return content;
            }
            return new List<string>();
        }

        public void RemoveStringListDataByKey(string key)
        {
            if (_configStringListDic.ContainsKey(key))
                _configStringListDic.Remove(key);
        }

        public void RemoveStringListData(string key, string value)
        {
            if (!_configStringListDic.ContainsKey(key))
                return;
            List<string> contents = _configStringListDic[key];
            if (contents.Contains(value))
                contents.Remove(value);
        }

        public void SetIntData(string key, int value)
        {
            if (_configIntDic.ContainsKey(key))
            {
                _configIntDic[key] = value;
            }
            else
            {
                _configIntDic.Add(key, value);
            }
        }
        public int GetIntData(string key)
        {
            if (_configIntDic.ContainsKey(key))
            {
                return _configIntDic[key];
            }
            return 0;
        }

        public void RemoveIntData(string key)
        {
            if (_configIntDic.ContainsKey(key))
            {
                _configIntDic.Remove(key);
            }
        }

        public void SetBoolData(string key, bool value)
        {
            if (_configBoolDic.ContainsKey(key))
            {
                _configBoolDic[key] = value;
            }
            else
            {
                _configBoolDic.Add(key, value);
            }
        }

        public void RemoveBoolData(string key)
        {
            if (_configBoolDic.ContainsKey(key))
            {
                _configBoolDic.Remove(key);
            }
        }
        public bool GetBoolData(string key)
        {
            if (_configBoolDic.ContainsKey(key))
            {
                return _configBoolDic[key];
            }
            return false;
        }
        public void SetStringData(string key, string value)
        {
            if (_configStringDic.ContainsKey(key))
            {
                _configStringDic[key] = value;
            }
            else
            {
                _configStringDic.Add(key, value);
            }
        }
        public string GetStringData(string key)
        {
            if (_configStringDic.ContainsKey(key))
            {
                return _configStringDic[key];
            }
            return "";
        }

        public void RemoveStringData(string key)
        {
            if (_configStringDic.ContainsKey(key))
            {
                _configStringDic.Remove(key);
            }
        }
    }

}
