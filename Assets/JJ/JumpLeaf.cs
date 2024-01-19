using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLeaf : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.onJumpLeaf = true;
                Debug.Log("Player entered JumpLeaf trigger zone");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.onJumpLeaf = false;
                Debug.Log("Player exited JumpLeaf trigger zone");
            }
        }
    }
}
