using UnityEngine;
using UnityEngine.SceneManagement;

// This MonoBehaviour reloads the scene when the method in it is called.
public class ReloadScene : MonoBehaviour
{
    // Reload currently active scene when the method is called.
    public void ReloadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}