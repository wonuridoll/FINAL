using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class Jumpscare : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string sceneToLoad = "NextSceneName";

    private bool hasTriggered = false;
    private GameObject player;
    private GameObject zombie;

    private void Start()
    {
        // Set up but no fading
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(PlayCutscene());
        }
    }

    private IEnumerator PlayCutscene()
    {
        // Wait until the player is spawned in the scene
        while (player == null)
        {
            player = GameObject.FindWithTag("Player");
            yield return null;
        }

        // Wait until the Zombie is spawned (assuming it's also tagged or identifiable)
        while (zombie == null)
        {
            zombie = GameObject.Find("Zombie"); // or use "Zombie" if the zombie is named specifically
            yield return null;
        }

        // Play the video first (so the player and zombie disappear immediately after)
        videoPlayer.Play();

        // Hide the player and the zombie right after the video starts
        player.SetActive(false);
        if (zombie != null)
        {
            zombie.SetActive(false);
        }

        // Listen for video end to trigger scene change
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // Change to the next scene after the video ends
        SceneManager.LoadScene(sceneToLoad);
    }
}
