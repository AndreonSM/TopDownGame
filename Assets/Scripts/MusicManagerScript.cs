using UnityEngine.SceneManagement;
using UnityEngine;

// Por enquanto, não tem uso no jogo; mas logo, logo...
// TODO
public class MusicManagerScript : MonoBehaviour
{

    public static MusicManagerScript instance;
    public AudioClip fieldMusic;
    public AudioClip houseMusic;
    public AudioClip woodsMusic;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        /*else
        {
            Destroy(gameObject);
            return; 
        } */

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Fields")
        {
            audioSource.clip = fieldMusic;
        }
        else if (scene.name == "PlayerHouse")
        {
            audioSource.clip = houseMusic;
        }
        else if (scene.name == "Woods")
        {
            audioSource.clip = woodsMusic;
        }

        audioSource.Play();
    }
}
