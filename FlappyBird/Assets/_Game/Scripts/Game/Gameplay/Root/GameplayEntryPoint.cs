using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class GameplayEntryPoint : MonoBehaviour
	{
		[SerializeField] private ScoreCounter _scoreCounter;

		private Storage _storage;
		private GameData _data;

		private void Start()
		{
			_storage = new Storage();
			Load();
		}

		private void OnEnable()
		{
			_scoreCounter.HighScoreValueChangedEvent += HighScoreValueChanged;
		}

		private void OnDisable()
		{
			_scoreCounter.HighScoreValueChangedEvent -= HighScoreValueChanged;
		}

		private void HighScoreValueChanged(int newValue)
		{
			_data.HighScore = newValue;
			Save();
		}

		private void Save()
		{
			_storage.Save(_data);
			Debug.Log($"Game saved. HighScoreValue = {_data.HighScore}");
		}

		private void Load()
		{
			_data = (GameData)_storage.Load(new GameData());
			_scoreCounter.Init(_data.HighScore);
			Debug.Log($"Game loaded. HighScoreValue = {_data.HighScore}");
		}
	}
}
