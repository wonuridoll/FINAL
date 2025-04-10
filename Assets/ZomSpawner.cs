using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public GameObject character; // Reference to the character GameObject
    public Transform spawnPoint; // Reference to the spawn point
    private bool characterSpawned = false;

    private void Start()
    {
        // Deactivate the character at the start
        if (character != null)
        {
            character.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding with the trigger is the player
        if (other.CompareTag("Player") && !characterSpawned)
        {
            // Set the character's position to the spawn point
            character.transform.position = spawnPoint.position;
            // Activate the character
            character.SetActive(true);
            characterSpawned = true; // Ensure the character only spawns once
        }
    }
}
