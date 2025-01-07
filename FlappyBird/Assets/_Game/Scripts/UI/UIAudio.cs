using UnityEngine;

namespace SloppyFox.FlappyBird
{
	[RequireComponent(typeof(AudioSource))]
	public class UIAudio : MonoBehaviour
	{
		[SerializeField] private AudioClip _buttonClickClip;

		private UIController _uiController;
		private AudioSource _audioSource;

		private void Awake()
		{
			_uiController = GetComponent<UIController>();
			_audioSource = GetComponent<AudioSource>();
		}

		private void OnEnable()
		{
			_uiController.OnPlayButtonClickedEvent += PlayButtonClicked;
		}

		private void OnDisable()
		{
			_uiController.OnPlayButtonClickedEvent -= PlayButtonClicked;
		}

		private void PlayButtonClicked()
		{
			_audioSource.PlayOneShot(_buttonClickClip);
		}
	}
}
