using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    private AudioSource bgmSource;

    void Start()
    {
        bgmSource = GetComponent<AudioSource>();
        bgmSource.Play();
    }

    // This can be called from other scripts or using Unity's event system.
    public void StopMusic()
    {
        if (bgmSource.isPlaying)
        {
            bgmSource.Stop();
        }
    }
}
