using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region ΩÃ±€≈Ê
    public static GameManager instance = null;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    public bool isGameover = false;
    public TextMeshProUGUI ScoreText;
    public GameObject gameover_UI;
    public int Score = 0;
    public Text finalScoreText;
    public Text playerRank, playerNick, playerScore;
    public InputField nickInput;
    public static List<User> users = new List<User>();

    [SerializeField] private bool isInput = false;

    public void ReStart()
    {
        if (isGameover)
        {
            isGameover = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int score)
    {
        if (!isGameover)
        {
            Score += score;
            ScoreText.text = Score.ToString();
        }
    }

    public void PlayerDead()
    {
        GameOver();
        isGameover = true;
        gameover_UI.SetActive(true);
    }

    public void GameOver()
    {
        ScoreText.enabled = false;
        finalScoreText.text = string.Format("FinalScore: " + Score.ToString());
    }

    public void InputNickname()
    {
        if (!isInput)
        {
            string name = "";
            string score = "";
            users.Add(new User(nickInput.text, Score));

            users.Sort((ScoreA, ScoreB) => ScoreB.score.CompareTo(ScoreA.score));

            for (int i = 0; i < users.Count; i++)
            {
                name = name + users[i].nickname + "\n";
                score = score + users[i].score + "\n";
                Debug.Log(name);
                Debug.Log(score);
            }
            playerNick.text = name;
            playerScore.text = score;
            isInput = true;
        }
        else return;
    }
}

[System.Serializable]
public class User
{
    public string nickname;
    public int score;

    public User(string nickname, int score)
    {
        this.nickname = nickname;
        this.score = score;
    }
}

public class Data
{
    public User[] users;
}
