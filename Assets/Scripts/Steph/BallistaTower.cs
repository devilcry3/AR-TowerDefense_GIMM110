using System.Collections;
using UnityEngine;

public class BallistaTower : MonoBehaviour
{
    [Header("Ballista Settings")]
    [SerializeField] private float fireInterval = 5f; // Time between shots
    [SerializeField] private float fireAngle = 90f; // Angle of firing
    [SerializeField] private GameObject spearPrefab; // Spear prefab to instantiate
    [SerializeField] private Transform firePoint; // Point from which the spear will be fired
    [SerializeField] private float spearSpeed = 10f; // Speed of the spear
    [SerializeField] private int spearDamage = 10; // Spear damage

    private void Start()
    {
        StartCoroutine(FireSpearRoutine());
    }

    private IEnumerator FireSpearRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireInterval);
            FireSpear();
        }
    }

    private void FireSpear()
    {
        // Instantiate spear at the fire point
        GameObject spear = Instantiate(spearPrefab, firePoint.position, Quaternion.identity);

        // Calculate firing direction based on the specified angle
        Vector3 firingDirection = Quaternion.Euler(0, 0, fireAngle) * Vector3.right;

        // Set the velocity of the spear
        Rigidbody2D rb = spear.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firingDirection.normalized * spearSpeed;
        }
        // Assign the spear's damage value
        Spear spearScript = spear.GetComponent<Spear>();
        if (spearScript != null)
        {
            spearScript.SetDamage(spearDamage);
        }

        // Destroy the spear after a number of seconds
        Destroy(spear, fireInterval);
    }
}
