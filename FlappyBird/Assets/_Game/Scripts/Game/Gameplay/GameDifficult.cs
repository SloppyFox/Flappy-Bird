using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class GameDifficult : MonoBehaviour
	{
		[SerializeField] private GameManager _gameManager;
		[SerializeField] private ScoreCounter _scoreCounter;

		public float CurrentGameDifficultRatio
		{
			get => _currentGameDifficultRatio;
			private set
			{
				if (value > 1f)
					value = 1f;
				else if (value < 0f)
					value = 0f;

				_currentGameDifficultRatio = value;
			}
		}

		public static GameDifficult Instance { get; private set; }

		private float _currentGameDifficultRatio;

		#region -Monobehavior callbacks-
		private void Awake()
		{
			if (Instance != null)
				Debug.LogError($"It is not possible to create more than 1 instance of this class: {gameObject.name}");

			Instance = this;

			CurrentGameDifficultRatio = 0f;
		}

		private void OnEnable()
		{
			_gameManager.OnGameplayRestartedEvent += GameplayRestarted;
			_scoreCounter.ScoreAmountValueChangedEvent += ScoreAmountValueChanged;
		}

		private void OnDisable()
		{
			_gameManager.OnGameplayRestartedEvent -= GameplayRestarted;
			_scoreCounter.ScoreAmountValueChangedEvent -= ScoreAmountValueChanged;
		}
		#endregion -Monobehavior callbacks-

		#region -Internal methods-
		private void GameplayRestarted()
		{
			CurrentGameDifficultRatio = 0f;
		}

		private void ScoreAmountValueChanged(int obj)
		{
			CurrentGameDifficultRatio += GameConfig.GAME_DIFFICULT_INCREASE_STEP;
		}
		#endregion -Internal methods-
	}
}
