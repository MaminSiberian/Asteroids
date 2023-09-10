using System.IO;
using System;
using UnityEngine;
using Newtonsoft.Json;

public class SaveSystem
{
    private const string DATA_KEY = "Data.json";

    public static void SaveToFile(object data)
    {
        string path = BuildPath(DATA_KEY);
        string json = JsonConvert.SerializeObject(data);

        if (!File.Exists(path)) File.Create(path);
        
        File.WriteAllText(path, json);

    }
    public static object LoadFromFile<T>() 
    {
        string path = BuildPath(DATA_KEY);

        if (!File.Exists(path)) File.Create(path);

        var json = File.ReadAllText(path);
        var data = JsonConvert.DeserializeObject<T>(json);
        return data;
    }
    private static string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
