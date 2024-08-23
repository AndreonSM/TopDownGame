using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOverScreen;
    
    public string mainMenuSceneName = "Menu";


    public Vector3 playerSpawnPosition;

    public float playerCurrentHealth = 50;
    public float playerMaxHealth = 50;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (gameOverScreen != null)
            {
                gameOverScreen.SetActive(false);
                DontDestroyOnLoad(gameOverScreen);
            }
            else
            {
                Debug.Log("GameOverScreen is not assigned in the Inspector!");
            }

        }
        else if (instance != this)
        {
            Destroy(gameObject); // destruir caso tenha uma instãncia DIFERENTE
        }
        Debug.Log(gameOverScreen);

    }

    

    void Start()
    {
        // Reatribuir referências ao iniciar a cena
    }

    void OnEnable()
    {
        // Registrar o callback para ser chamado após a cena ser carregada
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Remover o callback para evitar chamadas desnecessárias
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (gameOverScreen == null)
        {
            // Reassign gameOverScreen by finding it again
            gameOverScreen = GameObject.Find("GameOverCanvas");
            if (gameOverScreen != null)
            {
                DontDestroyOnLoad(gameOverScreen);
                gameOverScreen.SetActive(false); // Hide it initially
            }
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Pausa o jogo
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Retoma o jogo

        if (GameController.instance != null)
        {
            GameController.instance.playerCurrentHealth = GameController.instance.playerMaxHealth;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        gameOverScreen.SetActive(false);

    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Retoma o jogo
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void SetPlayerSpawnPosition(Vector3 newPosition)
    {
        playerSpawnPosition = newPosition;
    }
}
