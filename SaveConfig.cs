using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;

namespace SDGame
{
    public class SaveConfig : Singleton<SaveConfig>
    {
        private static readonly string FILE_NAME = "GameConfig.txt";
       
        // Use this for initialization
        public override void Init() 
        {
            base.Init();
        }

        private void CheckNull(JsonConfig jsonConfig)
        {
            if (jsonConfig._configBoolDic == null)
                jsonConfig._configBoolDic = new Dictionary<string, bool>();
            if (jsonConfig._configIntDic == null)
                jsonConfig._configIntDic = new Dictionary<string, int>();
            if (jsonConfig._configStringDic == null)
                jsonConfig._configStringDic = new Dictionary<string, string>();
            if (jsonConfig._configStringListDic == null)
                jsonConfig._configStringListDic = new Dictionary<string, List<string>>();
        }



        private bool CheckFileExists(string path,string name)
        {
            if (!File.Exists(path + "/" + name))
            {
                return false;
            }
            return true;
        }
        public void SetStringListData(string key, string value)
        {
            try
            {
                JsonConfig jsonConfig = null;
                if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
                {
                    string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                    jsonConfig = JsonMapper.ToObject<JsonConfig>(file);
                }else
                {
                    jsonConfig = new JsonConfig();
                }
               
                CheckNull(jsonConfig);
                jsonConfig.SetStringListData(key, value);
                DeleteFile(Application.persistentDataPath , FILE_NAME);
                string json_data = JsonMapper.ToJson(jsonConfig);
                CreateFile(Application.persistentDataPath, FILE_NAME, json_data);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.ToString());
            }
           
        }

        public List<string> GetStringListData(string key)
        {
            if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
            {
                string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                JsonConfig jsondata = JsonMapper.ToObject<JsonConfig>(file);
                return jsondata.GetStringListData(key);
            }
            return new List<string>();
        }

        public void RemoveStringListDataByKey(string key )
        {
            if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
            {
                string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                JsonConfig jsondata = JsonMapper.ToObject<JsonConfig>(file);
                jsondata.RemoveStringListDataByKey(key);
                DeleteFile(Application.persistentDataPath, FILE_NAME);
                string json_data = JsonMapper.ToJson(jsondata);
                CreateFile(Application.persistentDataPath, FILE_NAME, json_data);
            }

        }

        public void RemoveStringListData(string key,string value)
        {
            if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
            {
                string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                JsonConfig jsondata = JsonMapper.ToObject<JsonConfig>(file);
                jsondata.RemoveStringListData(key, value);
                DeleteFile(Application.persistentDataPath, FILE_NAME);
                string json_data = JsonMapper.ToJson(jsondata);
                CreateFile(Application.persistentDataPath, FILE_NAME, json_data);
            }

        }

        public void SetIntData(string key, int value)
        {
            try
            {
                JsonConfig jsonConfig = null;
                if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
                {
                    string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                    jsonConfig = JsonMapper.ToObject<JsonConfig>(file);
                }
                else
                {
                    jsonConfig = new JsonConfig();
                }
                CheckNull(jsonConfig);
                jsonConfig.SetIntData(key, value);
                DeleteFile(Application.persistentDataPath, FILE_NAME);
                string json_data = JsonMapper.ToJson(jsonConfig);
                CreateFile(Application.persistentDataPath, FILE_NAME, json_data);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.ToString());
            }
            
        }
        public void RemoveIntData(string key)
        {
            if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
            {
                string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                JsonConfig jsondata = JsonMapper.ToObject<JsonConfig>(file);
                jsondata.RemoveIntData(key);
                DeleteFile(Application.persistentDataPath, FILE_NAME);
                string json_data = JsonMapper.ToJson(jsondata);
                CreateFile(Application.persistentDataPath, FILE_NAME, json_data);
            }

        }

        public int GetIntData(string key)
        {
            if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
            {
                string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                JsonConfig jsondata = JsonMapper.ToObject<JsonConfig>(file);
                return jsondata.GetIntData(key);
            }else
            {
                return 0;
            }
               
        }
        public void SetBoolData(string key, bool value)
        {
            try
            {
                JsonConfig jsonConfig = null;
                if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
                {
                    string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                    jsonConfig = JsonMapper.ToObject<JsonConfig>(file);
                }
                else
                {
                    jsonConfig = new JsonConfig();
                }
                CheckNull(jsonConfig);
                jsonConfig.SetBoolData(key, value);
                DeleteFile(Application.persistentDataPath, FILE_NAME);
                string json_data = JsonMapper.ToJson(jsonConfig);
                CreateFile(Application.persistentDataPath, FILE_NAME, json_data);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.ToString());
            }
        }

        public bool GetBoolData(string key)
        {
            if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
            {
                string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                JsonConfig jsondata = JsonMapper.ToObject<JsonConfig>(file);
                return jsondata.GetBoolData(key);
            }else
            {
                return false;
            }
                
        }
        public void RemoveBoolData(string key)
        {
            if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
            {
                string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                JsonConfig jsondata = JsonMapper.ToObject<JsonConfig>(file);
                jsondata.RemoveBoolData(key);
                DeleteFile(Application.persistentDataPath, FILE_NAME);
                string json_data = JsonMapper.ToJson(jsondata);
                CreateFile(Application.persistentDataPath, FILE_NAME, json_data);
            }
        }
        public void SetStringData(string key, string value)
        {
            try
            {
                JsonConfig jsonConfig = null;
                if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
                {
                    string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                    jsonConfig = JsonMapper.ToObject<JsonConfig>(file);
                }
                else
                {
                    jsonConfig = new JsonConfig();
                }
                CheckNull(jsonConfig);
                jsonConfig.SetStringData(key, value);
                DeleteFile(Application.persistentDataPath, FILE_NAME);
                string json_data = JsonMapper.ToJson(jsonConfig);
                CreateFile(Application.persistentDataPath, FILE_NAME, json_data);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError(ex.ToString());
            }
        }

        public string GetStringData(string key)
        {
            if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
            {
                string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                JsonConfig jsondata = JsonMapper.ToObject<JsonConfig>(file);
                return jsondata.GetStringData(key);
            }else
            {
                return "";
            }
                
        }

        public void RemoveStringData(string key)
        {
            if (CheckFileExists(Application.persistentDataPath, FILE_NAME))
            {
                string file = LoadFile(Application.persistentDataPath, FILE_NAME);
                JsonConfig jsondata = JsonMapper.ToObject<JsonConfig>(file);
                jsondata.RemoveStringData(key);
                DeleteFile(Application.persistentDataPath, FILE_NAME);
                string json_data = JsonMapper.ToJson(jsondata);
                CreateFile(Application.persistentDataPath, FILE_NAME, json_data);
            }
        }
        private  void CreateFile(string path, string name, string info)
        {
            StreamWriter sw;
            FileInfo t = new FileInfo(path + "/" + name);
            if (!t.Exists)
            {
                sw = t.CreateText();
            }
            else
            {
                sw = t.AppendText();
            }
            sw.WriteLine(info);
            sw.Close();
            sw.Dispose();
        }

        private string LoadFile(string path, string name)
        {
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(path + "/" + name);
            }
            catch (Exception e)
            {
                return null;
            }
            string content;
            content = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            return content;
        }

        private void DeleteFile(string path, string name)
        {
            File.Delete(path + "/" + name);

        }
      
    }

}
