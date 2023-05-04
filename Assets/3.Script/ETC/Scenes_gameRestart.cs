using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_gameRestart : MonoBehaviour
{
    public void SceneChanger()
    {
        SceneManager.LoadScene("Scenes/intro"); //씬이동 게임오버에서 스타트로
    }
}

