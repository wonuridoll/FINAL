using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadSceneAsync("Credits");
    }
}