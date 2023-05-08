using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //아이템 효과중인지에 대한 bool변수
    public bool isGoast = false;
    public bool isInk = false;

    //아이템에 따른 효과를 위해 SpriteRenderer 
    private Renderer renderer;
    [SerializeField] GameObject player;

    //잉크 효과를 위한 raw image 선언
    [SerializeField] public RawImage ink_img;
    
    //itemtime = 3초
    private float itemTime = 3f;

    private void Awake()
    {
        //초기화
        renderer = GetComponentInChildren <Renderer>();
        isGoast = false;
        isInk = false;
        
    }

   

    //아이템과 접촉하였을 때
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goast"))
        {
            isGoast = true;
            other.gameObject.SetActive(false);
            Goasted();
            stopItem("StopGoast");
        }
        if (other.CompareTag("Ink"))
        {
            isInk = true;
            other.gameObject.SetActive(false);
            Inked();
            stopItem("Clear");
        }
    }
    private void Goasted()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Renderer ren))
            {
                for (int i = 0; i < ren.materials.Length; i++)
                {
                    Color alpha = ren.materials[i].color;
                    alpha.a = 0.3f;
                    ren.materials[i].color = alpha;
                }
            }
        }
    }
    public void StopGoast()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Renderer ren))
            {
                for (int i = 0; i < ren.materials.Length; i++)
                {
                    Color alpha = ren.materials[i].color;
                    alpha.a = 1f;
                    ren.materials[i].color = alpha;
                }
            }
        }
        isGoast = false;
    }
    public void Inked()
    {
        /*
         * 1.스크린에 먹물효과를 알파값 조정으로 부드럽게 보여주고
         * 2.2초 유지 후 시작과 같이 부드럽게 조절
         */
        ink_img.gameObject.SetActive(true);
    }
    public void Clear()
    {
        isInk = false;
        ink_img.gameObject.SetActive(false);
    }

    //아이템 정지
    public void stopItem(string name)
    {
        switch (name)
        {
            case "StopGoast":
                {
                    if (isGoast)
                    {
                        CancelInvoke("StopGoast");
                        Debug.Log("StopGoast cancel");
                        Invoke("StopGoast", itemTime);
                    }
                    else
                    {
                        Invoke("StopGoast", itemTime);
                    }
                    break;
                }
            case "Clear":
                {
                    if (isInk)
                    {
                        CancelInvoke("Clear");
                        Debug.Log("Clear cancel");
                        Invoke("Clear", itemTime);
                    }
                    else
                    {
                        Invoke("Clear", itemTime);
                    }
                    break;
                }
        }
    }

}
