using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSplatterHandler : MonoBehaviour
{
    public GameObject bloodSplatterPrefab;

    private void OnParticleCollision(GameObject other)
    {


        print("other.position " + other.transform.position);
        GameObject blood = Instantiate(bloodSplatterPrefab, other.transform.position, Quaternion.identity, this.transform);
        Destroy(blood,3);
    }

    private void OnParticleTrigger()
    {
        print("OnParticleTrigger");
    }
}
