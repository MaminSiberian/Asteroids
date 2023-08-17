using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<float> spawnPositionsX = new List<float>();
    [SerializeField] private float spawnPositionY;

    [SerializeField] private int asterSpawnChancePercent;
    [SerializeField] private int canisterSpawnChancePercent;
    [SerializeField] private int extingSpawnChancePercent;
    [SerializeField] private int heartSpawnChancePercent;

    private string asterTag = "Asteroid";
    private string canisterTag = "Canister";
    private string extingTag = "Exting";
    private string heartTag = "Heart";

    private Object SpawnAsteroid(float posX)
    {
        var obj = PoolManager.GetObject(asterTag);
        obj.transform.position = new Vector2(posX, spawnPositionY);

        return obj;
    }


}
