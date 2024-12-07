using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Requisition : MonoBehaviour
{
    [SerializeField] GameObject BarbedWire;         //assign barbed wire object in inspector
    [SerializeField] float wireDuration = 5f; //time it remains active
    
    [SerializeField] GameObject WarpCircle;
    [SerializeField] float warpDuration = 3f;


    RepairTower repair;
    FreezeEnemies freeze;

    private void Start()
    {
        repair = FindObjectOfType<RepairTower>();
        freeze = GetComponent<FreezeEnemies>();
    }

    public void DeployWire()
    {
        if (!BarbedWire.activeInHierarchy)
        {
            StartCoroutine(DeployBarbedWire());

        }
    }

    private IEnumerator DeployBarbedWire()
    {
        BarbedWire.SetActive(true); //enable object in hierarchy

        yield return new WaitForSeconds(wireDuration); //wait for deploymentDuration

        BarbedWire.SetActive(false); //disable object in hierarchy
    }


   public void DeployWarp()
    {
        if (!WarpCircle.activeInHierarchy)
        {
            StartCoroutine(StartWarpCircle());
        }
    }

    private IEnumerator StartWarpCircle()
    {
        WarpCircle.SetActive(true);

        yield return new WaitForSeconds(warpDuration);

        WarpCircle.SetActive(false);

    }

    public void DeployRepair()
    {
        repair.RepairTowers();
    }

    public void DeployFreeze()
    {
        freeze.FreezeAllEnemies();
    }


}
