using TMPro;
using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class UIHighScore : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _uiHighScoreText;
		[SerializeField] private ScoreCounter _scoreCounter;

		private void Start()
		{
			_scoreCounter.HighScoreValueChangedEvent += ScoreAmountValueChanged;
		}
		 
		private void OnDestroy()
		{
			_scoreCounter.HighScoreValueChangedEvent -= ScoreAmountValueChanged;
		}

		public void Init(int savedHighScore)
		{
			ScoreAmountValueChanged(savedHighScore);
		}

		private void ScoreAmountValueChanged(int highScore)
		{
			_uiHighScoreText.text = $"Highscore = {highScore}";
		}
	}
}
