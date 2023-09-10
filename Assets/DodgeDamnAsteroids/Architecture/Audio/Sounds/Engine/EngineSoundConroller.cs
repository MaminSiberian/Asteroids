using UnityEngine;

public class EngineSoundConroller : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        ChangePan();
    }
    private void ChangePan()
    {
        audioSource.panStereo = transform.position.x * 0.35f;
    }
}
