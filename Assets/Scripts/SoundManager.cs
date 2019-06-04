using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager Instance;

    private AudioSource audioSource;

    public AudioClip clickSound;
    public AudioClip closeSound;
	// Use this for initialization
	void Start () {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
	
    public void PlayClickSound()
    {
        if (audioSource == null) return;
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clickSound);
        }

    }
}
