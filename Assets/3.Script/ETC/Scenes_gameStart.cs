using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_gameStart : MonoBehaviour
{
    public void SceneChanger()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
}
