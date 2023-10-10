using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner Instance;

    public GameObject zombiePrefab;
    public List<Transform> spawnPoints;
    [HideInInspector] public int wave;

    Transform player;
    public float minDistanceFromPlayer = 12f;

    private void Awake()
    {
        Instance = this;
        wave = 1;
        player = FindObjectOfType<PlayerMovement>().transform;

        foreach (Transform spawnPoint in spawnPoints)
        {
            spawnPoint.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void CountZombies()
    {
        Zombie[] zombies = FindObjectsOfType<Zombie>();

        if (zombies.Length <= 1)
        {
            SpawnWaveOfZombies();
        }
    }

    void SpawnWaveOfZombies()
    {
        wave++;

        for (int i = 0; i < wave; i++) 
        {
            bool isTooCloseToZombie = true;
            int rand = 0;

            while (isTooCloseToZombie)
            {
                rand = Random.Range(0, spawnPoints.Count - 1);

                if (Vector3.Distance(spawnPoints[rand].position, player.transform.position) > minDistanceFromPlayer)
                {
                    isTooCloseToZombie = false;
                }
                else
                {
                    isTooCloseToZombie = true;
                }
            }

            Instantiate(zombiePrefab, spawnPoints[rand].position, Quaternion.identity, transform);
        }

        HUD.Instance.UpdateWaveUI(wave);
    }
}
