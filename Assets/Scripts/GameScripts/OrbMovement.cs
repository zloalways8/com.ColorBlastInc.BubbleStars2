using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the orb
    private Vector3 targetPosition; // Target position to move towards
    private bool isMoving = false; // Whether the orb is currently moving
    private bool isActionComplete = true; // Flag to prevent multiple actions

    // Move the orb to a target position
    public void MoveToTarget(Vector3 targetPos, System.Action onComplete)
    {
        GameObject.Find("MainCameraStar").GetComponent<SoundsManagerStar>().PlayPingStar();
        if (!isActionComplete) return; // Prevent moving again if the previous action is not complete
        isActionComplete = false; // Prevent further actions while moving

        targetPosition = new Vector3(targetPos.x-GetComponent<SpriteRenderer>().bounds.size.x,targetPos.y,targetPos.z);
        isMoving = true;

        // Start the move coroutine
        StartCoroutine(MoveCoroutine(onComplete));
    }

    // Coroutine to move the orb smoothly towards the target
    private IEnumerator MoveCoroutine(System.Action onComplete)
    {
        while (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                isMoving = false;
                GetComponent<OrbScript>().position.x=targetPosition.x;
                GetComponent<OrbScript>().position.y = targetPosition.y;
                GetComponent<OrbSelection>().active = true;
                onComplete?.Invoke();
            }
            yield return null;
        }
    }

    // Set isActionComplete to true after the action is done
    public void ActionComplete()
    {
        isActionComplete = true;
        Debug.Log("REACHED ActionComplete");
    }
}
