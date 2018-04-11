using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public string gameScene = "MainScene";

    public void SwitchToGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }

}
