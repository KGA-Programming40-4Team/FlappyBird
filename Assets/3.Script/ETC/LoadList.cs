using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadList : MonoBehaviour
{
    private void OnEnable()
    {
        if(GameManager.users.Count > 9)
        {
            GameManager.users.RemoveRange(9, GameManager.users.Count - 1);
        }

        string name = "";
        string score = "";

        GameManager.users.Sort((ScoreA, ScoreB) => ScoreB.score.CompareTo(ScoreA.score));

        for (int i = 0; i < GameManager.users.Count; i++)
        {
            name = name + GameManager.users[i].nickname + "\n";
            score = score + GameManager.users[i].score + "\n";
            Debug.Log(name);
            Debug.Log(score);
        }
        GameManager.instance.playerNick.text = name;
        GameManager.instance.playerScore.text = score;
    }
}
