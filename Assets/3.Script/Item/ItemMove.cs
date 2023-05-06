using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 180f;
    private Rigidbody Item_r;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out Item_r);
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
        Rotate();
    }
    public void Move()
    {
        Vector3 moveDirection = transform.up * moveSpeed * Time.deltaTime;
        Item_r.MovePosition(Item_r.position + moveDirection);
    }
    public void Rotate()
    {
        float turn = rotateSpeed * Time.deltaTime;
        Item_r.rotation = Item_r.rotation * Quaternion.Euler(0, turn, 0);
    }
}
