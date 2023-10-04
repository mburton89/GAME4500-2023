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
    public int startingAmmo;
    int currentAmmo;

    private void Start()
    {
        currentAmmo = startingAmmo;
        HUD.Instance.UpdateCurrentAmmoCount(currentAmmo);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (currentAmmo > 0)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * launchSpeed);
            shootSound.pitch = Random.Range(0.9f, 1.1f);
            shootSound.Play();
            currentAmmo--;
            HUD.Instance.UpdateCurrentAmmoCount(currentAmmo);
            Destroy(newProjectile, 5);
        }
        else
        { 
            //TODO Play dud sound effect
        }
    }

    public void HandleAmmoPickup(int ammoToGain)
    {
        currentAmmo += ammoToGain;
        HUD.Instance.UpdateCurrentAmmoCount(currentAmmo);
    }
}
