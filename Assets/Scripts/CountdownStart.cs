using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownStart : MonoBehaviour
{
    [SerializeField] private int countdownTime;
    [SerializeField] private Text countdownDisplay;
    [SerializeField] private GameObject inputContainer;
    [SerializeField] private GameObject startTimer;

    private void Start()
    {
        inputContainer.SetActive(false);
        StartCoroutine(CountdownToStart());

    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "GO!";

        Time.timeScale = 1;
        inputContainer.SetActive(true);
        startTimer.GetComponent<Timer>().StartTimer();

        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
        
    }

}
