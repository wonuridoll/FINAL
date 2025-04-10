using UnityEngine;

public class DestroyOnCollision : MonoBehaviour

{

    // This method is called when the collider attached to this GameObject collides with another collider.

    private void OnCollisionEnter2D(Collision2D collision)

    {

        // Check if the collision is with the specific object you want to destroy

        if (collision.gameObject.CompareTag("Player")) // Replace "Collider" with the tag you want to check

        {

            // Destroy this GameObject

            Destroy(gameObject);

        }

    }

}