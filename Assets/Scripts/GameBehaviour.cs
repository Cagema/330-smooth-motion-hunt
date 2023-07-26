using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		if (Input.GetKeyDown(KeyCode.F2))
		{
			ScreenCapture.CaptureScreenshot("1.png", 1);
		}

		if (Input.GetKeyDown(KeyCode.F3))
		{
			ScreenCapture.CaptureScreenshot("2.png", 1);
		}

		if (Input.GetKeyDown(KeyCode.F4))
		{
			ScreenCapture.CaptureScreenshot("3.png", 1);
		}
	}

	public void ShowPrivacy()
	{
		Application.OpenURL(GameManager.Single.PolicyLink);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
	}
}
