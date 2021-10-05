using UnityEngine;
using UnityEngine.UI;

// Advanced touch input MonoBehaviour that spawns balls at touch positions.
public class AdvancedTouchInput : MonoBehaviour
{
    // Reference to touch count Text component in the scene.
    [SerializeField] private Text touchCountText;

    // Reference to ball Prefab in the project assets.
    [SerializeField] private GameObject[] spawnObject;

    [SerializeField] private GameObject limit;
    
    private int randomNumber;
    private GameObject newObject;
    
    public int ObjectCount { get; private set; }

    // Update method is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        // Display the current touch count in the Text component.
        touchCountText.text = "Touch count: " + Input.touchCount + "\n" + "Number of objects: " + ObjectCount;

        

        // Make sure there are currently touches on the screen (at least one).
        if (Input.touchCount > 0)
        {
            // Obtain all the Touches currently available.
            for (int i = 0; i < Input.touchCount; i++)
            {

                // Get the Touch at index.
                Touch touch = Input.GetTouch(i);

                // Convert the screen position to world position.
                // A Z-coordinate ("10f") is passed to the method to account for offset from the Camera position.
                var worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));

                //Preventing the player from spawning objects on the upper part.
                if (worldPosition.y > limit.transform.position.y - 0.4)
                {
                    continue;
                }

                randomNumber = Random.Range(0, spawnObject.Length);

                // Log the touch phase events.
                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("TouchPhase.Began: " + i);
                    // Spawn a new ball instance from the prefab each time the screen is touched.
                    //private GameObject =

                    //Debug.Log(randomNumber);
                    newObject = spawnObject[randomNumber];
                    ObjectCount++;
                    Instantiate(newObject, worldPosition, Quaternion.identity);
                }
            }
        }
    }

}