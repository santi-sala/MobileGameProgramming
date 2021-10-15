using UnityEngine;

// Collision detecetion MonoBehaviour that should be attached to colliding objects.
public class CollisionDetection : MonoBehaviour
{
    private bool hasTouchedWorldCollider = false;
    private bool isDestroyed = false;

    // This method is automatically called each time a collision occurs with the game object that this script is attached to.
    private void OnCollisionEnter(Collision collision)
    {
        // Never run this logic twice for objects that have already collided. This is to make sure that score count always remains correct.
        if (isDestroyed)
        {
            return;
        }

        // Require at least one collision with world bound colliders before accepting collision with similar objects.
        if (!hasTouchedWorldCollider && collision.gameObject.CompareTag("World"))
        {
            hasTouchedWorldCollider = true;
            Debug.Log("Has touch world");
        }

        // If the object has collided with the world bound colliders, destroy it when it collides with a similar object.
        if (hasTouchedWorldCollider && collision.gameObject.CompareTag(tag))
        {
            Debug.Log("Destroying object with tag: " + tag);

            // Mark this object destroyed to avoid calling this logic again.
            isDestroyed = true;

            // Destroy this game object.
            Destroy(gameObject);

            // Add one score for each destroyed object.
            GameController.Instance.AddScore();

            // Decrease object count so that the counter reflects correct count.
            GameController.Instance.DecreaseObjectCount();
        }
    }
}