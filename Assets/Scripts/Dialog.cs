using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [Header("Components")]
    public Sprite profile;
    public string name;
    public List<string> textList;
    private DialogController dialogController;

    private void Start()
    {
        dialogController = FindObjectOfType<DialogController>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogController.speech(profile, name, textList);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogController.hideDialog();
        }
    }

}
