using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{  
    public string menuMainScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitToMain()
    {
        AudioManager.instance.StopMusic();
        SceneManager.LoadScene(menuMainScene);
    }
}
