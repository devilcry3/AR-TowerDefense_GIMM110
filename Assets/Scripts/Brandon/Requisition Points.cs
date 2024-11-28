using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // called the text mesh pro library


public class RequisitionPoints : MonoBehaviour
{

    public int recPoints= 0;

    [SerializeField] private TextMeshProUGUI pointText; //serialized field specifically for a TextMeshProUI, is not interchangeable with legacy text box
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        pointText.text = "RP: " + recPoints; //updates the Textmeshpro text box with the curretn chargePoints value
    }

    public void AddPoints(int points)
    {
        recPoints += points;
        Debug.Log($"Requisition Points updated: {recPoints}");
    }

}
