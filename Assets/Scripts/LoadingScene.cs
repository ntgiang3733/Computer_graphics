using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {
    public float waitToLoad;

	// Use this for initialization
	void Start () {
		UIFade.instance.FadeFromBlack();
	}
	
	// Update is called once per frame
	void Update () {
        
		if(waitToLoad > 0)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                SceneManager.LoadScene(GameManager.gameManager.current_screen);
            }
        }
	}
}
