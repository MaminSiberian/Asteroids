using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private List<Transform> _spawnPositions = new List<Transform>(4);
    public static List<Transform> spawnPositions;
    [Header("Asteroids")]
    [SerializeField] private int asterStartSpawnChance;
    [SerializeField] private float asterSpawnIncreaseStep;
    [Header("Extinguishers")]
    [SerializeField] private int extingStartSpawnChance;
    [SerializeField] private float extingSpawnIncreaseStep;
    [Header("Fuel")]
    [SerializeField] private int canisterStartSpawnChance;
    [SerializeField] private float canisterSpawnIncreaseStep;
    [Header("Hearts")]
    [SerializeField] private int heartStartSpawnChance;
    [SerializeField] private float heartSpawnIncreaseStep;

    private string asterTag = "Asteroid";
    private string canisterTag = "Canister";
    private string extingTag = "Exting";
    private string heartTag = "Heart";

    private float asterSpawnChance; 
    private float canisterSpawnChance;
    private float extingSpawnChance;
    private float heartSpawnChance;

    private float timer = 0f;
    private int maxSpawnChance = 90;
    private int criticHealthValue = 3;

    private void Awake()
    {
        spawnPositions = _spawnPositions;
        asterSpawnChance = asterStartSpawnChance;
        canisterSpawnChance = canisterStartSpawnChance;
        extingSpawnChance = extingStartSpawnChance;
        heartSpawnChance = heartStartSpawnChance;
    }
    private void Update()
    {
        SetSpawnTimer();
    }
    private void SetSpawnTimer()
    {
        if (timer >= spawnRate)
        {
            SpawnRandomObjects();
            timer -= spawnRate;
        }
        else
            timer += Time.deltaTime;
    }
    private void SpawnRandomObjects()
    {
        if (PlayerFire.isOnFire && Random.Range(0, 100) <= extingSpawnChance)
        {
            SpawnExting();
            return;
        }
        if (Random.Range(0, 100) <= canisterSpawnChance)
        {
            SpawnCanister();
            return;
        }
        if (PlayerHealth.healthValue < criticHealthValue && Random.Range(0, 100) <= heartSpawnChance)
        {
            SpawnHeart();
            return;
        }
        if (Random.Range(0, 100) <= asterSpawnChance)
        {
            SpawnAsteroids();
            return;
        }
    }
    private Object SpawnObject(string tag, Transform pos)
    {
        var obj = PoolManager.GetObject(tag);
        obj.transform.position = pos.position;

        return obj;
    }
    private List<Transform> GetRandomPositions(int numberOfPositions = 1)
    {
        System.Random random = new System.Random();
        List<Transform> positions = spawnPositions.OrderBy(x => random.Next()).Take(numberOfPositions).ToList();
        return positions;
    }
    private void IncreaseSpawnChances()
    {
        if (asterSpawnChance <= maxSpawnChance) asterSpawnChance += asterSpawnIncreaseStep;

        if (canisterSpawnChance <= maxSpawnChance) canisterSpawnChance += canisterSpawnIncreaseStep;

        if (extingSpawnChance <= maxSpawnChance && PlayerFire.isOnFire) 
            extingSpawnChance += extingSpawnIncreaseStep;
        if (heartSpawnChance <= maxSpawnChance && PlayerHealth.healthValue < criticHealthValue) 
            heartSpawnChance += heartSpawnIncreaseStep;
    }
    private void SpawnAsteroids()
    {
        GetRandomPositions(Random.Range(0, 4)).ForEach(p => SpawnObject(asterTag, p));
        IncreaseSpawnChances();
        asterSpawnChance = asterStartSpawnChance;
    }
    private void SpawnExting()
    {
        GetRandomPositions(1).ForEach(p => SpawnObject(extingTag, p));
        IncreaseSpawnChances();
        extingSpawnChance = extingStartSpawnChance;
    }
    private void SpawnCanister()
    {
        GetRandomPositions(1).ForEach(p => SpawnObject(canisterTag, p));
        IncreaseSpawnChances();
        canisterSpawnChance = canisterStartSpawnChance;
    }
    private void SpawnHeart()
    {
        GetRandomPositions(1).ForEach(p => SpawnObject(heartTag, p));
        IncreaseSpawnChances();
        heartSpawnChance = heartStartSpawnChance;
    }
}
