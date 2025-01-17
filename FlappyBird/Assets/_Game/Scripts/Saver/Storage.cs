using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SloppyFox.FlappyBird
{
	public class Storage
	{
		private readonly string _filePath;
		private BinaryFormatter _formatter;

		public Storage()
		{
			string directory = Application.persistentDataPath + "saves";

			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			_filePath = directory + "/GameSave.save";
			InitBinaryFormatter();
		}

		private void InitBinaryFormatter()
		{
			_formatter = new BinaryFormatter();
			var selector = new SurrogateSelector();

			var vector3Surrogate = new Vector3SerialisationSurrogate();
			var quaternionSurrogate = new QuaternionSerialisationSurrogate();

			selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3Surrogate);
			selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), quaternionSurrogate);

			_formatter.SurrogateSelector = selector;
		}

		public object Load(object saveDataByDefault)
		{
			if (!File.Exists(_filePath))
			{
				if (saveDataByDefault != null)
					Save(saveDataByDefault);

				return saveDataByDefault;
			}

			var file = File.Open(_filePath, FileMode.Open);
			var savedData = _formatter.Deserialize(file);
			file.Close();
			return savedData;
		}

		public void Save(object saveData)
		{
			var file = File.Create(_filePath);
			_formatter.Serialize(file, saveData);
			file.Close();
		}
	}
}
