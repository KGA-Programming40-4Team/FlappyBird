using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //아이템 효과중인지에 대한 bool변수
    private bool isGoast = false;
    private bool isInk = false;

    //아이템에 따른 효과를 위해 SpriteRenderer 
    private Renderer renderer;
    [SerializeField] GameObject player;
    private void Awake()
    {
        //초기화
        renderer = GetComponent<Renderer>();
        isGoast = true;
        isInk = true;

    }

    private void Update()
    {
        if (isGoast)
        {
            Material[] ms = renderer.materials;
            for(int i=0;i<ms.Length;i++)
            {
                Color alpha = ms[i].color;
                alpha.a = 0.1f;
                renderer.materials[i].color = alpha;

            }

        }
    }

    //아이템과 접촉하였을 때
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goast"))
        {


        }
        if (other.CompareTag("INK"))
        {

        }
    }
    public void Goasted()
    {
        /*
         * 1. 플레이어 알파값 조정
         * 2. isGoasted라면 충돌X
         * 3. itemTime = 3초로 한다.
         */

        int i = 40;
        Color alpha = renderer.material.color;
        alpha.a = i;
        renderer.material.color = alpha;

    }
    public void Inked()
    {
        /*
         * 1.스크린에 먹물효과를 알파값 조정으로 부드럽게 보여주고
         * 2.2초 유지 후 시작과 같이 부드럽게 조절
         * 
         */
    }

    IEnumerator goast()
    {
        int i = 40;
        Color alpha = renderer.material.color;
        alpha.a = i;
        renderer.material.color = alpha;
        yield return new WaitForSeconds(3f);
    }
}
