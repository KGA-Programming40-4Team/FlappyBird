using UnityEngine;
using System;
using System.IO;

// 2.2 Json 데이터 클래스 생성
[Serializable]
public class JsonData
{
    public string name;
    public int age;
    public float height;
    public bool man;
    public string description;
    public string[] tools;
}

public class DataManager : MonoBehaviour
{
    // 싱글톤
    public static DataManager instance = null;
    public Data playerData = new Data();
    string path;
    string fileName = "saveRanking";

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
        path = Application.persistentDataPath + "/";
        Debug.Log(path);
    }

    private void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(playerData);
        File.WriteAllText(path + fileName, data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + fileName);
        playerData = JsonUtility.FromJson<Data>(data);
        Debug.Log(playerData.nickname + ", " + playerData.score);
    }
}

public class Data
{
    public string nickname; // 닉네임
    public int score;       // 점수
}