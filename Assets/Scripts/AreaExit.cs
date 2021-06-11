using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour {

    public string areaToLoad;

    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if(shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                GameManager.gameManager.current_screen=areaToLoad;
                AudioManager.instance.StopMusic();
                SceneManager.LoadScene("LoadingScene");
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack();
        }
    }
}
