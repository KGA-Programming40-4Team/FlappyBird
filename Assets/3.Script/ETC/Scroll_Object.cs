using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Object : MonoBehaviour
{

    public float Speed = 10f;

    // Update is called once per frame
    void Update()
    {
        //if (!GameManager.Instance.isGameover && !GameManager.Instance.isWin)
        //{
            transform.Translate(new Vector3(0, 0, Speed * Time.deltaTime));
        //}
    }
}
