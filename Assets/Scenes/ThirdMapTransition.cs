using Unity.Cinemachine;
using UnityEngine;
using System.Collections; // Don't forget to include this for coroutines

public class ThirdMapTransition : MonoBehaviour
{
    [SerializeField] private BoxCollider2D mapBoundary;
    [SerializeField] private GameObject mapSpawnPoint; // New field for spawn point
    [SerializeField] private Direction direction;
    [SerializeField] private GameObject zombie; // Reference to the zombie object

    private CinemachineConfiner2D confiner;

    private enum Direction { Up, Down, Left, Right }

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundary;

            if (mapSpawnPoint != null)
            {
                collision.gameObject.transform.position = mapSpawnPoint.transform.position;

                // Start coroutine to teleport the zombie after a delay
                if (zombie != null)
                {
                    StartCoroutine(TeleportZombieAfterDelay(1f)); // 2 seconds delay
                }
            }
            else
            {
                Debug.LogWarning("Map spawn point is not assigned in the inspector!");
            }
        }
    }

    private IEnumerator TeleportZombieAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        if (zombie != null && mapSpawnPoint != null)
        {
            zombie.transform.position = mapSpawnPoint.transform.position; // Teleport zombie to the spawn point
        }
    }
}