using System.Collections;
using UnityEngine;

public class BerserkBehavior : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private int attackDamage = 10; // Damage
    [SerializeField] private float attackInterval = 1f; // Time between attacks
    [SerializeField] private float detectionRadius = 3f; // Detection radius

    private Transform currentTower = null;
    private Health towerHealth;
    private EnemyMovement enemyMovement;
    private bool isAttacking = false;

    private void Start()
    {
        // Get the EnemyMovement component
        enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement == null)
        {
            Debug.LogError("EnemyMovement script is missing!");
        }
    }

    private void Update()
    {
        // Search for towers within the detection radius if not currently attacking
        if (!isAttacking)
        {
            DetectTower();
        }

        // Pause movement while attacking a tower
        if (currentTower != null && enemyMovement != null)
        {
            enemyMovement.enabled = false;
        }
        else if (enemyMovement != null)
        {
            enemyMovement.enabled = true;
        }
    }

    private void DetectTower()
    {
        // Use Physics2D.OverlapCircle to find towers within the detection radius
        // Adjust detectionRadius to change this.  
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Tower"))
            {
                currentTower = hit.transform;
                towerHealth = hit.GetComponent<Health>();
                if (towerHealth != null)
                {
                    StartCoroutine(AttackTower());
                    return;
                }
            }
        }
    }

    private IEnumerator AttackTower()
    {
        isAttacking = true;
        while (currentTower != null && towerHealth != null && towerHealth.currentHealth > 0)
        {
            towerHealth.TakeDamage(attackDamage);
            yield return new WaitForSeconds(attackInterval);
        }
        StopAttackingTower();
    }

    private void StopAttackingTower()
    {
        // Sets tower to 0 and makes beserker stop attacking
        currentTower = null;
        towerHealth = null;
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        //This makes detection radius visible in Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

// Towers must have health scripts attached and have the Tower tag. 
// Towers need Collider2D component.