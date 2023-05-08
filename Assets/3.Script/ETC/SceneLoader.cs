using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void SceneChanger(string name)
    {
        SceneManager.LoadScene(name); //씬이동 게임시작화면에서 게임으로
    }
}
