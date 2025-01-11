using UnityEngine;

namespace SloppyFox.FlappyBird
{
	[RequireComponent(typeof(Camera))]
	public class MainCamera : MonoBehaviour
	{
		private Camera _mainCamera;

		private void Awake()
		{
			_mainCamera = GetComponent<Camera>();

			_mainCamera.orthographic = true;
			_mainCamera.orthographicSize = GameConfig.MAIN_CAMERA_ORTOGRAPHIC_SIZE;
		}
	}
}
