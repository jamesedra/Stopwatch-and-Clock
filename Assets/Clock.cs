using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    /*
    float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;
    [SerializeField] Transform hoursPivot, minutesPivot, secondsPivot;

    /*
    private void Update ()
    {
        // Debug.Log(DateTime.Now);
        // Debug.Log(DateTime.Now.TimeOfDay);
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * (float)time.TotalHours);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds);

    }

    private float elapsedTime = 0f;

    private void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate minutes and seconds
        float totalMinutes = Mathf.Floor(elapsedTime / 60f);
        float totalSeconds = elapsedTime % 60f;

        // Update the pivot rotations
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * totalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * totalSeconds);
    }*/

    float minutesToDegrees = -6f, secondsToDegrees = -6f, millisecondsToDegrees = -0.002f;
    [SerializeField] Transform minutesPivot, secondsPivot;

    // Reference to the UI Text element
    [SerializeField] GameObject textMesh;

    private float elapsedTime = 0f;

    private TextMeshProUGUI timeText;

    private void Start()
    {
        timeText = textMesh.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Update the elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate minutes, seconds, and milliseconds
        float totalMinutes = Mathf.Floor(elapsedTime / 60f);
        float totalSeconds = Mathf.Floor(elapsedTime % 60f);
        float totalMilliseconds = Mathf.Floor((elapsedTime * 1000) % 1000);

        // Update the pivot rotations
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * totalMinutes);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * totalSeconds);

        // Update the UI Text with the elapsed time
        UpdateTimeText(totalMinutes, totalSeconds, totalMilliseconds);
    }

    void UpdateTimeText(float minutes, float seconds, float milliseconds)
    {
        // Format the time and update the TextMeshProUGUI
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }


}
