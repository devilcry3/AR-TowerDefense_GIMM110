using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Requisition : MonoBehaviour
{
    [SerializeField] GameObject BarbedWire;   //assign barbed wire object in inspector
    [SerializeField] float wireDuration = 5f; //time it remains active
    
    [SerializeField] GameObject WarpCircle;
    [SerializeField] float warpDuration = 3f;


    RepairTower repair;
    FreezeEnemies freeze;
    RequisitionPoints reqPoints;

    //Req Point costs
    [SerializeField] int warpCost = 10;
    [SerializeField] int wireCost = 15;
    [SerializeField] int repairCost = 50;
    [SerializeField] int freezeCost = 20;

    private void Start()
    {
        repair = FindObjectOfType<RepairTower>();
        freeze = FindObjectOfType<FreezeEnemies>();
        reqPoints = FindObjectOfType<RequisitionPoints>();
    }

    public void DeployWire()
    {
        if (reqPoints.recPoints >= wireCost && !BarbedWire.activeInHierarchy)
        {
            reqPoints.recPoints -= wireCost; //This is what deducts the points spent
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
        if (reqPoints.recPoints >= warpCost && !WarpCircle.activeInHierarchy)
        {
            reqPoints.recPoints -= warpCost;
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
        if (reqPoints.recPoints >= repairCost)
        {
            reqPoints.recPoints -= repairCost;
            repair.RepairTowers();
        }
    }

    public void DeployFreeze()
    {
        if (reqPoints.recPoints >= freezeCost)
        {
            reqPoints.recPoints -= freezeCost;
            StartCoroutine(freeze.FreezeAllEnemies());
        }
    }


}
