/// <summary> 
/// SavingConfig
/// 作者：NavyZhang 
/// 日期：2018-06-01 
/// </summary> 
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System;

namespace GameConfig
{
    public class SavingConfig
    {

        public static SavingConfig Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
            internal static readonly SavingConfig instance = new SavingConfig();
        }

        public void SetSelfDefineType<T>(string key, T jsonConfig)
        {
            key = key.Trim();
            string json_data = JsonMapper.ToJson(jsonConfig);
            PlayerPrefs.SetString(key + MD5Helper.HashString("self"), json_data);
        }
        public T GetSelfDefineType<T>(string key)
        {
            key = key.Trim();
            string stringDictionaryJsonData = PlayerPrefs.GetString(key + MD5Helper.HashString("self"), "");
            if (stringDictionaryJsonData != "")
            {
                T jsonConfig = JsonMapper.ToObject<T>(stringDictionaryJsonData);
                return jsonConfig;
            }
            return default(T);
        }

        public void RemoveSelfDefineTypeData(string key)
        {
            PlayerPrefs.DeleteKey(key.Trim() + MD5Helper.HashString("self"));
        }

        private void CheckListNull(JsonListConfig jsonConfig)
        {
            if (jsonConfig.ListStringData == null)
                jsonConfig.ListStringData = new List<string>();

        }

        private void CheckDictionaryNull(JsonDictionaryConfig jsonConfig)
        {
            if (jsonConfig.DictionaryStringData == null)
                jsonConfig.DictionaryStringData = new Dictionary<string, string>();

        }

        public void SetStringDictionaryData(string key, string DicKey, string DicValue)
        {
            try
            {
                key = key.Trim();
                DicKey = DicKey.Trim();
                JsonDictionaryConfig jsonConfig = null;
                string stringDictionaryJsonData = PlayerPrefs.GetString(key + MD5Helper.HashString("Dictionary"), "");
                if (stringDictionaryJsonData != "")
                {
                    jsonConfig = JsonMapper.ToObject<JsonDictionaryConfig>(stringDictionaryJsonData);
                }
                else
                {
                    jsonConfig = new JsonDictionaryConfig();
                }

                CheckDictionaryNull(jsonConfig);
                jsonConfig.SetDictionaryStringData(DicKey, DicValue);
                string json_data = JsonMapper.ToJson(jsonConfig);
                PlayerPrefs.SetString(key + MD5Helper.HashString("Dictionary"), json_data);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.ToString());
            }
        }

        public void SetStringDictionaryData(string key, Dictionary<string, string> values)
        {
            try
            {
                key = key.Trim();
                JsonDictionaryConfig jsonConfig = null;
                string stringDictionaryJsonData = PlayerPrefs.GetString(key + MD5Helper.HashString("Dictionary"), "");
                if (stringDictionaryJsonData != "")
                {
                    jsonConfig = JsonMapper.ToObject<JsonDictionaryConfig>(stringDictionaryJsonData);
                }
                else
                {
                    jsonConfig = new JsonDictionaryConfig();
                }

                CheckDictionaryNull(jsonConfig);
                foreach (KeyValuePair<string, string> item in values)
                {
                    jsonConfig.SetDictionaryStringData(item.Key, item.Value);
                }

                string json_data = JsonMapper.ToJson(jsonConfig);
                PlayerPrefs.SetString(key + MD5Helper.HashString("Dictionary"), json_data);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.ToString());
            }
        }

        public Dictionary<string, string> GetStringDictionaryData(string key)
        {
            key = key.Trim();
            string stringDictionaryJsonData = PlayerPrefs.GetString(key + MD5Helper.HashString("Dictionary"), "");
            if (stringDictionaryJsonData != "")
            {
                JsonDictionaryConfig jsondata = JsonMapper.ToObject<JsonDictionaryConfig>(stringDictionaryJsonData);
                return jsondata.GetDictionaryStringData();
            }
            return new Dictionary<string, string>();
        }

        public void RemoveStringDictionaryData(string key)
        {
            PlayerPrefs.DeleteKey(key.Trim());
        }
        public void RemoveStringDictionaryData(string key, string DicKey)
        {
            key = key.Trim();
            string stringDictionaryJsonData = PlayerPrefs.GetString(key + MD5Helper.HashString("Dictionary"), "");
            if (stringDictionaryJsonData != "")
            {
                JsonDictionaryConfig jsondata = JsonMapper.ToObject<JsonDictionaryConfig>(stringDictionaryJsonData);
                jsondata.RemoveData(DicKey);
                string json_data = JsonMapper.ToJson(jsondata);
                PlayerPrefs.SetString(key + MD5Helper.HashString("Dictionary"), json_data);
            }
        }

        public void SetStringListData(string key, string value)
        {
            try
            {
                key = key.Trim();
                value = value.Trim();
                JsonListConfig jsonConfig = null;
                string stringListJsonData = PlayerPrefs.GetString(key + MD5Helper.HashString("list"), "");
                if (stringListJsonData != "")
                {
                    jsonConfig = JsonMapper.ToObject<JsonListConfig>(stringListJsonData);
                }
                else
                {
                    jsonConfig = new JsonListConfig();
                }

                CheckListNull(jsonConfig);
                jsonConfig.SetListStringData(value);
                string json_data = JsonMapper.ToJson(jsonConfig);
                PlayerPrefs.SetString(key + MD5Helper.HashString("list"), json_data);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.ToString());
            }

        }



        public void SetStringListData(string key, List<string> values)
        {
            try
            {
                key = key.Trim();
                JsonListConfig jsonConfig = null;
                string stringListJsonData = PlayerPrefs.GetString(key + MD5Helper.HashString("list"), "");
                if (stringListJsonData != "")
                {
                    jsonConfig = JsonMapper.ToObject<JsonListConfig>(stringListJsonData);
                }
                else
                {
                    jsonConfig = new JsonListConfig();
                }

                CheckListNull(jsonConfig);
                for (int i = 0; i < values.Count; ++i)
                    jsonConfig.SetListStringData(values[i].Trim());
                string json_data = JsonMapper.ToJson(jsonConfig);
                PlayerPrefs.SetString(key + MD5Helper.HashString("list"), json_data);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.ToString());
            }
        }

        public List<string> GetStringListData(string key)
        {
            key = key.Trim();
            string stringListJsonData = PlayerPrefs.GetString(key + MD5Helper.HashString("list"), "");
            if (stringListJsonData != "")
            {
                JsonListConfig jsondata = JsonMapper.ToObject<JsonListConfig>(stringListJsonData);
                return jsondata.GetListStringData();
            }
            return new List<string>();
        }

        public void RemoveStringListDataByKey(string key)
        {
            key = key.Trim();
            PlayerPrefs.DeleteKey(key + MD5Helper.HashString("list"));

        }

        public void RemoveStringListData(string key, string value)
        {
            key = key.Trim();
            value = value.Trim();
            string stringListJsonData = PlayerPrefs.GetString(key + MD5Helper.HashString("list"), "");
            if (stringListJsonData != "")
            {
                JsonListConfig jsondata = JsonMapper.ToObject<JsonListConfig>(stringListJsonData);
                jsondata.RemoveData(value);
                string json_data = JsonMapper.ToJson(jsondata);
                PlayerPrefs.SetString(key + MD5Helper.HashString("list"), json_data);
            }

        }



        public void SetIntData(string key, int value)
        {
            PlayerPrefs.SetInt(key.Trim(), value);

        }
        public void RemoveIntData(string key)
        {
            PlayerPrefs.DeleteKey(key.Trim());
        }

        public int GetIntData(string key)
        {
            return PlayerPrefs.GetInt(key.Trim(), 0);
        }
        public void SetBoolData(string key, bool value)
        {
            if (value)
                PlayerPrefs.SetInt(key.Trim(), 1);
            else
                PlayerPrefs.SetInt(key.Trim(), 0);
        }

        public bool GetBoolData(string key)
        {
            int value = PlayerPrefs.GetInt(key.Trim(), 0);
            if (value == 1)
                return true;
            else
                return false;

        }
        public void RemoveBoolData(string key)
        {
            PlayerPrefs.DeleteKey(key.Trim());
        }
        public void SetStringData(string key, string value)
        {
            PlayerPrefs.SetString(key.Trim(), value.Trim());
        }

        public string GetStringData(string key)
        {
            return PlayerPrefs.GetString(key.Trim(), "");
        }

        public void RemoveStringData(string key)
        {
            PlayerPrefs.DeleteKey(key.Trim());
        }

        public void SetFloatData(string key, float value)
        {
            PlayerPrefs.SetFloat(key.Trim(), value);
        }
        public float GetFloatData(string key)
        {
            return PlayerPrefs.GetFloat(key.Trim(), 0f);
        }
        public void RemoveFloatData(string key)
        {
            PlayerPrefs.DeleteKey(key.Trim());
        }
        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }

}
