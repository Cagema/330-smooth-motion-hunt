using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    Transform _playerTr;
    private void Start()
    {
        _playerTr = FindObjectOfType<Player>().transform;
    }
    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, _playerTr.position, Time.deltaTime * GameManager.Single.Speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameManager.Single.Score++;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
