using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class OrbSelection : MonoBehaviour
{
    private OrbMovement leftOrbMovement; // Reference to the left orb's movement script
    private GameManager gameManager;
    public bool active = false;
    void Start()
    {
        // Get the GameManager instance and retrieve the reference to the left orb's movement script
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager in the scene
      
    }

    void OnMouseDown()
    {
        if (active)
        {
            if (gameManager != null)
            {
                leftOrbMovement = gameManager.GetLeftOrbMovement(); // Get the left orb's movement script
            }

            if (gameManager.GetLeftmostColumnPosition(GetComponent<OrbScript>()))
                leftOrbMovement.MoveToTarget(transform.position, OnMovementComplete);
        }
    }

    // This method is called when the movement is completed
    private void OnMovementComplete()
    {
        // After the orb reaches the target position, check for any matching lines of orbs
        if (gameManager != null)
        {
            gameManager.CheckForLines(); // Call the CheckForLines method in GameManager
        }
    }


}
