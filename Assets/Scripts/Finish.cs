using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private float minimumSpeed;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject showResults;
    [SerializeField] private GameObject inputContainer;

    private void Start()
    {
        showResults.SetActive(false);
        
    }

    private void OnTriggerStay(Collider other)
    {
        

        if (other.gameObject.CompareTag("Piece") && other.GetComponent<Rigidbody>().velocity.magnitude < minimumSpeed)
        {
            Debug.Log("Sup");
            timer.GetComponent<Timer>().StopTimer();
            Time.timeScale = 0;
            showResults.SetActive(true);
            inputContainer.SetActive(false);
            
        }
    }
}
