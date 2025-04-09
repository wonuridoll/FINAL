using UnityEngine;
using Unity.Cinemachine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] availableCharacters;  // Array to store all character prefabs
    public Transform spawnPoint;  // Reference to the spawn point (you will assign this in the Inspector)
    public CinemachineCamera virtualCamera;  // Reference to your Cinemachine Virtual Camera

    void Start()
    {
        // Get the selected character name from PlayerPrefs
        string selectedCharacterName = PlayerPrefs.GetString("SelectedCharacter", "DefaultCharacter");

        // Loop through the available characters and instantiate the correct one
        foreach (GameObject character in availableCharacters)
        {
            if (character.name == selectedCharacterName)
            {
                // Instantiate the character at the spawn point position
                GameObject spawnedCharacter = Instantiate(character, spawnPoint.position, Quaternion.identity);

                // Ensure that the Cinemachine camera follows the new character
                virtualCamera.Follow = spawnedCharacter.transform;  // Update Follow target
                virtualCamera.LookAt = spawnedCharacter.transform;  // Update LookAt target

                return;  // Exit once the character has been found and spawned
            }
        }

        Debug.LogWarning("Selected character not found! Make sure the character names match.");
    }
}
