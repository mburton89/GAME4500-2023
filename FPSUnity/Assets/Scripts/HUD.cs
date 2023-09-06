using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;
    public TextMeshProUGUI waveText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateWaveUI(int wave)
    {
        waveText.SetText("Wave: " + wave);
    }
}
