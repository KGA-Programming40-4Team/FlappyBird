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

public class SaveManager : MonoBehaviour
{
    Data data = new Data() { name = "정수민", score = 100 };

    private void Start()
    {
        // 제이슨으로 변환
        string jsonData = JsonUtility.ToJson(data);
        Debug.Log(jsonData);
    }
}

public class Data
{
    public string name;
    public int score;
}