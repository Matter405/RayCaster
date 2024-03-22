using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class Level01Controller : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _currentScoreTextView;
    private int _currentScore;
    public static string _highScoreKey = "HighScore";

    private void Awake()
    {
        // Lock the cursor in place
        Cursor.lockState = CursorLockMode.Locked;
        // Make the cursor invisible
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ExitLevel();
        }
    }

    public void IncreaseScore(int scoreIncrease)
    {
        // Increase the score
        _currentScore += scoreIncrease;
        // Update the score display, so we can see our new score
        _currentScoreTextView.text =
            "Score: " + _currentScore.ToString();
    }

    private void ExitLevel()
    {
        // Compare score to high score
        int highScore = PlayerPrefs.GetInt(_highScoreKey);
        if(_currentScore > highScore)
        {
            // Save current score as new high score
            PlayerPrefs.SetInt(_highScoreKey, _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }
        SceneManager.LoadScene("MainMenu");
    }
    

}
