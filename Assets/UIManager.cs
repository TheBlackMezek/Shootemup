using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreText;
    public Text healthText;

    public PlayerController player;


	
	void Start () {
        StaticStuff.OnScoreChange = UpdateScoreText;
        StaticStuff.score = 0;

        StaticStuff.OnHealthChange = UpdateHealthText;
	}
	
	public void UpdateScoreText()
    {
        scoreText.text = "Score: " + StaticStuff.score.ToString();
    }

    public void UpdateHealthText()
    {
        healthText.text = "HP: " + player.Health.ToString();
    }

}
