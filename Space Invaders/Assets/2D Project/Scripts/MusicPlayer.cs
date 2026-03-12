using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public AudioClip music;

    private AudioSource sound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        sound.PlayOneShot(music, 0.6f);
    }
}
