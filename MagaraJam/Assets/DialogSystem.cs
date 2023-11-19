using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;
    public string[] dialogs;
    public GameObject cntButton;

    private int index;

    public float wordSpeed;
    public bool playerIsClose;



    private void Update()
    {
        Dialog();
    }

    void Dialog()
    {
        if(Input.GetKey(KeyCode.E) && playerIsClose)
        {
            if (dialogPanel.activeInHierarchy)
            {

            }
            else
            {
                dialogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogText.text == dialogs[index])
        {
            cntButton.SetActive(true);
        }


    }

    public void NextLine()
    {
        cntButton.SetActive(false);

        if(index < dialogs.Length - 1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    void zeroText()
    {
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogs[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            playerIsClose = true;
        }
       

    }

    private void OnTriggerExitr2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            playerIsClose = false;
        }


    }
}
