using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    [SerializeField] private float obstaclesSpeed;
    public static float _obstaclesSpeed { get; private set; }

    private void Awake()
    {
        _obstaclesSpeed = obstaclesSpeed;
    }
}
