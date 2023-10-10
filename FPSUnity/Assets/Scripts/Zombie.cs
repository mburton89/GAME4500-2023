using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    float currentHealth;
    public float maxHealth;

    public GameObject healthBarContainer;
    public Image healthBarFill;

    public GameObject gutsPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //target = FindObjectOfType<FPSController>().transform;

        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        ChaseTarget();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    public void EatBrain()
    { 
    
    }

    public void ChaseTarget()
    {
        agent.destination = target.position;
    }

    public void TakeDamage(float damageToGive)
    {
        healthBarContainer.SetActive(true);

        currentHealth -= damageToGive;
        healthBarFill.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Instantiate(gutsPrefab, transform.position, transform.rotation, null);
            ZombieSpawner.Instance.CountZombies();
            Destroy(gameObject);
        }
    }
}
