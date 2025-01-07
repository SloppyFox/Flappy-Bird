using System;
using UnityEngine;

namespace SloppyFox.FlappyBird
{
	[RequireComponent(typeof(BirdMover))]
	[RequireComponent(typeof(BirdAudio))]
	public class Bird : MonoBehaviour
	{
		[SerializeField] private GameManager _gameManager;

		public event Action BirdDeadEvent;
		public event Action OnBirdClaimedScoreEvent;

		private static Bird _instance;

		private Rigidbody2D _rigidbody;

		#region -Monobehavior callbacks-
		private void Awake()
		{
			if (_instance != null)
				Debug.LogError($"It is not possible to create more than 1 instance of this class: {gameObject.name}");

			_instance = this;

			_rigidbody = GetComponent<Rigidbody2D>();
			_rigidbody.bodyType = RigidbodyType2D.Static;
		}

		private void OnEnable()
		{
			_gameManager.OnGameplayRestartedEvent += GameplayRestarted;
			_gameManager.OnGameOverEvent += GameOver;
		}

		private void OnDisable()
		{
			_gameManager.OnGameplayRestartedEvent -= GameplayRestarted;
			_gameManager.OnGameOverEvent -= GameOver;
		}

		private void OnTriggerEnter2D(Collider2D collider)
		{
			string colliderLayerName = LayerMask.LayerToName(collider.gameObject.layer);

			if (colliderLayerName == GameConfig.OBSTACLE_LAYER_NAME)
			{
				BirdDeadEvent?.Invoke();
			}
			else if (colliderLayerName == GameConfig.SCORE_LAYER_NAME)
			{
				OnBirdClaimedScoreEvent?.Invoke();
			}
		}
		#endregion -Monobehavior callbacks-

		#region -Internal methods-
		private void GameOver()
		{
			_rigidbody.bodyType = RigidbodyType2D.Static;
		}

		private void GameplayRestarted()
		{
			transform.position = new Vector2(BirdConfig.BIRD_X_POS, 0f);
			_rigidbody.bodyType = RigidbodyType2D.Dynamic;
		}
		#endregion -Internal methods-
	}
}
