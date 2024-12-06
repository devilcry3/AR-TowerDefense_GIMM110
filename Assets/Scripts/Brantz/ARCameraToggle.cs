using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using TMPro;

public class ARCameraToggle : MonoBehaviour
{
    [SerializeField] public GameObject arCamera; //assign camera to this field in inspector
    [SerializeField] public TextMeshProUGUI timerText; //assign UI text for countdown
    [SerializeField] private float activeDuration = 10f; //time the camera stays on
    [SerializeField] private float inactiveDuration = 30f; //time the camera stays inactive

    void Start()
    {
        arCamera.SetActive(false); //this is here to make the camera inactive at first
        StartCoroutine(ToggleCamera());
    }


    private IEnumerator ToggleCamera()
    {
        while (true)
        {
            yield return StartCoroutine(Countdown(inactiveDuration)); //this is here to make the camera inactive at first, too

            //activate AR camera and show countdown for active duration
            arCamera.SetActive(true);
            Debug.Log("AR Camera Activated");
            yield return StartCoroutine(Countdown(activeDuration));

            //deactivate AR camera and show countdown for inactive duration
            arCamera.SetActive(false);
            Debug.Log("AR Camera Deactivated");
            yield return StartCoroutine(Countdown(inactiveDuration));
        }
    }

    private IEnumerator Countdown(float duration)
    {
        float timeRemaining = duration;
        while (timeRemaining > 0)
        {
            //update timer text
            timerText.text = $"{timeRemaining:F0}";
            yield return new WaitForSeconds(0.1f); //updated every 0.1 seconds
            timeRemaining -= 0.1f;
        }

        timerText.text = ""; //zero timer when countdown ends

    }


}
