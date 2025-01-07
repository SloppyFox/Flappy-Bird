using UnityEngine;

namespace SloppyFox.FlappyBird
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class ScoreGeometry : MonoBehaviour
	{
		private BoxCollider2D _collider;

		private void Awake()
		{
			_collider = GetComponent<BoxCollider2D>();
		}

		public void Init(float height)
		{
			_collider.size = new Vector2(_collider.size.x, height);
		}
	}
}
