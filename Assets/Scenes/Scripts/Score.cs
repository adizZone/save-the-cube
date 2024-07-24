using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text highscoreText;
    
    static int hitScore = 0;
    int currentScore;
    int highscore;

    void Start()
    {
        if (highscoreText == null)
        {
            Debug.LogWarning("Highscore Text is not assigned in the inspector");
            return;
        }

        if (scoreText == null)
        {
            Debug.LogWarning("Score Text is not assigned in the inspector");
            return;
        }

        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = highscore.ToString();
    }

    private void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player Transform is not assigned in the inspector");
            return;
        }

        if (scoreText == null)
        {
            Debug.LogWarning("Score Text is not assigned in the inspector");
            return;
        }

        if(hitScore>=60){
            FindObjectOfType<GameManager>().EndGame();
        }

        // Continuously update currentScore based on player position
        int scoreFromPosition = Mathf.FloorToInt(player.position.z);
        if (scoreFromPosition > currentScore)
        {
            currentScore = scoreFromPosition - hitScore;
        }
        scoreText.text = currentScore.ToString();

        // Update the highscore if the current score is higher
        if (currentScore > highscore)
        {
            highscore = currentScore;
            highscoreText.text = highscore.ToString();
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    public void ChangeScore(int amount)
    {
        hitScore = hitScore + amount;
    }

    public void resetHit()
    {
        hitScore = 0;
    }
}
