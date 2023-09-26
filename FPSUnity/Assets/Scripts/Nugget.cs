using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nugget : MonoBehaviour
{
    public float damageToGive;
    bool hasHitZombie = false;
    public AudioSource hitSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Zombie>() && !hasHitZombie)
        {
            collision.gameObject.GetComponent<Zombie>().TakeDamage(damageToGive);
            hasHitZombie = true;
            hitSound.Play();
        }
    }
}
