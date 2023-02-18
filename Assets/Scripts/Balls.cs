using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    Rigidbody _rigidbody;
    Transform _transform;
    Renderer _renderer;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        _rigidbody.velocity = new Vector3(10f, 10f, 0f); //ボールの速さ
        _transform = transform;
    }

    void Update()
    {
        Vector3 velocity = _rigidbody.velocity;
        float clampedspeed = Mathf.Clamp(velocity.magnitude,5f, 10f); //最低速,最高速
        _rigidbody.velocity = velocity.normalized * clampedspeed;
        if (!_renderer.isVisible)
        {
            GameManager.instance.Balls--;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // プレイヤーに当たったときに、跳ね返る方向を変える
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 playerPos = collision.transform.position;
            Vector3 ballPos = _transform.position;
            Vector3 direction = (ballPos - playerPos).normalized;
            float speed = _rigidbody.velocity.magnitude;

            _rigidbody.velocity = direction * speed;
        }
    }
}