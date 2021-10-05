using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string reloadScene;

    public void IsLoadScene()
    {
        SceneManager.LoadScene(reloadScene);
        Time.timeScale = 1;
    }
    
}
