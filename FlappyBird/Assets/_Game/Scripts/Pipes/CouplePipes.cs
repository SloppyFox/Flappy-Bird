using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class CouplePipes : MonoBehaviour
	{
		[SerializeField] private GameObject _pipePrefab;
		[SerializeField] private GameObject _scoreGeometryPrefab;

		private Pipe _bottomPipe;
		private Pipe _upperPipe;
		private ScoreGeometry _scoreGeometry;

		private void Awake()
		{
			_bottomPipe = Instantiate(_pipePrefab, gameObject.transform).GetComponent<Pipe>();
			_upperPipe = Instantiate(_pipePrefab, gameObject.transform).GetComponent<Pipe>();
			_scoreGeometry = Instantiate(_scoreGeometryPrefab, gameObject.transform).GetComponent<ScoreGeometry>();
		}

		public void TeleportPipesToStartPosition(float xPos)
		{
			float gapSize = Mathf.Lerp(PipesConfig.MAX_GAP_SIZE, PipesConfig.MIN_GAP_SIZE, GameDifficult.Instance.CurrentGameDifficultRatio);

			float maxYOffset = GameConfig.MAIN_CAMERA_ORTOGRAPHIC_SIZE - gapSize / 2f - PipesConfig.MAX_COUPLE_PIPES_Y_OFFSET;

			float yPos = Random.Range(-maxYOffset, maxYOffset);

			transform.localPosition = new Vector2(xPos, yPos);

			_bottomPipe.Init(true, -gapSize / 2);
			_upperPipe.Init(false, gapSize / 2);

			_scoreGeometry.Init(gapSize);
		}
	}
}
