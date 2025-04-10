using Unity.Cinemachine;
using UnityEngine;

public class ThirdMapTransition : MonoBehaviour
{
    [SerializeField] private BoxCollider2D mapBoundary;
    [SerializeField] private GameObject mapSpawnPoint; // New field for spawn point
    [SerializeField] private Direction direction;

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
            }
            else
            {
                Debug.LogWarning("Map spawn point is not assigned in the inspector!");
            }
        }
    }
}
