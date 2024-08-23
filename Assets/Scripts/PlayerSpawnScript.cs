using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Find the player GameObject
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Set the player position to the spawn position stored in the GameManager
        if (player != null)
        {
            player.transform.position = GameController.instance.playerSpawnPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

