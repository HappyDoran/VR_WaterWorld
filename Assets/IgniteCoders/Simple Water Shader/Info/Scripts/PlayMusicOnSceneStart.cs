using UnityEngine;

public class PlayMusicOnSceneStart : MonoBehaviour
{
    public AudioClip musicClip; // 재생할 노래 클립
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();

        // 노래 클립 설정
        audioSource.clip = musicClip;

        // 노래 재생
        audioSource.Play();
    }
}
