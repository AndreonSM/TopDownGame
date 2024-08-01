using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogBox;
    public Image profile;
    public Text name;
    public Text text;


    [Header("Settings")]
    public float typingSpeed;
    private List<string> textList;
    private int index = 0;


    public void speech(Sprite profile, string name, List<string> text)
    {
        dialogBox.SetActive(true);
        this.profile.sprite = profile;
        this.name.text = name;
        textList = text;
        StartCoroutine(TypeTextList());
    }

    public void hideDialog()
    {
        dialogBox.SetActive(false);
    }

    IEnumerator TypeTextList()
    {
        text.text = "";
        foreach (char letter in textList[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextText()
    {
        if (text.text == textList[index])
        {
            if (index < textList.Count -1)
            {
                index++;
                text.text = "";
                StartCoroutine(TypeTextList());
            }
            else
            {
                text.text = "";
                index = 0;
                dialogBox.SetActive(false);
            }
        }
    }

}
