using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManagerScript : MonoBehaviour
{
    // Variables
    private int interactionID = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // Case statement for each id
		switch (interactionID)
        {
            // Test case resets after use
            case 1:
                Debug.Log("Case 1");
                interactionID = 0;
                break;
            // Default case does nothing
            default:
                break;
        }
	}

    // Sets id when changed
    public void interaction(int newInteractID)
    {
        // Saves over variable
        interactionID = newInteractID;
    }
}
