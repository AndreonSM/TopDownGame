using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOverScreen;
    public Text gameOverText;
    public string mainMenuSceneName = "MainMenu";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // destruir caso tenha uma instãncia DIFERENTE!
        }
    }

    void Start()
    {
        // Reatribuir referências ao iniciar a cena
        ReassignReferences();
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
        // Reatribuir referências quando uma nova cena for carregada
        ReassignReferences();
    }

    void ReassignReferences()
    {
        // Busque novamente os objetos na cena
        // gameOverScreen = GameObject.Find("GameOverCanvas");
        // gameOverText = GameObject.Find("GameOvText").GetComponent<Text>();
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Pausa o jogo
        gameOverScreen.SetActive(true);
        gameOverText.text = "Game Over XD"; // Personalize a mensagem conforme necessário
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Retoma o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Retoma o jogo
        SceneManager.LoadScene(mainMenuSceneName);
    }
}

    /*
    public void RestartLevel(){
        
        lives--;
        if (lives > 0) {
            SceneManager.LoadScene(currentLevel);
        }
        else{
            lives = 3;
            currentLevel = 0;
            SceneManager.LoadScene(currentLevel);
        }
    }

    public void GoOnLevel(){
        currentLevel++;
        SceneManager.LoadScene(currentLevel);
    }


    public void GameOver()
    {
        // pegar tela de gameover
    }
    */

