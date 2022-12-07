using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public static PlayerSFX instance;
    private AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlaySFX(int soundClip)
    {
        audioSource.PlayOneShot(audioClips[soundClip]);
    }
}
