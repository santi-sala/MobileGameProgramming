using UnityEngine;
using UnityEngine.UI;

// Touch input MonoBehaviour for handling touch input events.
public class TouchInput : MonoBehaviour
{
    // Reference to touch count Text component in the scene.
    [SerializeField] private Text touchCountText;

    // Update method is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        // Display the current touch count in the Text component.
        touchCountText.text = "Touch count: " + Input.touchCount;

        // Make sure there are currently touches on the screen (at least one).
        if (Input.touchCount > 0)
        {
            // Obtain the Touch in the zero index.
            Touch touch = Input.GetTouch(0);

            // Log the touch phase events.
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("TouchPhase.Began");
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("TouchPhase.Moved");
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                Debug.Log("TouchPhase.Stationary");
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("TouchPhase.Ended");
            }
            else if (touch.phase == TouchPhase.Canceled)
            {
                Debug.Log("TouchPhase.Canceled");
            }
        }
    }
}