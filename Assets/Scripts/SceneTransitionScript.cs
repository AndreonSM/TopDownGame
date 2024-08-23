using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Name of the scene to load, different for each transition area
    public string sceneToLoad;
    public Vector3 spawnPositionInTargetScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Set the spawn position in the GameManager
            GameController.instance.SetPlayerSpawnPosition(spawnPositionInTargetScene);
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
