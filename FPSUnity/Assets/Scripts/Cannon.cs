using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float fireRate;
    public float launchSpeed;
    public Transform spawnPoint;
    public GameObject projectilePrefab;
    public AudioSource shootSound;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
    	print("Shoot");
	    GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * launchSpeed);
        shootSound.pitch = Random.Range(0.9f, 1.1f);
        shootSound.Play();
        Destroy(newProjectile, 5);
    }
}
