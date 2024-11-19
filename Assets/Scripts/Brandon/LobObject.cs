using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LobObject : MonoBehaviour

{
    Catapult cat;
    AOE areaEffect;
    Health health;
    public GameObject ball;
    //Vector2 spawnPosition;
    Quaternion spawnRotation = Quaternion.identity;

    public Rigidbody2D rb;
    public float lobForce = 5f; // Adjust for desired throw strengt
    public float launchAngle = 45f; // Adjust for desired lob arc
    [SerializeField] int damage = 15;

    private void Start()
    {
        cat = FindObjectOfType<Catapult>();
        areaEffect = FindObjectOfType<AOE>();
        health = FindObjectOfType<Health>();
    }


    void Update()

    {

    }

    public void Launch()
    {
       
        GameObject newObject = Instantiate(ball, cat.transform.position, Quaternion.identity);
        //creates and "instantiates" the bullet in world
        // Get the Rigidbody2D of the new object
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            float radians = Mathf.Deg2Rad * launchAngle;

            float xForce = Mathf.Cos(radians) * lobForce;

            float yForce = Mathf.Sin(radians) * lobForce;

            rb.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse); //Impulse adds the force in a single pulse of force instead of continous
            Debug.Log("Fire");

            /*
         * This code is calculating the horizontal (xForce) and vertical (yForce) components 
         * of a force vector for a projectile, given a launch angle (in degrees) and a lob
         * force (the magnitude of the total force).
         */
        }


    }

   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Detonator" )
        {
            Destroy(gameObject);
            Explosion();
           
        }
        
    }

    void Explosion ()
    {
        foreach (GameObject target in areaEffect.enemyList)
        {
            if (target != null) // Check if the GameObject exists
            {
                // Get the HealthComponent (or equivalent script) on the GameObject
                Health health = target.GetComponent<Health>();

                if (health != null)
                {
                    // Call the TakeDamage method to apply damage
                    health.TakeDamage(damage);
                }
                else
                {
                    Debug.LogWarning($"GameObject {target.name} does not have a HealthComponent!");
                }
            }
        }
    }

}
