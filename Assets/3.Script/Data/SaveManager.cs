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

public class SaveManager : MonoBehaviour
{
    Data data = new Data() { name = "������", score = 100 };

    private void Start()
    {
        // ���̽����� ��ȯ
        string jsonData = JsonUtility.ToJson(data);
        Debug.Log(jsonData);
    }
}

public class Data
{
    public string name;
    public int score;
}