using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdMovement : MonoBehaviour
{
    private CharacterController Controller;
    private Vector3 Velocity;
    private bool Cooldown;

    private GameObject LookAt;
    public GameObject Cube1;
    public GameObject Cube2;
    private int Speed;

    public Animator BirdAnimator;

    public TextMeshProUGUI ScoreText;
    private int Score;

    private void OnTriggerEnter(Collider other)
    {
        //튜브에 지정한 큐브에 닿을때마다 점수증가 (튜브에닿지않고 넘어가면)
        if(other.tag == "Score")
        {
            Score++;
        }
        //튜브에 닿으면 처음씬으로 넘어감(사망)
        if(other.tag == "Obstacle")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void Start()
    {
        Controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        ScoreText.text = Score.ToString();

        Velocity.y += -15 * Time.deltaTime;

        //스페이스바 입력 = 점프
        if (Input.GetKey("space") && Cooldown == false)
        {
            //점프 쿨타임
            Cooldown = true;
            Velocity.y = 0;
            Velocity.y = Mathf.Sqrt(60);
            BirdAnimator.SetBool("Fly", true);
            StartCoroutine(CooldownRefresh());
        }

        if(Velocity.y > 0)
        {
            LookAt = Cube1;
            Speed = 5;
        }
        else
        {
            LookAt = Cube2;
            Speed = 10;
        }

        Quaternion lookOnLook =
        Quaternion.LookRotation(-LookAt.transform.position - transform.position);

        transform.rotation =
        Quaternion.Slerp(transform.rotation, lookOnLook, Speed * Time.deltaTime);

        Controller.Move(Velocity * Time.deltaTime);
    }

    private IEnumerator CooldownRefresh()
    {
        //점프 쿨다운 0.3초
        yield return new WaitForSeconds(0.3f);
        Cooldown = false;
        BirdAnimator.SetBool("Fly", false);
    }
}
