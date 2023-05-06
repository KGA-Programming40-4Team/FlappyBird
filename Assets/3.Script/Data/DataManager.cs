using UnityEngine;
using System;
using System.IO;

// 2.2 Json ������ Ŭ���� ����
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
    // �̱���
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
    public string nickname; // �г���
    public int score;       // ����
}