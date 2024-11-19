using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequisitionBW : MonoBehaviour
{
    [SerializeField] GameObject BarbedWire;         //assign barbed wire object in inspector
    [SerializeField] float deploymentDuration = 5f; //time it remains active


    public void LoadOnClick()
    {
        if (!BarbedWire.activeInHierarchy)
        {
            StartCoroutine(DeployBarbedWire());

        }
    }
    
    private IEnumerator DeployBarbedWire()
    {
        BarbedWire.SetActive(true); //enable object in hierarchy

        yield return new WaitForSeconds(deploymentDuration); //wait for deploymentDuration

        BarbedWire.SetActive(false); //disable object in hierarchy
    }

}
