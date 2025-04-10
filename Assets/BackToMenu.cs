using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}