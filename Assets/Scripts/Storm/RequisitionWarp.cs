using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequisitionWarp : MonoBehaviour
{
    [SerializeField] GameObject WarpCircle;
    [SerializeField] float warpDuration = 5.0f;

    public void WarpTimer()
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
}
