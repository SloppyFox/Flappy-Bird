using System;
using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class ScoreCounter : MonoBehaviour
	{
		[SerializeField] private Bird _bird;
		[SerializeField] private GameManager _gameManager;

		public event Action<float> ScoreAmountValueChangedEvent;

		private int _scoreAmont;

		#region -Monobehavior callbacks-
		private void OnEnable()
		{
			_gameManager.OnGameplayRestartedEvent += GameplayRestarted;
			_bird.OnBirdClaimedScoreEvent += BirdCollidedWithScoreGeometry;
		}

		private void OnDisable()
		{
			_gameManager.OnGameplayRestartedEvent -= GameplayRestarted;
			_bird.OnBirdClaimedScoreEvent -= BirdCollidedWithScoreGeometry;
		}
		#endregion -Monobehavior callbacks-

		#region -Internal methods-
		private void GameplayRestarted()
		{
			_scoreAmont = 0;

			ScoreAmountValueChangedEvent?.Invoke(_scoreAmont);
		}

		private void BirdCollidedWithScoreGeometry()
		{
			++_scoreAmont;

			ScoreAmountValueChangedEvent?.Invoke(_scoreAmont);
		}
		#endregion -Internal methods-
	}
}
