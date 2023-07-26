using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _helpText;
	[SerializeField] TextMeshProUGUI _scoreText;
	[SerializeField] TextMeshProUGUI _currentScoreEndgameText;
    [SerializeField] TextMeshProUGUI _bestScoreText;

    [SerializeField] Slider _timeSlider;

    [SerializeField] GameObject _menuCanvas;

    [SerializeField] Image[] _liveImages;
    [SerializeField] Sprite _fillLive;
	[SerializeField] Sprite _emptyLive;
    private void Start()
    {
        UpdateTexts();

        _timeSlider.maxValue = GameManager.Single.TimeLeft;
    }

    private void Update()
    {
        _timeSlider.value = GameManager.Single.TimeLeft;
    }

    public void UpdateTexts()
    {
        _scoreText.text = GameManager.Single.Score.ToString();
        _currentScoreEndgameText.text = _scoreText.text;
        _bestScoreText.text = GameManager.Single.BestScore.ToString();
    }

    public void UpdateLives()
    {
        for (int i = 0; i < _liveImages.Length; i++)
        {
            if (i >= GameManager.Single.Lives)
            {
                _liveImages[i].sprite = _emptyLive;
            }
            else
            {
                _liveImages[i].sprite = _fillLive;
            }
        }
    }

    public void HideHelpText()
    {
        _helpText.enabled = false;
    }

    public void ShowEndgameMenu()
    {
        GameManager.Single.GameActive = false;
		_menuCanvas.SetActive(true);
    }
}
