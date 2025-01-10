using System;
using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class GameManager : MonoBehaviour
	{
		[SerializeField] private Bird _bird;
		[SerializeField] private UIController _uiController;

		private static GameManager _instance;

		public event Action OnGameplayRestartedEvent;
		public event Action OnGameOverEvent;

		#region -Monobehavior callbacks-
		private void Awake()
		{
			if (_instance != null)
				Debug.LogError($"It is not possible to create more than 1 instance of this class: {gameObject.name}");

			_instance = this;
		}

		private void OnEnable()
		{
			_bird.BirdDeadEvent += GameOver;
			_uiController.OnPlayButtonClickedEvent += RestartGameplay;
		}

		private void OnDisable()
		{
			_bird.BirdDeadEvent -= GameOver;
			_uiController.OnPlayButtonClickedEvent -= RestartGameplay;
		}
		#endregion -Monobehavior callbacks-

		#region -Internal methods-
		public void RestartGameplay()
		{
			OnGameplayRestartedEvent?.Invoke();
		}

		private void GameOver()
		{
			OnGameOverEvent?.Invoke();
		}
		#endregion -Internal methods-
	}
}
