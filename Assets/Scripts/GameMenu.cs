using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public string menuMainScene="menu";
    public Text MuteText;
    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(AudioManager.instance.bgm[0].mute){
            MuteText.text = "UnMute";
        } else {
            MuteText.text = "Mute";
        }
       
	}
    public void ReturnMenu()
    {
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene(menuMainScene);
    }
    public void Mute()
    {
        AudioManager.instance.Mute();
    }

    public void Cancel()
    {
        gameObject.SetActive(false);
    }
}
