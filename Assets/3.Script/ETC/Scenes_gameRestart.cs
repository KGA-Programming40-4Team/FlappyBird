using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_gameRestart : MonoBehaviour
{
    public void SceneChanger()
    {
        SceneManager.LoadScene("Scenes/intro");
    }
}

