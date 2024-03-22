using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private TextMeshProUGUI _highScoreTextView;

    private void Awake()
    {
        // Allow the cursor to move around the game window
        Cursor.lockState = CursorLockMode.Confined;
        // Make the cursor visible
        Cursor.visible = true;
    }

    private void Start()
    {
        // Load high score display
        int highScore =
            PlayerPrefs.GetInt(Level01Controller._highScoreKey);
        _highScoreTextView.text = highScore.ToString();
        if(_menuMusic != null)
        {
            AudioManager.Instance.PlayMusic(_menuMusic);
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt(Level01Controller._highScoreKey, 0);

        _highScoreTextView.text = "0";
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game has been quit");
    }
}
