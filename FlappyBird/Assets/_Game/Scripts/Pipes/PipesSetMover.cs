using System.Collections;
using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class PipesSetMover : MonoBehaviour
	{
		[SerializeField] private GameManager _gameManager;

		private bool _isPlaying = false;
		private CouplePipes[] _couplePipes;

		#region -Monobehavior callbacks-
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
		#endregion -Monobehavior callbacks-

		#region -Internal methods-
		private void GameplayRestarted()
		{
			for (int i = 0; i < _couplePipes.Length; i++)
			{
				_couplePipes[i].gameObject.SetActive(true);
				_couplePipes[i].TeleportPipesToStartPosition(PipesConfig.START_PIPES_X_POS + i * PipesConfig.DISTANCE_BETWEEN_COUPLE_PIPES_ALONG_THE_X_AXIS);
			}

			_isPlaying = true;

			StartCoroutine(MovePipes());
		}

		private void GameOver()
		{
			_isPlaying = false;
		}

		public void Init(CouplePipes[] couplePipes)
		{
			_couplePipes = new CouplePipes[couplePipes.Length];
			_couplePipes = couplePipes;
		}

		private IEnumerator MovePipes()
		{
			while (_isPlaying)
			{
				for (int i = 0; i < _couplePipes.Length; i++)
				{
					_couplePipes[i].transform.position += Vector3.left * PipesConfig.PIPES_SPEED * Time.deltaTime;

					if (_couplePipes[i].transform.position.x < PipesConfig.END_PIPES_X_POS)
					{
						int rightPipesIndex = i > 0 ? i - 1 : _couplePipes.Length - 1;

						_couplePipes[i].TeleportPipesToStartPosition(_couplePipes[rightPipesIndex].transform.position.x + PipesConfig.DISTANCE_BETWEEN_COUPLE_PIPES_ALONG_THE_X_AXIS);
					}
				}

				yield return null;
			}

		}
		#endregion -Internal methods-
	}
}
