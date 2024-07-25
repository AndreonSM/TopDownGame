using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField] private List<GameObject> screenList;
    [SerializeField] private GameObject currentScreen;

    private void Start()
    {
        screenList.ForEach(screen =>
        {
            if(screen.activeSelf == true)
            {
                currentScreen = screen;
            }
        });
    }

    public void goToScreen(int targetScreen)
    {
        currentScreen.SetActive(false);
        screenList[targetScreen].SetActive(true);
        currentScreen = screenList[targetScreen];
    }

    public void loadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
