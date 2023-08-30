using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private List<PoolableObject> prefabs = new List<PoolableObject>();
    [SerializeField] private int poolLenght = 5;
    
    public static string asterTag => "Asteroid";
    public static string canisterTag => "Canister";
    public static string extingTag => "Exting";
    public static string heartTag => "Heart";

    private static Pool<PoolableObject> pool;
    private void Start()
    {
        pool = new Pool<PoolableObject> (prefabs, poolLenght);
    }
    public static PoolableObject GetObject(string tag)
    {
        return pool.GetObject(tag);
    }
}
