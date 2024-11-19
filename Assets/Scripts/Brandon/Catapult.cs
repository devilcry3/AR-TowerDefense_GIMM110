using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Catapult : MonoBehaviour
{
    LobObject lob; //inheriting information from the ChargePoints class, will be for chargePoint value
    public GameObject ballSpawn;
    public GameObject ball;
    [SerializeField] GameObject catapult;
    public Vector2 spawnPosition;
    Quaternion spawnRotation = Quaternion.identity;
    [SerializeField] float timeToSpawn = 5f;


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
                    lob.Launch();
                  
                }

                yield return new WaitForSeconds(timeToSpawn); // Waits for the specified time before spawning another enemy
            }
        }



    
}
