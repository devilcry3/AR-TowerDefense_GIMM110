using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequisitionWarp : MonoBehaviour
{
    [SerializeField] GameObject WarpCircle;
    [SerializeField] float warpDuration = 3.0f;

    public void LoadOnClick()
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
