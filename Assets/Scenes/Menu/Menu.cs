using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CharacterSelect()
    {
        SceneManager.LoadSceneAsync("CharacterSelection");
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("MainGame");
    }
}
