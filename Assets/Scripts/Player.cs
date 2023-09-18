using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10.0f;
    private float maxLeftPos = -7.5f;
    private float maxRightPos = 7.5f;
    private float maxTopPos = 20.0f;
    private float maxDownPos = -4.0f;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > maxLeftPos)
                transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < maxRightPos)
                transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y < maxTopPos)
                transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > maxDownPos)
                transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Item1")
        {
            GameManager.instance.Item1();
        }

        if (other.gameObject.tag == "Item2")
        {
            GameManager.instance.Item2();
        }

        if (other.gameObject.tag == "Item3")
        {
            GameManager.instance.Item3();
        }
    }
}