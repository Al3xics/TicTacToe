using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AI
{
    List<int> choice = new();
    string[] TabAI = new string[9];

    public int BestPosition()
    {
        // Récupération du tableau
        string[] source = GameObject.Find("Game Manager").GetComponent<GameManager>().Tab;
        Array.Copy(source, TabAI, source.Length);

        choice.Clear();

        for (int i = 0; i < TabAI.Length; i++)
        {
            if (TabAI[i] == string.Empty)
                choice.Add(i);
        }

        // Y a t-il un coup gagnant ?
        for (int i = 0; i < TabAI.Length; i++)
        {
            if (TabAI[i] == string.Empty)
            {
                TabAI[i] = "O";
                if (CheckWin("O"))
                {
                    Debug.Log("Coup gagnant");
                    return i;
                }
                TabAI[i] = string.Empty;
            }
        }

        // Y a t-il un coup gagnant pour l'adversaire ?
        for (int i = 0; i < TabAI.Length; i++)
        {
            if (TabAI[i] == string.Empty)
            {
                TabAI[i] = "X";
                if (CheckWin("X"))
                {
                    Debug.Log("Coup gagnant pour l'adversaire");
                    return i;
                }
                TabAI[i] = string.Empty;
            }
        }

        // Aléatoire
        return choice[UnityEngine.Random.Range(0, choice.Count)];
    }

    private bool CheckWin(string p)
    {
        if (TabAI[0] == p && TabAI[1] == p && TabAI[2] == p ||
            TabAI[3] == p && TabAI[4] == p && TabAI[5] == p ||
            TabAI[6] == p && TabAI[7] == p && TabAI[8] == p ||
            TabAI[0] == p && TabAI[3] == p && TabAI[6] == p ||
            TabAI[1] == p && TabAI[4] == p && TabAI[7] == p ||
            TabAI[2] == p && TabAI[5] == p && TabAI[8] == p ||
            TabAI[0] == p && TabAI[4] == p && TabAI[8] == p ||
            TabAI[2] == p && TabAI[4] == p && TabAI[6] == p)
        {
            return true;
        }
        return false;
    }
}
