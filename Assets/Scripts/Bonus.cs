using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private void Start()
    {
        SetNewPos();
    }
    public void SetNewPos()
    {
        transform.position = new Vector3(Random.Range(-GameManager.Single.RightUpperCorner.x, GameManager.Single.RightUpperCorner.x), 
            Random.Range(-GameManager.Single.RightUpperCorner.y, GameManager.Single.RightUpperCorner.y), 0);
    }
}
