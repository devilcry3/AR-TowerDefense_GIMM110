using System;
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
    bool upgrade;
    Quaternion spearRotation;

    private void Start()
    {
        StartCoroutine(FireSpearRoutine());
        spearRotation = spearPrefab.transform.rotation;
        
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
        GameObject spear = Instantiate(spearPrefab, firePoint.position, spearRotation);

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

    public void Boost()
    {

        if (!upgrade)
        {
            upgrade = true;
            Debug.Log("boost engaged");
            StartCoroutine(Pew());
        }
    }
    IEnumerator Pew()
    {

        fireInterval = 2f;
        yield return new WaitForSeconds(6);  // Ensure this is properly awaited
        upgrade = false;
        fireInterval = 5f;
        Debug.Log("BRRRRR");
        yield break;
    }
}
