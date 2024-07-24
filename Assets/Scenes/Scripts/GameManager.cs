using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool hasGameEnded = false;

    public void EndGame()
    {
        if (hasGameEnded == false)
        {
            hasGameEnded = true;
            Debug.Log("Game Over");
            FindObjectOfType<Score>().resetHit();
            Invoke("Restart", 0f); // Delay before restarting the game
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
