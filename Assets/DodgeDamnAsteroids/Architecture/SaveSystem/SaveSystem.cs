using System.IO;
using System;
using UnityEngine;
using Newtonsoft.Json;

public class SaveSystem
{
    public static void SaveToFile(object data, string key)
    {
        string path = BuildPath(key);
        string json = JsonConvert.SerializeObject(data);

        using (var fileStream = new StreamWriter(path))
        {
            fileStream.Write(json);
        }
    }
    public static object LoadFromFile<T>(string key) 
    {
        string path = BuildPath(key);

        using (var fileStream = new StreamReader(path))
        {
            var json = fileStream.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T>(json);
            return data;
        }
    }
    private static string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
