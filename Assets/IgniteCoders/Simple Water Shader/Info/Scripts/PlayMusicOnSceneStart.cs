using UnityEngine;

public class PlayMusicOnSceneStart : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
    }

    public void PushButton()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}