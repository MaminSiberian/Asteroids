using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _click;

    private static AudioSource click;

    private void Start()
    {
        click = _click;
    }
    public static void PlayClickSound()
    {
        click.Play();
    }
}
