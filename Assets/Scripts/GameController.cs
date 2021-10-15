using UnityEngine;
using UnityEngine.UI;

// Game controller MonoBehaviour that spawns objects at touch positions and keeps score.
public class GameController : MonoBehaviour
{
    // Static reference to 'this' game controller class instance.
    public static GameController Instance;

    // References to Text components in the scene.
    [SerializeField] private Text touchCountText;
    [SerializeField] private Text objectCountText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text scoreCountText;

    // References to prefabs in the project assets.
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject capsulePrefab;
    [SerializeField] private GameObject cylinderPrefab;

    // Counter variables.
    private int objectCount = 0;
    private int scoreCount = 0;
    private int levelCount = 0;

    // Level increase score limit value.
    private readonly int levelIncreaseScoreLimit = 50;

    // Awake is called once for each MonoBehaviour when it is first enabled.
    private void Awake()
    {
        // Set the reference to 'this' game controller class instance.
        // This effectively makes this a singleton that may be called from other scripts.
        /*Instance = this;*/
    }

    // Update method is called every frame, if the MonoBehaviour is enabled.
    private void Update()
    {
        // Display the current touch count in the Text component.
        touchCountText.text = "Touch count: " + Input.touchCount;

        // Make sure there are currently touches on the screen (at least one).
        if (Input.touchCount > 0)
        {
            touchCountText.text = "Touch count: " + Input.touchCount;

            // Obtain all the Touches currently available.
            for (int i = 0; i < Input.touchCount; i++)
            {
                // Get the Touch at index.
                Touch touch = Input.GetTouch(i);

                // Convert the screen position to world position.
                // A Z-coordinate ("10f") is passed to the method to account for offset from the Camera position.
                var worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));

                // Log the touch phase events.
                if (touch.phase == TouchPhase.Began)
                {
                    // Spawn a new object instance from a prefab each time the screen is touched.
                    if (i == 0)
                    {
                        Instantiate(ballPrefab, worldPosition, Quaternion.identity);
                    }
                    else if (i == 1)
                    {
                        Instantiate(cubePrefab, worldPosition, Quaternion.identity);
                    }
                    else if (i == 2)
                    {
                        Instantiate(capsulePrefab, worldPosition, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(cylinderPrefab, worldPosition, Quaternion.identity);
                    }

                    // Increase object count after new object is spawned.
                    IncreaseObjectCount();
                }
            }
        }
    }

    // Increase the object counter and update the object count in the Text component.
    private void IncreaseObjectCount()
    {
        objectCount++;
        objectCountText.text = "Object count: " + objectCount;
    }

    // Decrease the object counter and update the object count in the Text component.
    public void DecreaseObjectCount()
    {
        objectCount--;
        objectCountText.text = "Object count: " + objectCount;
    }

    // Add one score to the score counter and update score counter Text component.
    public void AddScore()
    {
        // Increase score count by one and update text.
        scoreCount++;
        scoreCountText.text = "Score" + "\n" + scoreCount;

        // If level increase limit is reached, increase level count.
        if (scoreCount >= levelIncreaseScoreLimit)
        {
            // Increase level count and update text.
            levelCount++;
            levelText.text = "Level" + "\n" + levelCount;

            // Set score count to zero when level increases.
            scoreCount = 0;
        }
    }
}