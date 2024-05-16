using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string[] Tab = new string[9];
    public GameObject panelGameOver;

    private AI ai = new();

    void Start()
    {
        int turn = Random.Range(0, 2);

        if (turn == 0) ComputerPlay();
    }

    public void ComputerPlay()
    {


        int button = ai.BestPosition();

        Button btn = GameObject.Find(button.ToString()).GetComponent<Button>();
        btn.interactable = false;
        Color colorFromHex;
        ColorUtility.TryParseHtmlString("#001693", out colorFromHex);
        TMP_Text tmp_text = btn.GetComponentInChildren<TMP_Text>();
        tmp_text.text = "O";
        tmp_text.color = colorFromHex;

        Tab[button] = "O";

        if (CheckWin("O"))
        {
            Debug.Log("Computer Win !");
            panelGameOver.SetActive(true);
            return;
        }

        if (MatchNull() )
        {
            Debug.Log("Match Null !");
            panelGameOver.SetActive(true);
            ColorMatchNull();
            return;
        }
    }

    public bool CheckWin(string p)
    {
        // Horizontal
        if (Tab[0] == p && Tab[1] == p && Tab[2] == p)
        {
            ColorWinner(0, 1, 2);
            return true;
        }

        if (Tab[3] == p && Tab[4] == p && Tab[5] == p)
        {
            ColorWinner(3, 4, 5);
            return true;
        }

        if (Tab[6] == p && Tab[7] == p && Tab[8] == p)
        {
            ColorWinner(6, 7, 8);
            return true;
        }


        // Vertical
        if (Tab[0] == p && Tab[3] == p && Tab[6] == p)
        {
            ColorWinner(0, 3, 6);
            return true;
        }

        if (Tab[1] == p && Tab[4] == p && Tab[7] == p)
        {
            ColorWinner(1, 4, 7);
            return true;
        }

        if (Tab[2] == p && Tab[5] == p && Tab[8] == p)
        {
            ColorWinner(2, 5, 8);
            return true;
        }


        // Diagonal
        if (Tab[0] == p && Tab[4] == p && Tab[8] == p)
        {
            ColorWinner(0, 4, 8);
            return true;
        }

        if (Tab[2] == p && Tab[4] == p && Tab[6] == p)
        {
            ColorWinner(2, 4, 6);
            return true;
        }


        return false;
    }

    public bool MatchNull()
    {
        for (int i = 0; i < Tab.Length; i++)
        {
            if (Tab[i] == string.Empty) return false;
        }

        return true;
    }

    public void ColorWinner(int c1, int c2, int c3)
    {
        GameObject.Find(c1.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.green;
        GameObject.Find(c2.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.green;
        GameObject.Find(c3.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.green;
    }

    public void ColorMatchNull()
    {
        for(int i = 0;i < Tab.Length;i++)
        {
            GameObject.Find(i.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.red;
        }
    }
}
