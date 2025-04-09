using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] BoxCollider2D mapBoundary;
    CinemachineConfiner2D confiner;
    [SerializeField] Direction direction;

    enum Direction { Up, Down, Left, Right }

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundary;
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject Player)
    {
        Vector3 newPos = Player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                newPos.y += 2;
                break;
            case Direction.Down:
                newPos.y -= 2;
                break;
            case Direction.Left:
                newPos.x -= 2;
                break;
            case Direction.Right:
                newPos.x += 2;
                break;
        }    
        Player.transform.position = newPos;
    }
}
