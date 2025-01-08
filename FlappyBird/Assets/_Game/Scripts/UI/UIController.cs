using System;
using UnityEngine;

namespace SloppyFox.FlappyBird
{
	[RequireComponent(typeof(UIAudio))]
	public class UIController : MonoBehaviour
	{
		[SerializeField] private GameManager _gameManager;
		[SerializeField] private GameObject _uiGameMenuButton;

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
			_uiGameMenuButton.SetActive(true);
		}

		public void OnClickPlayButton()
		{
			_uiGameMenuButton.SetActive(false);
			OnPlayButtonClickedEvent?.Invoke();
		}
		
		public void OnClickQuitApplicationButton()
		{
			Application.Quit();
		}
	}
}
