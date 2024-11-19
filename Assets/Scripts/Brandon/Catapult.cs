using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
   LobObject lob; //inheriting information from the ChargePoints class, will be for chargePoint value
    public GameObject ballSpawn;
    public GameObject ball;
    public Vector2 spawnPosition;
     Quaternion spawnRotation = Quaternion.identity;

    public void Start()
    {
        lob = FindObjectOfType<LobObject>(); // instantiates cP as ChargePoints
        spawnPosition = ballSpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Or any input to trigger the lob

        {

            lob.Launch();
        }
    }

    
}
