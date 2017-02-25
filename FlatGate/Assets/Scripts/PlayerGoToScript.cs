using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoToScript : MonoBehaviour
{
    // Variables
    public Vector3 startPos;
    public float moveSpeed;

    private Vector3 moveVelo = new Vector3(0, 0, 0);
    private float momentum = 0;

    public Vector3 ForcedTargetPos;
    private Vector3 currPos;
    private Vector3 targetPos;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // DEBUGINFO
        targetPos = ForcedTargetPos;
        // END

        // Set current position
        currPos = transform.position;

        // Checks to see if current position is at target
        if (currPos.x <= targetPos.x - 0.5 || currPos.x >= targetPos.x + 0.5)
        {
            // Work out movement needed
            moveVelo.x = targetPos.x - currPos.x;
            // Normalize movement
            moveVelo.Normalize();

            // Calculate momentum
            if (momentum == 0)
            {
                momentum = 0.1f;
            }
            else
            {
                if (momentum < 0.75f)
                {
                    momentum = momentum * 1.25f;
                }
                else
                {
                    momentum = 1.0f;
                }
            }

            // Apply movement
            transform.position += (moveVelo * moveSpeed * momentum * Time.deltaTime);
        }
        else
        {
            // Reset momentum
            momentum = 0;
        }
	}

    // Sets the players target position
    public void SetTargetPos(Vector3 newTargetPos)
    {
        targetPos = newTargetPos;
        Debug.Log("Target Changed");
    }
}
