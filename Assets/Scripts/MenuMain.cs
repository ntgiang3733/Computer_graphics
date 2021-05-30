using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour {

    public string newGameScene;
    public string loadingScene="LoadingScene";
    public float waitToLoad=1;

    public GameObject easyModeButton;
    public GameObject hardModeButton;
    public GameObject newGameButton;
    public GameObject exitButton;
    public GameObject returnButton;

    public GameManager gameManager;
    private bool shouldLoadAfterFade;

    public bool chooseMode = false;

    void Awake()
    {         
        

    }

	// Use this for initialization
	void Start () {
		gameManager = GameManager.gameManager;
	}
	
	// Update is called once per frame
	void Update () {
        if(!chooseMode){
            newGameButton.SetActive(true);
            exitButton.SetActive(true);
            hardModeButton.SetActive(false);
            easyModeButton.SetActive(false);
            returnButton.SetActive(false);
        } else {
            newGameButton.SetActive(false);
            exitButton.SetActive(false);
            hardModeButton.SetActive(true);
            easyModeButton.SetActive(true);
            returnButton.SetActive(true);
            
        }

        if(shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                AudioManager.instance.StopMusic();
                SceneManager.LoadScene(loadingScene);
            }
        }
		
	}

    public void NewGame()
    {   
        chooseMode = true;
        gameManager.current_screen="";
        AudioManager.instance.PlaySFX(3);
    }
    public void Return()
    {
        chooseMode = false;
        AudioManager.instance.PlaySFX(3);
    }

    public void Exit()
    {
        Application.Quit();
        AudioManager.instance.PlaySFX(3);
    }
    public void EasyMode()
    {
        setEasyMode();
        gameManager.mode="Easy";
        gameManager.current_screen=newGameScene;
        shouldLoadAfterFade = true;
        AudioManager.instance.PlaySFX(3);

        UIFade.instance.FadeToBlack();

    }
    public void HardMode()
    {
        setHardMode();
        gameManager.mode="Hard";
        AudioManager.instance.PlaySFX(3);
        
        gameManager.current_screen=newGameScene;
        shouldLoadAfterFade = true;
        UIFade.instance.FadeToBlack();
    }

    public void setEasyMode(){
        gameManager.health = 10;
        gameManager.damage = 30;
        gameManager.bullets = 10;
        gameManager.bombs = 5;
        gameManager.upgradeCost = 10;
        gameManager.fireRate = 0.3f;
    }
    public void setHardMode(){
        gameManager.health = 5;
        gameManager.damage = 1;
        gameManager.bullets = 6;
        gameManager.bombs = 2;
        gameManager.fireRate = 0.5f;
        gameManager.upgradeCost = 12;
    }
}
