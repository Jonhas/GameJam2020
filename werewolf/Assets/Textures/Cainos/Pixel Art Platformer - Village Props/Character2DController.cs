using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character2DController : MonoBehaviour
{
    private Character2DController playerBase;
    public float movementSpeed = 2;
    public float jumpForce = 3;

    [SerializeField]
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    private void Start()
    {
        playerBase = gameObject.GetComponent<Character2DController>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        var horizontalAxis = new Vector3(movement, 0, 0);
        transform.position += horizontalAxis * Time.deltaTime * movementSpeed;
        if (Input.GetKeyDown(KeyCode.Space))//&& Math.Abs(rigid.velocity.y) < 0.00)
        {
            //rigid.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            rigid.velocity = Vector2.up * jumpForce;
        }
    }
}