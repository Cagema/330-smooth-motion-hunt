using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    [SerializeField] float _rotSpeed;
    [SerializeField] float _speed;

    float rotateZ;
    Vector3 _mousePos;
    bool _move;

    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                _move = true;
                _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _mousePos = new Vector3(_mousePos.x, _mousePos.y, 0);
            }

            if (_move)
            {
                Vector3 diference = _mousePos - transform.position;
                rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg - 90f;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, rotateZ), Time.deltaTime * _rotSpeed);
                transform.Translate(_speed * Time.deltaTime * Vector2.up);
                if (Vector2.Distance(transform.position, _mousePos) < 0.05f)
                {
                    _move = false;
                    transform.position = _mousePos;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bonus"))
        {
            GameManager.Single.Score++;

            collision.GetComponent<Bonus>().SetNewPos();
        }
    }
}
