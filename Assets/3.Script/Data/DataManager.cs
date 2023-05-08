using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;
using LitJson;

// 2.2 Json 데이터 클래스 생성

public class DataManager : MonoBehaviour
{
    // 싱글톤
    public static DataManager instance = null;
    string path;
    string fileName = "database.json";
    string data = "";


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
        path = Path.Combine(Application.dataPath + "/9.Data/");
        Debug.Log(path);

        LoadData();
    }


    public void SaveData()
    {
        //User[] users = GameManager.users.ToArray();
        Data newData = new Data
        {
            users = GameManager.users.ToArray()
        };

        string json = JsonUtility.ToJson(newData);
        json = json.Replace("\"users\":", "");
        json = json.TrimEnd('}');
        json = json.TrimStart('{');
        Debug.Log(json);

        File.WriteAllText(path + fileName, json);
    }

    public void LoadData()
    {
        string nickname = "";
        int score = 0;
        data = File.ReadAllText(path + fileName);
        JsonData jsonData = JsonMapper.ToObject(data);

        for (int i = 0; i < jsonData.Count; i++)
        {
            nickname = jsonData[i]["nickname"].ToString();
            score = int.Parse(jsonData[i]["score"].ToString());
            GameManager.users.Add(new User(nickname, score));
            Debug.Log(GameManager.users[i].nickname + ", " + GameManager.users[i].score);
        }


    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}