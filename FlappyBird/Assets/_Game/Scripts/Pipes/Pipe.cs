using UnityEngine;

namespace SloppyFox.FlappyBird
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class Pipe : MonoBehaviour
	{
		[SerializeField] private Transform _pipeBody;
		[SerializeField] private SpriteRenderer _pipeBodySpriterenderer;

		private BoxCollider2D _collider;

		private void Awake()
		{
			_collider = GetComponent<BoxCollider2D>();
		}

		#region -Internal methods-
		public void Init(bool isBottom, float localYPos)
		{
			SetPosition(localYPos);
			SetRotation(isBottom);
			SetPipeBodyHeight(isBottom);
			InitCollider();
		}

		private void SetPosition(float localYPos)
		{
			transform.localPosition = new Vector2(0f, localYPos);
		}

		private void SetRotation(bool isBottom)
		{
			if (isBottom == false)
				transform.localEulerAngles = new Vector3(0f, 0f, 180f);
		}

		private void SetPipeBodyHeight(bool isBottom)
		{
			float yPos = _pipeBody.position.y;

			if (isBottom)
			{
				if (yPos < 0)
					yPos = Mathf.Abs(yPos);
				else
					yPos = -yPos;
			}

			float pipeBodyHeight = GameConfig.MAIN_CAMERA_ORTOGRAPHIC_SIZE - yPos;

			_pipeBodySpriterenderer.size = new Vector2(_pipeBodySpriterenderer.size.x, pipeBodyHeight);
		}

		private void InitCollider()
		{
			float colliderSizeY = _pipeBodySpriterenderer.size.y + Mathf.Abs(_pipeBody.localPosition.y);

			_collider.size = new Vector2(_collider.size.x, colliderSizeY);

			_collider.offset = new Vector2(_collider.offset.x, -_collider.size.y / 2);
		}
		#endregion -Internal methods-
	}
}
