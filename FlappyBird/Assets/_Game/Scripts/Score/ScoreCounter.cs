using System;
using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class ScoreCounter : MonoBehaviour
	{
		[SerializeField] private Bird _bird;
		[SerializeField] private GameManager _gameManager;
		[SerializeField] private UIHighScore _uiHighScore;

		public event Action<int> ScoreAmountValueChangedEvent;
		public event Action<int> HighScoreValueChangedEvent;

		private int _score;
		private int _highScore;

		#region -Monobehavior callbacks-
		private void OnEnable()
		{
			_gameManager.OnGameplayRestartedEvent += GameplayRestarted;
			_bird.OnBirdClaimedScoreEvent += BirdCollidedWithScoreGeometry;
			_bird.BirdDeadEvent += BirdDead;
		}

		private void OnDisable()
		{
			_gameManager.OnGameplayRestartedEvent -= GameplayRestarted;
			_bird.OnBirdClaimedScoreEvent -= BirdCollidedWithScoreGeometry;
			_bird.BirdDeadEvent -= BirdDead;
		}
		#endregion -Monobehavior callbacks-

		#region -Internal methods-
		public void Init(int savedHighScore)
		{
			_highScore = savedHighScore;
			HighScoreValueChangedEvent?.Invoke(_highScore);
			_uiHighScore.Init(_highScore);
		}

		private void GameplayRestarted()
		{
			ScoreAmountValueChangedEvent?.Invoke(_score);
		}

		private void BirdCollidedWithScoreGeometry()
		{
			++_score;

			ScoreAmountValueChangedEvent?.Invoke(_score);
		}

		private void BirdDead()
		{
			if (_score > _highScore)
			{
				_highScore = _score;
				HighScoreValueChangedEvent?.Invoke(_highScore);
			}

			_score = 0;
		}
		#endregion -Internal methods-
	}
}
