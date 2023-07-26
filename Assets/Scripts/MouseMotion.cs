using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMotion : MonoBehaviour
{
    Vector3 _mousePos;
    float _offset;
    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mousePos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);
                _offset = transform.position.x - _mousePos.x;
            }

            if (Input.GetMouseButton(0))
            {
                _mousePos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(_mousePos.x + _offset, transform.position.y, 0);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -GameManager.Single.RightUpperCorner.x, GameManager.Single.RightUpperCorner.x), transform.position.y, transform.position.z);
        }
    }
}
