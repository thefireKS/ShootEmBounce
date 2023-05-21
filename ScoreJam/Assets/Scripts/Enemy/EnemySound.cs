using UnityEngine;

public class EnemySound : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(!_audioSource.isPlaying) _audioSource.Play();
    }
}
