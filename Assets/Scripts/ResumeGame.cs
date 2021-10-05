using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGame : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenu;
    [SerializeField] private GameObject input;

    public void IsResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        input.SetActive(true);
        Time.timeScale = 1;
    }
}
