using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private List<Object> prefabs = new List<Object>();
    [SerializeField] private int poolLenght = 5;

    private static Pool<Object> pool;
    private void Start()
    {
        pool = new Pool<Object> (prefabs, poolLenght);
    }
    public static Object GetObject(string tag)
    {
        return pool.GetObject(tag);
    }
}
