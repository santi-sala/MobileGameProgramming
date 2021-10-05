using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    private bool timerIsActive = false;
    private float currentTime;
    private string finalObjectCount;
    [SerializeField] private Text currentTimeText;

    [SerializeField] private GameObject finalTime;
    

    
    // Update is called once per frame
    void Update()
    {
        if (timerIsActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        //currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        currentTimeText.text = time.Seconds.ToString() + "s. and " + time.Milliseconds.ToString() + "ms.";
    }

    public void StartTimer()
    {
        timerIsActive = true;
    }

    public void StopTimer()
    {
        timerIsActive = false;
        finalTime.GetComponent<ShowScore>().GetTime(currentTimeText.text);

        finalObjectCount = GameObject.Find("InputContainer").GetComponent<AdvancedTouchInput>().ObjectCount.ToString();

        finalTime.GetComponent<ShowScore>().GetObjects(finalObjectCount);
    }
}
