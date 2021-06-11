using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource[] sfx;
    public AudioSource[] bgm;

    public static AudioManager instance;

    // Use this for initialization
    void Start () {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void PlaySFX(int soundToPlay)
    {
        if (soundToPlay < sfx.Length)
        {
            sfx[soundToPlay].Play();
        }
    }

    public void PlayBGM(int musicToPlay)
    {
        if (!bgm[musicToPlay].isPlaying)
        {
            StopMusic();

            if (musicToPlay < bgm.Length)
            {
                bgm[musicToPlay].Play();
            }
        }
    }

    public void StopMusic()
    {
        for(int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
    public void Mute(){
        for(int i = 0; i < bgm.Length; i++)
        {
            bgm[i].mute=!bgm[i].mute;
        
        }
        for(int i = 0; i < sfx.Length; i++)
        {
            
            sfx[i].mute=!sfx[i].mute;
        }
    }
}
