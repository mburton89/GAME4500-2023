using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button startButton;

    public TextMeshProUGUI highestWave;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);

        highestWave.SetText("Highest Wave: " + PlayerPrefs.GetInt("HighestWave"));
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
