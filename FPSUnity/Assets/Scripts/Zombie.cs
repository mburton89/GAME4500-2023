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

    public GameObject healthBarContainer;
    public Image healthBarFill;

    public GameObject gutsPrefab;

    void Start()
    {
        target = FindObjectOfType<FPSController>().transform;

        navMeshAgent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;

        healthBarContainer.SetActive(false);
    }

    void Update()
    {
        ChasePlayer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);

        if (collision.gameObject.GetComponent<FPSController>())
        {
            GameManager.Instance.GameOver();
        }
    }

    void ChasePlayer()
    {
        navMeshAgent.destination = target.position;
    }

    public void TakeDamage(float damageToGive)
    {
        healthBarContainer.SetActive(true);

        currentHealth -= damageToGive;
        healthBarFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth < 0)
        {
            Instantiate(gutsPrefab, transform.position, transform.rotation, null);
            ZombieSpawner.Instance.CountZombies();
            Destroy(gameObject);
        }
    }
}
