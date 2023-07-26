using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;

    Vector3 _finalPoint;
    void Start()
    {
        _finalPoint = (transform.position - FindObjectOfType<Player>().transform.position).normalized * 20;

        Invoke(nameof(Death), 2f);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _finalPoint,_bulletSpeed * Time.deltaTime);
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
