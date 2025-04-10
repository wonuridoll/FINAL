using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip mainMusic;
    public AudioClip gameMusic;
    public AudioClip houseMusic;

    private void Awake()
    {
        if (FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = mainMusic;
        musicSource.Play();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "2ndMap" && musicSource.clip != houseMusic)
        {
            musicSource.clip = houseMusic;
            musicSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "MainGame" && musicSource.clip != gameMusic)
        {
            musicSource.clip = gameMusic;
            musicSource.Play();
        }
        else if (SceneManager.GetActiveScene().name != "MainGame" && musicSource.clip != mainMusic)
        {
            musicSource.clip = mainMusic;
            musicSource.Play();
        }
    }
}
