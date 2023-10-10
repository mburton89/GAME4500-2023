using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class HUD : MonoBehaviour
{
    public static HUD Instance;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI ammoText;

    public GameObject bloodOverlay;
    public AudioSource chicken;

    bool gameIsOver = false;

    public Transform chickee;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateWaveUI(int wave)
    {
        waveText.SetText("Wave: " + wave);
    }

    public void UpdateCurrentAmmoCount(int currentAmmo)
    {
        ammoText.SetText("Nuggie Clusters: " + currentAmmo);
    }

    public void GameOver()
    {
        if (!gameIsOver)
        { 
            StartCoroutine(GameOverCo());
            gameIsOver = true;
        }
    }

    private IEnumerator GameOverCo()
    {
        if (ZombieSpawner.Instance.wave > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", ZombieSpawner.Instance.wave);
        }

        bloodOverlay.SetActive(true);
        chicken.Play();
        FindObjectOfType<PlayerMovement>().enabled = false;
        FindObjectOfType<WallRunning>().enabled = false;
        FindObjectOfType<Cannon>().enabled = false;
        FindObjectOfType<MoveCamera>().enabled = false;
        chickee.localScale = Vector3.zero;
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
