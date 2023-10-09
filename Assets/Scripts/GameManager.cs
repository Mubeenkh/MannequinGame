using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private float Score = 0;
    private static float totalScore;
    private Text scoreText; 
    private GameObject text;

    private void Awake()
    {
        // Instance = this;
        // DontDestroyOnLoad(Instance); 

        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            // DontDestroyOnLoad(Instance); 
        } 
    }
    public void Start()
    {
        // Debug.Log("Score: " + Score + "pts");
        // Debug.Log("Total Score: " + totalScore + "pts");
        text = GameObject.FindWithTag("ScoreText");
        scoreText = (Text) text.GetComponent(typeof(Text));
        scoreText.text = "Score: " + (totalScore + Score).ToString() + " pts";
    }
    public void StartGame()
    {
        Score = 0;
        totalScore = 0;
        SceneManager.LoadScene("Level1");
    }

    public void AddScore()
    {
        // TODO: Add 50 pts when we collect yellow ball
        Score += 50;
        // Debug.Log("Score: " + Score + "pts");
        // Debug.Log("Total Score: " + totalScore + "pts");
        scoreText.text = "Score: " + (totalScore + Score).ToString() + " pts";
    }

    public float  getTotalScore()
    {
        return totalScore;
    }
    public float getScore()
    {
        return Score;
    }

    public void LoadNextLevel()
    {
        totalScore += Score;
        // Debug.Log("Score: " + Score + "pts");
        // Debug.Log("Total Score: " + totalScore + "pts");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ResetScore()
    {
        Debug.Log("Rip...You Died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
