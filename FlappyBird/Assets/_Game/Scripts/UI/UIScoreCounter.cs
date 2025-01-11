using TMPro;
using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class UIScoreCounter : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _uiScoreCounterText;
		[SerializeField] private ScoreCounter _scoreCounter;

		private void OnEnable()
		{
			_scoreCounter.ScoreAmountValueChangedEvent += ScoreAmountValueChanged;
		}

		private void OnDisable()
		{
			_scoreCounter.ScoreAmountValueChangedEvent -= ScoreAmountValueChanged;
		}

		private void ScoreAmountValueChanged(int scoreValue)
		{
			_uiScoreCounterText.text = scoreValue.ToString();
		}
	}
}
