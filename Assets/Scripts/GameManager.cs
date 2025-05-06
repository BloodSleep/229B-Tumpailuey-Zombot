using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public TMP_Text scoreText;
    public GameObject gameOverUI;
    public float creditsDelay = 5f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (scoreText != null)
            scoreText.text = score.ToString() + " Score";
            scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
        
        Time.timeScale = 0;

        StartCoroutine(GoToCreditsAfterDelay());
    }

    IEnumerator GoToCreditsAfterDelay()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(creditsDelay);
        SceneManager.LoadScene("Credits");
    }
}