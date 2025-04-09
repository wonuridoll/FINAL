using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Optional: save character name
        PlayerPrefs.SetString("SelectedCharacter", gameObject.name);

        // Load main game scene
        SceneManager.LoadSceneAsync("MainGame");
    }
}
