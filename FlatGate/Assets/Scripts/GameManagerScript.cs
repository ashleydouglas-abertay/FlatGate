using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Variables
    public Sprite clickedSprite;
    public Sprite unClickedSprite;
    private bool changed = false;
    private float spriteCooldown = 0;
    private Vector3 mousePos;
    private int targetID = 0;

    private GameObject player;

    // Use this for initialization
    void Start ()
    {
        // Hide windows cursor
        Cursor.visible = false;

        // Find player object
        player = GameObject.FindGameObjectWithTag("Player");

        // Set mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Move cursor
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // Set mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Move cursor
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        // Detect click for movement
        if (Input.GetMouseButtonDown(0))
        {
            // Change visable sprite
            GetComponent<SpriteRenderer>().sprite = clickedSprite;
            changed = true;
            spriteCooldown = 0.25f;

            // Checks if move is possible
            if (targetID == 0)
            {
                // Update player on target
                player.GetComponent<PlayerGoToScript>().SetTargetPos(mousePos);
            }
            // Checks if target should activate a script
            else if (targetID == 1)
            {
                // Sends id to another script
                GetComponent<InteractionManagerScript>().interaction(targetID);
            }
        }
        else if (changed)
        {
            // Prevents sprite from flashing
            if (spriteCooldown > 0)
            {
                spriteCooldown -= Time.deltaTime;
            }
            else
            {
                // Change visable sprite
                GetComponent<SpriteRenderer>().sprite = unClickedSprite;
                spriteCooldown = 0;
                changed = false;
            }
        }
    }

    // Check for cursor collision
    void OnTriggerEnter2D(Collider2D target)
    {
        // Find id for interactable objects
        if (target.gameObject.tag == "InteractObject")
        {
            // Set ID to match
            targetID = target.gameObject.GetComponent<InteractObjectScript>().getID();
            Debug.Log("Target ID: " + targetID);
        }
        else
        {
            // Set ID to Default
            targetID = 0;
        }
    }

    // Resets cursor collision
    void OnTriggerExit2D(Collider2D target)
    {
        // Set ID to Default
        targetID = 0;
    }
}
