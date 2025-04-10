using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    // This method is called when the collider attached to this GameObject enters a trigger collider.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the trigger is colliding with the player
        if (collider.gameObject.CompareTag("Player")) // Replace "Player" with the tag of the object you want to check
        {
            // Destroy this GameObject
            Destroy(gameObject);
        }
    }
}
