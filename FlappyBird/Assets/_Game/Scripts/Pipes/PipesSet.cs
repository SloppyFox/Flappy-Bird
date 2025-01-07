using UnityEngine;

namespace SloppyFox.FlappyBird
{
	[RequireComponent(typeof(PipesSetMover))]
	public class PipesSet : MonoBehaviour
	{
		[SerializeField] private CouplePipes _couplePipesPrefab;

		private static PipesSet _instance;

		private PipesSetMover _pipesSetMover;
		private CouplePipes[] _couplePipes = new CouplePipes[PipesConfig.MAX_COUPLE_PIPES_AMOUNT_IN_SCENE];

		private void Awake()
		{
			if (_instance != null)
				Debug.LogError($"It is not possible to create more than 1 instance of this class: {gameObject.name}");

			_instance = this;

			for (int i = 0; i < _couplePipes.Length; i++)
			{
				_couplePipes[i] = Instantiate(_couplePipesPrefab, gameObject.transform).GetComponent<CouplePipes>();

				_couplePipes[i].gameObject.SetActive(false);
			}

			_pipesSetMover = GetComponent<PipesSetMover>();
			_pipesSetMover.Init(_couplePipes);
		}
	}
}
