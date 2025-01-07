using UnityEngine;

namespace SloppyFox.FlappyBird
{
	[RequireComponent(typeof(AudioSource))]
	public class BirdAudio : MonoBehaviour
	{
		[SerializeField] private AudioClip _scoreClaimedClip;
		[SerializeField] private AudioClip _deadClip;

		private AudioSource _audioSource;
		private Bird _bird;

		#region -Monobehavior callbacks-
		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
			_bird = GetComponent<Bird>();
		}

		private void OnEnable()
		{
			_bird.OnBirdClaimedScoreEvent += BirdClaimedScore;
			_bird.BirdDeadEvent += BirdDead;
		}

		private void OnDisable()
		{
			_bird.OnBirdClaimedScoreEvent -= BirdClaimedScore;
			_bird.BirdDeadEvent -= BirdDead;
		}
		#endregion -Monobehavior callbacks-

		#region -Internal methods-
		private void BirdClaimedScore()
		{
			_audioSource.PlayOneShot(_scoreClaimedClip);
		}

		private void BirdDead()
		{
			_audioSource.PlayOneShot(_deadClip);
		}
		#endregion -Internal methods-
	}
}
