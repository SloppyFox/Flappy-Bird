using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class UIRootView : MonoBehaviour
	{
		[SerializeField] private GameObject _disclaimer;
		[SerializeField] private GameObject _loadingScreen;

		public void ShowLoadingScreen() => _loadingScreen.SetActive(true);

		public void HideLoadingScreen() => _loadingScreen.SetActive(false);

		public void ShowDisclaimer() => _disclaimer.SetActive(true);

		public void HideDisclaimer() => _disclaimer.SetActive(false);
	}
}