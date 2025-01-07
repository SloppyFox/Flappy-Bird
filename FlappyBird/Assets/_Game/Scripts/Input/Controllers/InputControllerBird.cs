using UnityEngine.InputSystem;

namespace SloppyFox.FlappyBird
{
	public class InputControllerBird : InputControllerBase<IControllableBird>
	{
		public InputControllerBird(UnityInputActions unityInputActions, IControllableBird controllable) : base(unityInputActions, controllable) { }

		/// <summary>
		/// Use this method for SUBSCRIBES events _unityInputActions
		/// </summary>
		protected override void SetupActions()
		{
			_unityInputActions.Locomotion.Jump.performed += Jump;
		}

		/// <summary>
		/// Use this method for UNSUBSCRIBES events _unityInputActions
		/// </summary>
		protected override void Reset()
		{
			_unityInputActions.Locomotion.Jump.performed -= Jump;
		}

		private void Jump(InputAction.CallbackContext obj)
		{
			_controllable.Flap();
		}
	}
}
