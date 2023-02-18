using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 mousePos;
    private float maxLeftPos = 60f; //30f
    private float maxRightPos =2000f; //435f
    private float maxTopPos = 1000f; //250f
    private float maxDownPos = 0f; //0f

    void Update()
    {
        mousePos = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Mathf.Clamp(mousePos.x,maxLeftPos,maxRightPos), Mathf.Clamp(mousePos.y, maxDownPos, maxTopPos), 10f));
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