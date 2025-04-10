using UnityEngine;

public class ZomFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;

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
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}