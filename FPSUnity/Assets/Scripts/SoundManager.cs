using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource ammoPickup;

    void Awake()
    {
        Instance = this;
    }
}
