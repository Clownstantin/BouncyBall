using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;

    private AudioSource _audio;

    private void Awake() => _audio = GetComponent<AudioSource>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip randomClip = _clips[Random.Range(0, _clips.Length)];
        _audio.PlayOneShot(randomClip);
    }
}
