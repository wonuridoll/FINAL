using UnityEngine;

public class StartButton : MonoBehaviour
{
    void OnMouseDown()
    {
        // This runs when the GameObject is clicked
        Debug.Log("Clicked on " + gameObject.name);
        // Add your event here
    }
}