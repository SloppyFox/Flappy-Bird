using System;
using UnityEngine;

namespace SloppyFox.FlappyBird
{
	[RequireComponent(typeof(UIAudio))]
	public class UIController : MonoBehaviour
	{
		[SerializeField] private GameManager _gameManager;
		[SerializeField] private GameObject _playButton;

		public event Action OnPlayButtonClickedEvent;

		#region -Monobehavior callbacks-
		private void OnEnable()
		{
			_gameManager.OnGameOverEvent += GameOver;
		}

		private void OnDisable()
		{
			_gameManager.OnGameOverEvent -= GameOver;
		}
		#endregion -Monobehavior callbacks-

		private void GameOver()
		{
			_playButton.SetActive(true);
		}

		public void OnClickPlayButton()
		{
			_playButton.SetActive(false);
			OnPlayButtonClickedEvent?.Invoke();
		}
	}
}
