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

    public bool useBlunderbuss = false;
    public int blunderBussShotCount = 7;
    public float blunderbussSpreadRadius = .075f;
    public float blunderbussTimeBetweenShots = .01f;
    public float blunderbussYMultiplier = 7;

    private void Start()
    {
        currentAmmo = startingAmmo;
        if (HUD.Instance != null)
        { 
            HUD.Instance.UpdateCurrentAmmoCount(currentAmmo);
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (useBlunderbuss)
            {
                if (currentAmmo > 0)
                {
                    StartCoroutine(Blunderbuss(blunderBussShotCount, blunderbussSpreadRadius, blunderbussYMultiplier, blunderbussTimeBetweenShots));
                }
                else
                {
                    //TODO Play dud sound effect
                }
            }
            else
            {
                Shoot();
            }
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
            Destroy(newProjectile, 5);
        }
        else
        { 
            //TODO Play dud sound effect
        }

        if (currentAmmo < 0)
        {
            currentAmmo = 0;
        }
        HUD.Instance.UpdateCurrentAmmoCount(currentAmmo);

    }

    public void HandleAmmoPickup(int ammoToGain)
    {
        currentAmmo += ammoToGain;
        HUD.Instance.UpdateCurrentAmmoCount(currentAmmo);
    }

    IEnumerator Blunderbuss(int shotCount = 10, float spreadRadius = .05f, float yMultiplier = 7, float timeBetweenShots = .001f)
    {
        for (int i = 0; i < shotCount; i++)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, transform.rotation);

            Vector3 randVec = new Vector3(Random.Range(-spreadRadius, spreadRadius), Random.Range(-spreadRadius * yMultiplier, spreadRadius * yMultiplier), Random.Range(-spreadRadius, spreadRadius));

            newProjectile.GetComponent<Rigidbody>().AddForce((spawnPoint.forward + randVec) * launchSpeed);

            Destroy(newProjectile, 2f);

            yield return new WaitForSeconds(timeBetweenShots);
        }
        
        shootSound.pitch = Random.Range(0.9f, 1.1f);
        shootSound.Play();
        currentAmmo--;

        if (currentAmmo < 0)
        {
            currentAmmo = 0;
        }
        HUD.Instance.UpdateCurrentAmmoCount(currentAmmo);

    }

}
