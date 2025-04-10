using UnityEngine;

public class ZomFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;

    void Update()
    {
        // Keep checking until the player is found
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }

        // If the target is assigned, follow it
        if (target != null)
        {
            // Move toward the player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Flip sprite based on direction
            float direction = target.position.x - transform.position.x;
            Vector3 localScale = transform.localScale;

            if (direction < 0)
            {
                localScale.x = Mathf.Abs(localScale.x) * -1; // face left
            }
            else if (direction > 0)
            {
                localScale.x = Mathf.Abs(localScale.x); // face right
            }

            transform.localScale = localScale;

        }
    }
}
