using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int AmmoToGive = 10;
    public float rotationSpeed = 30.0f;
    public float secondsToRespawn = 30.0f;

    bool canBeCollected = true;
    MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,0,1) * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>() && canBeCollected)
        {
            StartCoroutine(HandleCollectedCo());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FPSController>() && canBeCollected)
        {
            StartCoroutine(HandleCollectedCo());
        }
    }

    private IEnumerator HandleCollectedCo()
    {
        meshRenderer.enabled = false;
        FindObjectOfType<Cannon>().HandleAmmoPickup(AmmoToGive);
        SoundManager.Instance.ammoPickup.Play();
        canBeCollected = false;
        yield return new WaitForSeconds(secondsToRespawn);
        canBeCollected = true;
        meshRenderer.enabled = true;
    }
}
