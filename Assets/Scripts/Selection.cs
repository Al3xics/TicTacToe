using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void WriteX()
    {
        Color colorFromHex;
        ColorUtility.TryParseHtmlString("#930700", out colorFromHex);
        TMP_Text tmp_text = GetComponentInChildren<TMP_Text>();
        tmp_text.text = "X";
        tmp_text.color = colorFromHex;
        GetComponent<Button>().interactable = false;
        gameManager.Tab[int.Parse(gameObject.name)] = "X";

        if (gameManager.CheckWin("X"))
        {
            Debug.Log("Player Win !");
            gameManager.panelGameOver.SetActive(true);
            return;
        }
        else if (gameManager.MatchNull())
        {
            Debug.Log("Match Null !");
            gameManager.panelGameOver.SetActive(true);
            gameManager.ColorMatchNull();
            return;
        }
        else
        {
            gameManager.ComputerPlay();
        }
    }
}
