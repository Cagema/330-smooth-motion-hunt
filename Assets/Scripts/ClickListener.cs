using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
	private void Update()
	{
		if (GameManager.Single.GameActive)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Vector2 mousePos = GameManager.Single.MainCamera.ScreenToWorldPoint(Input.mousePosition);

				Collider2D col = Physics2D.OverlapCircle(mousePos, 0.2f);
				if (col)
				{

				}
			}
		}
	}
}
