using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //������ ȿ���������� ���� bool����
    public bool isGoast = false;
    public bool isInk = false;

    //�����ۿ� ���� ȿ���� ���� SpriteRenderer 
    private Renderer renderer;
    [SerializeField] GameObject player;

    //��ũ ȿ���� ���� raw image ����
    [SerializeField] public RawImage ink_img;
    
    //itemtime = 3��
    private float itemTime = 3f;

    private void Awake()
    {
        //�ʱ�ȭ
        renderer = GetComponentInChildren <Renderer>();
        isGoast = false;
        isInk = false;
        
    }

   

    //�����۰� �����Ͽ��� ��
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
         * 1.��ũ���� �Թ�ȿ���� ���İ� �������� �ε巴�� �����ְ�
         * 2.2�� ���� �� ���۰� ���� �ε巴�� ����
         */
        ink_img.gameObject.SetActive(true);
    }
    public void Clear()
    {
        isInk = false;
        ink_img.gameObject.SetActive(false);
    }

    //������ ����
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
