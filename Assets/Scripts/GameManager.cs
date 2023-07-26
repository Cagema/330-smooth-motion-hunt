using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Single;

	[HideInInspector] public Camera MainCamera;
	GameUI _gameUI;

	int _score;
	int _bestScore;

	

	public bool GameActive;
	public Vector2 RightUpperCorner;

	[Header("Game parameters")]
	[SerializeField] int _lives;
	[SerializeField] float _speed;
	[SerializeField] float _interval;
	[SerializeField] bool _timer;
	[SerializeField] float _timeLeft;

	float _maxTime;

	[Header("Sounds")]
	[SerializeField] AudioSource _music;

	public string PolicyLink;

	public float TimeLeft
	{
		get { return _timeLeft; }
	}
	public int BestScore
	{
		get { return _bestScore; }
	}
	public int Lives
	{
		get { return _lives; }
	}
	public float Interval
	{
		get { return _interval; }
	}
	public float Speed
	{
		get { return _speed; }
	}
	public int Score
	{
		get { return _score; }
		set
		{
			_score = value;

			if (_score > _bestScore)
			{
				_bestScore = _score;
				PlayerPrefs.SetInt("BestScore", _bestScore);
			}

			_speed += 0.02f;
			if (_interval > 0.7f) _interval -= 0.01f;

			_timeLeft = _maxTime;
			_gameUI.UpdateTexts();
		}
	}

	private void Awake()
	{
		if (Single != null)
		{
			Debug.Log("Error! - single already exist");
			Single = this;
		}
		else
		{
			Single = this;
		}

		_gameUI = FindObjectOfType<GameUI>();
		MainCamera = Camera.main;
		RightUpperCorner = MainCamera.ViewportToWorldPoint(new Vector2(1, 1));
	}

	private void Start()
	{
		_bestScore = PlayerPrefs.GetInt("BestScore", 0);
		_maxTime = _timeLeft;
	}

	private void FixedUpdate()
	{
		if (GameActive)
		{
			if (_timer)
			{
				_timeLeft -= Time.deltaTime;
				if (_timeLeft <= 0)
				{
					LostLive();
				}
			}
		}
	}

	public void LostLive()
	{
		_lives--;

		_gameUI.UpdateLives();

		if (_lives <= 0)
		{
			EndGame();
		}
	}

	private void EndGame()
	{
		_gameUI.ShowEndgameMenu();
		_music.Stop();
	}

	public void StartGame()
	{
		Invoke(nameof(ActivateGame), 0.1f);
		_gameUI.HideHelpText();
	}
	private void ActivateGame()
	{
		GameActive = true;
	}

}
