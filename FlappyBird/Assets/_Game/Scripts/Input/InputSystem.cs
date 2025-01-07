using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class InputSystem : MonoBehaviour
	{
		[SerializeField] private Bird _bird;
		[SerializeField] private GameManager _gameManager;

		private static InputSystem _instance;

		private UnityInputActions _unityInputActions;
		private InputControllerBird _inputControllerBird;

		#region -Monobehavior callbacks-
		private void Awake()
		{
			if (_instance != null)
				Debug.LogError($"It is not possible to create more than 1 instance of this class: {gameObject.name}");

			_instance = this;

			_unityInputActions = new UnityInputActions();

			InitInputControllers(_unityInputActions);
		}

		private void OnEnable()
		{
			_unityInputActions.Enable();

			_gameManager.OnGameplayRestartedEvent += GameplayRestarted;
			_gameManager.OnGameOverEvent += GameOver;
		}

		private void OnDisable()
		{
			_gameManager.OnGameplayRestartedEvent -= GameplayRestarted;
			_gameManager.OnGameOverEvent -= GameOver;

			DisableAllInputControllers();

			_unityInputActions.Disable();
		}
		#endregion -Monobehavior callbacks-

		#region -Internal methods-
		private void GameplayRestarted()
		{
			_inputControllerBird.Enable();
		}

		private void GameOver()
		{
			_inputControllerBird.Disable();
		}
		#endregion -Internal methods-

		#region -Input controllers-
		private void InitInputControllers(UnityInputActions unityInputActions)
		{
			InitInputControllerLocomotion(unityInputActions);
		}
		
		private void DisableAllInputControllers()
		{
			_inputControllerBird.Disable();
		}

		private void InitInputControllerLocomotion(UnityInputActions unityInputActions)
		{
			if (_bird.TryGetComponent(out IControllableBird controllable) == false)
				Debug.LogError($"There is no IControllable component in object: {gameObject.name}");

			_inputControllerBird = new InputControllerBird(unityInputActions, controllable);
		}
		#endregion -Input controllers-
	}
}
