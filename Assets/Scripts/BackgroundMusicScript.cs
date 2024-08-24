using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{

    public static BackgroundMusicScript instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return; // Stop further execution in this duplicate instance
        }

    }

}
