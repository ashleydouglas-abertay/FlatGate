using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObjectScript : MonoBehaviour
{
    // Variables
    public int interactionId;

	// Use this for initialization
	void Start ()
    {
		
	}

    // Returns object ID
    public int getID()
    {
        return interactionId;
    }
}
