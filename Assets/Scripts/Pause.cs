using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button pause;
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private GameObject input;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.gameObject.SetActive(false); 
    }

    public void PausePressed()
    {

        Debug.Log("Pause pressed");
        input.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
}
