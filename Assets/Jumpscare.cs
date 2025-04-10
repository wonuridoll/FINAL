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

        // Play the video first (so the player disappears immediately after)
        videoPlayer.Play();

        // Hide the player right after video starts
        player.SetActive(false);

        // Listen for video end to trigger scene change
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // Change to the next scene after the video ends
        SceneManager.LoadScene(sceneToLoad);
    }
}
