using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _dumping = 1.5f;
    [SerializeField] Vector2 _offset = new(2, 1);

    Transform _playerTr;

    private void Start()
    {
        _offset = new Vector2(Mathf.Abs(_offset.x), _offset.y);
        _playerTr =FindObjectOfType<Player>().transform;
    }

    private void FixedUpdate()
    {
        if (_playerTr != null)
        {
            Vector3 target = new(_playerTr.position.x + _offset.x, Mathf.Abs(_playerTr.position.y + _offset.y), transform.position.z);

            transform.position = Vector3.Lerp(transform.position, target, _dumping * Time.deltaTime);
        }
    }
}
