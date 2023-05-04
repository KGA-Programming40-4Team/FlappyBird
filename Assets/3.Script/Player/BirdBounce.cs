using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBounce : MonoBehaviour
{
    private CharacterController controller; //plalyer
    private Vector3 Velocity;
    private bool Cooldown; //������ ��Ÿ��

    private GameObject LookAt; //������ ������ �÷��̾ lookat ����
    private int Speed;
    public GameObject Cube1; //������ lookat�� ���
    public GameObject Cube2; //�������� ''

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        #region Movement
        Velocity.y += -15 * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && Cooldown == false) //�����̽��� �Է¹����� �����ϰ� ��ٿ��� ������
        {
 
            Cooldown = true;
            Velocity.y = Mathf.Sqrt(60);
            StartCoroutine(CooldownRefresh());
        }

        if (Input.GetMouseButtonDown(0)) //����Ʈ�� ��ġ�� ���� GetMouseButtonDown
        {
            Cooldown = true;
            Velocity.y = Mathf.Sqrt(60);
            StartCoroutine(CooldownRefresh());
        }

        controller.Move(Velocity * Time.deltaTime);
        #endregion
        if(Velocity.y >0) //�Է��� �ٶ� ��ü,�ӵ�
        {
            LookAt = Cube1;
            Speed = 5;

        }
        else //�Է��� �������� �ٶ� ��ü,�ӵ� 
        {
            LookAt = Cube2;
            Speed = 20;
        }
        Quaternion LookOnLook = Quaternion.LookRotation(-LookAt.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookOnLook, Speed * Time.deltaTime);
    }


    private IEnumerator CooldownRefresh() //������ 0.3��ŭ��  ��Ÿ���� ���´�
    {  
        yield return new WaitForSeconds(0.3f);
        Cooldown = false;
    }
}
