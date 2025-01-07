using UnityEngine;

namespace SloppyFox.FlappyBird
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class BirdMover : MonoBehaviour, IControllableBird
	{
		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		public void Flap()
		{
			_rigidbody.linearVelocityY = BirdConfig.FLAP_HEIGHT;
		}
	}
}
