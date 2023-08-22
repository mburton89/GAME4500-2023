using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileLaunchSpeed;
    public AudioSource projectileLaunchSound;
    public CharacterController fpsController;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LaunchAmmo();
        }
    }

    void LaunchAmmo()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        print("fpsRigidBody.velocity" + fpsController.velocity);
        newProjectile.GetComponent<Rigidbody>().AddForce((projectileSpawnPoint.forward * projectileLaunchSpeed) + (fpsController.velocity * 50));
        Destroy(newProjectile, 5);
        projectileLaunchSound.pitch = Random.Range(0.92f, 1.08f);
        projectileLaunchSound.Play();
    }
}