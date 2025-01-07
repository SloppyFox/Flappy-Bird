using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public abstract class InputControllerBase<T> where T : IControllable
	{
		protected readonly UnityInputActions _unityInputActions;
		protected readonly T _controllable;

		private bool _isEnabled = false;

		protected InputControllerBase(UnityInputActions unityInputActions, T controllable)
		{
			_unityInputActions = unityInputActions;
			_controllable = controllable;
		}

		public void Enable()
		{
			if (_isEnabled)
				Debug.LogError($"Object type of {this} is already ENABLED");

			SetupActions();

			_isEnabled = true;
		}

		public void Disable()
		{
			if (_isEnabled == false)
				return;

			Reset();

			_isEnabled = false;
		}

		/// <summary>
		/// Use this method for SUBSCRIBES events _unityInputActions
		/// </summary>
		protected virtual void SetupActions() { }

		/// <summary>
		/// Use this method for UNSUBSCRIBES events _unityInputActions
		/// </summary>
		protected virtual void Reset() { }
	}
}
