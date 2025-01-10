using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SloppyFox.FlappyBird
{
	public class GameEntryPoint
	{
		private static GameEntryPoint _instance;
		private Corutines _corutines;
		private UIRootView _uiRootView;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void LoadAndStartGame()
		{
			_instance = new GameEntryPoint();
			_instance.RunGame();
		}

		private GameEntryPoint()
		{
			CreateUtils();
			CreateUIRoot();
		}

		private void CreateUtils()
		{
			_corutines = new GameObject("[CORUTINES]").AddComponent<Corutines>();

			Object.DontDestroyOnLoad(_corutines.gameObject);
		}

		private void CreateUIRoot()
		{
			var uiRootPrefab = Resources.Load<UIRootView>("UIRoot");

			_uiRootView = Object.Instantiate(uiRootPrefab);

			Object.DontDestroyOnLoad(_uiRootView.gameObject);
		}

		private void RunGame()
		{
#if UNITY_EDITOR
			string activeSceneName = SceneManager.GetActiveScene().name;

			if (activeSceneName == Scenes.GAMEPLAY || activeSceneName == Scenes.DISCLAIMER)
			{
				_corutines.StartCoroutine(LoadAndStartGameplayScene());
				return;
			}

			if (activeSceneName != Scenes.BOOT)
				return;
#endif
			_corutines.StartCoroutine(LoadAndStartGameplayScene());
		}

		private IEnumerator LoadAndStartGameplayScene()
		{
			yield return LoadScene(Scenes.BOOT);
			yield return LoadScene(Scenes.DISCLAIMER);

			_uiRootView.ShowLoadingScreen();
			_uiRootView.ShowDisclaimer();
			yield return new WaitForSecondsRealtime(5);
			_uiRootView.HideDisclaimer();

			yield return LoadScene(Scenes.GAMEPLAY);

			_uiRootView.HideLoadingScreen();
		}
		
		private IEnumerator LoadScene(string sceneName)
		{
			yield return SceneManager.LoadSceneAsync(sceneName);
			yield return null;
		}
	}
}
