using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Variables
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // Detect click for movement
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.GetComponent<PlayerGoToScript>().SetTargetPos(mousePos);
            Debug.Log("Mouse Triggered");
        }
    }
}
