using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject dialogBox;
    public Text dialogText;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }

    public void ShowDialog(string line)
    {
        dialogBox.SetActive(true);
        dialogText.text = line;
    }

    public void HideDialog()
    {
        dialogBox.SetActive(false);
    }
}
