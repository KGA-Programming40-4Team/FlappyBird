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
        //Ʃ�꿡 ������ ť�꿡 ���������� �������� (Ʃ�꿡�����ʰ� �Ѿ��)
        if(other.tag == "Score")
        {
            Score++;
        }
        //Ʃ�꿡 ������ ó�������� �Ѿ(���)
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

        //�����̽��� �Է� = ����
        if (Input.GetKey("space") && Cooldown == false)
        {
            //���� ��Ÿ��
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
        //���� ��ٿ� 0.3��
        yield return new WaitForSeconds(0.3f);
        Cooldown = false;
        BirdAnimator.SetBool("Fly", false);
    }
}
