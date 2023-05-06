using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //������ ȿ���������� ���� bool����
    private bool isGoast = false;
    private bool isInk = false;

    //�����ۿ� ���� ȿ���� ���� SpriteRenderer 
    private Renderer renderer;
    [SerializeField] GameObject player;
    private void Awake()
    {
        //�ʱ�ȭ
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

    //�����۰� �����Ͽ��� ��
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
         * 1. �÷��̾� ���İ� ����
         * 2. isGoasted��� �浹X
         * 3. itemTime = 3�ʷ� �Ѵ�.
         */

        int i = 40;
        Color alpha = renderer.material.color;
        alpha.a = i;
        renderer.material.color = alpha;

    }
    public void Inked()
    {
        /*
         * 1.��ũ���� �Թ�ȿ���� ���İ� �������� �ε巴�� �����ְ�
         * 2.2�� ���� �� ���۰� ���� �ε巴�� ����
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
