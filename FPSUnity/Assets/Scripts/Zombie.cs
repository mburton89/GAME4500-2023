using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    NavMeshAgent navMeshAgent;

    public float maxHealth;
    float currentHealth;

    public Image healthBarFill;

    public GameObject gutsPrefab;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        navMeshAgent.destination = target.position;
    }

    public void TakeDamage(float damageToGive)
    {
        currentHealth -= damageToGive;
        healthBarFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth < 0)
        {
            Instantiate(gutsPrefab, transform.position, transform.rotation, null);
            Destroy(gameObject);
        }
    }
}
