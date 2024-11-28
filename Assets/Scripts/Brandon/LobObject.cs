using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LobObject : MonoBehaviour

{
    AOE areaEffect;
    Health health;
    Catapult cat;

    public int damage = 15;

    private void Start()
    {
        areaEffect = FindObjectOfType<AOE>();
        health = FindObjectOfType<Health>();
        cat = FindObjectOfType<Catapult>();
    }

    void Update()

    {

    }

   public void DamageChange(int x)
    {
        if (cat.upgrade == true)
        {
            damage = 20;
        }
        if (cat.upgrade != false) { damage = 15; }
        
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
