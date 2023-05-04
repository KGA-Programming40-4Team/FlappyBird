using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBounce : MonoBehaviour
{
    private CharacterController controller; //plalyer
    private Vector3 Velocity;
    private bool Cooldown; //점프후 쿨타임

    private GameObject LookAt; //점프를 누른후 플레이어가 lookat 선언
    private int Speed;
    public GameObject Cube1; //점프후 lookat할 장소
    public GameObject Cube2; //떨어질때 ''

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        #region Movement
        Velocity.y += -15 * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && Cooldown == false) //스페이스바 입력받으면 점프하고 쿨다운이 켜진다
        {
 
            Cooldown = true;
            Velocity.y = Mathf.Sqrt(60);
            StartCoroutine(CooldownRefresh());
        }

        if (Input.GetMouseButtonDown(0)) //스마트폰 터치를 위한 GetMouseButtonDown
        {
            Cooldown = true;
            Velocity.y = Mathf.Sqrt(60);
            StartCoroutine(CooldownRefresh());
        }

        controller.Move(Velocity * Time.deltaTime);
        #endregion
        if(Velocity.y >0) //입력후 바라볼 물체,속도
        {
            LookAt = Cube1;
            Speed = 5;

        }
        else //입력후 떨어질떄 바라볼 물체,속도 
        {
            LookAt = Cube2;
            Speed = 20;
        }
        Quaternion LookOnLook = Quaternion.LookRotation(-LookAt.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, LookOnLook, Speed * Time.deltaTime);
    }


    private IEnumerator CooldownRefresh() //점프후 0.3만큼의  쿨타임을 갔는다
    {  
        yield return new WaitForSeconds(0.3f);
        Cooldown = false;
    }
}
