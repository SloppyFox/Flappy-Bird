using System;

namespace SloppyFox.FlappyBird
{
	[Serializable]
	public class GameData
	{
		public int HighScore;

		public GameData()
		{
			HighScore = 0;
		}
	}
}
