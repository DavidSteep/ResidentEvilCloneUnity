using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour, IEnemyBehaviour
{
    [SerializeField]
    private EnemyStatSO stats;

    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = stats.baseHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
