using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Catapult : MonoBehaviour
{
    LobObject lob; //inheriting information from the ChargePoints class, will be for chargePoint value
    [SerializeField] GameObject ballSpawn;
    [SerializeField] GameObject ball;
    Rigidbody2D rb;
    [SerializeField] GameObject catapult;
   Vector2 spawnPosition;
    Quaternion spawnRotation = Quaternion.identity;
   
    [SerializeField] float timeToSpawn = 5f;
    public float lobForce = 10f; // Adjust for desired throw strengt
    public float launchAngle = 90f; // Adjust for desired lob arc


    public void Start()
    {
        lob = FindObjectOfType<LobObject>(); // instantiates cP as ChargePoints
        spawnPosition = ballSpawn.transform.position;
        StartCoroutine(Crank()); // Starts the coroutine to spawn enemies
                                 //A coroutine is a method that can pause execution and return control to
                                 //Unity but then continue where it left off on the following frame.
    }

    // Update is called once per frame
    void Update()
    {
        {



        }
    }
        IEnumerator Crank()
        {
            while (true) // Infinite loop to keep spawning enemies
            {
            if (catapult != null)
            {
                // Spawns an enemy samurai at the enemy spawn position
                GameObject newObject = Instantiate(ball, spawnPosition, Quaternion.identity);
                //creates and "instantiates" the bullet in world
                // Get the Rigidbody2D of the new object
                rb = newObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    float radians = Mathf.Deg2Rad * launchAngle;

                    float xForce = Mathf.Cos(radians) * lobForce;

                    float yForce = Mathf.Sin(radians) * lobForce;

                    rb.AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse); //Impulse adds the force in a single pulse of force instead of continous
                    Debug.Log("Fire");

                }

                yield return new WaitForSeconds(timeToSpawn); // Waits for the specified time before spawning another enemy
                }
            }
        }



    
}
