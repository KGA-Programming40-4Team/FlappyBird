using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void SceneChanger(string name)
    {
        SceneManager.LoadScene(name); //���̵� ���ӽ���ȭ�鿡�� ��������
    }
}
