using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int AmmoToGive = 10;
    public float rotationSpeed = 30.0f;

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,1) * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            FindObjectOfType<Cannon>().HandleAmmoPickup(10);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>())
        {
            FindObjectOfType<Cannon>().HandleAmmoPickup(10);
            SoundManager.Instance.ammoPickup.Play();
            Destroy(gameObject);
        }
    }
}
