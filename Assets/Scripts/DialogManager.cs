using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    /**** Variables. ****/
    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive;

    private string[] dialogLines;
    public int currentDialogLine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentDialogLine++;
            }

            if (currentDialogLine >= dialogLines.Length)
            {
                dialogActive = false;
                dialogBox.SetActive(false);
                currentDialogLine = 0;
            }
            else
            {
                dialogText.text = dialogLines[currentDialogLine];
            }
        }
    }

    public void ShowDialog(string[] lines)
    {
        dialogActive = true;
        dialogBox.SetActive(true);
        currentDialogLine = 0;
        dialogLines = lines;
    }
}