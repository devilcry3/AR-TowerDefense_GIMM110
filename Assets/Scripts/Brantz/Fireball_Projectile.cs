using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Projectile : MonoBehaviour
{
    //Variables
    [SerializeField] float speed = 5f;            //projectile speed
    [SerializeField] float rotationSpeed = 200f;  //How fast fireball rotates to its target
    [SerializeField] int damage = 10;             //Damage dealt to target
    private Transform target;           //Target enemy


    void Start()
    {
        Destroy(gameObject, 5f);    //Destroy projectile after 5 seconds if it doesn't hit anything
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);    //if no target, destroy fireball
            return;
        }

        //Movement to target
        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
        direction.Normalize();

        //Rotate fireball to face target
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        transform.Rotate(0, 0, -rotateAmount * rotationSpeed * Time.deltaTime);

        //Move projectile forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Skeleton"))
        {
            //Damage enemy
            Health enemyHealth = other.GetComponent<Health>(); 
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject); //Destroy fireball on impact

        }

    }
}
