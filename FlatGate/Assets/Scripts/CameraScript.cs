using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Varaibles
    public float minX;
    public float maxX;

    private Vector3 currPos;
    private Vector3 playerPos;
    private Vector3 cursorPos;

    private GameObject player;
    private GameObject cursor;

    // Use this for initialization
    void Start ()
    {
        // Find player object
        player = GameObject.FindGameObjectWithTag("Player");
        // Find game manager object
        cursor = GameObject.FindGameObjectWithTag("Manager");

        // Set current position
        currPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Get positions
        playerPos = player.GetComponent<PlayerGoToScript>().getPos();
        cursorPos = cursor.GetComponent<GameManagerScript>().getPos();

        // Calculate range
        if ((playerPos.x >= (currPos.x - 9.0f)) && (playerPos.x <= (currPos.x + 9.0f)))
        {
            // Calculate movement
            currPos.x = (playerPos.x + cursorPos.x) / 2;
        }
        else if (playerPos.x < (currPos.x - 9.0f))
        {
            // Calculate movement ??????????????????????????????????????????????????????????????????????????? FIX ME ASHREY
            currPos.x = (playerPos.x + 9.0f);
        }

        // makes sure screen is still in bounds
        if (currPos.x < minX + 8.9f)
        {
            currPos.x = minX + 8.9f;
        }
        else if (currPos.x > maxX - 8.9f)
        {
            currPos.x = maxX - 8.9f;
        }

        // Apply movement
        transform.position = currPos;
    }
}
