using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class LobObject : MonoBehaviour

{
    Catapult cat;
   // public GameObject ballSpawn;
    public GameObject ball;
    //Vector2 spawnPosition;
    Quaternion spawnRotation = Quaternion.identity;

    public Rigidbody2D rb;

    public float lobForce = 5f; // Adjust for desired throw strength

    public float launchAngle = 45f; // Adjust for desired lob arc

    private void Start()
    {
        cat = FindObjectOfType<Catapult>();
    }


    void Update()

    {

    }

    public void Launch()
    {
        // spawnPosition = ballSpawn.transform.position; // determines the spawnPosition based on BulletSpawn object location
        GameObject newObject = Instantiate(ball, cat.transform.position, Quaternion.identity);
       // Instantiate(ball, cat.spawnPosition, spawnRotation); //creates and "instantiates" the bullet in world
        // Get the Rigidbody2D of the new object
        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            float radians = Mathf.Deg2Rad * launchAngle;

            float xForce = Mathf.Cos(radians) * lobForce;

            float yForce = Mathf.Sin(radians) * lobForce;

            rb.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
            Debug.Log("Fire");
            }
       
       
    }

    void Force()
    {
        float radians = Mathf.Deg2Rad * launchAngle;

        float xForce = Mathf.Cos(radians) * lobForce;

        float yForce = Mathf.Sin(radians) * lobForce;

        rb.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
    }

}
