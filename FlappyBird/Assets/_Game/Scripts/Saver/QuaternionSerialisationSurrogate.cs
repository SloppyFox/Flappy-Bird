using System.Numerics;
using System.Runtime.Serialization;
namespace SloppyFox.FlappyBird
{
	public class QuaternionSerialisationSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			var quaternion = (Quaternion) obj;
			info.AddValue("x", quaternion.X);
			info.AddValue("y", quaternion.Y);
			info.AddValue("z", quaternion.Z);
			info.AddValue("w", quaternion.W);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			var quaternion = (Quaternion)obj;
			quaternion.X = (float)info.GetValue("x", typeof(float));
			quaternion.Y = (float)info.GetValue("y", typeof(float));
			quaternion.Z = (float)info.GetValue("z", typeof(float));
			quaternion.W = (float)info.GetValue("w", typeof(float));
			obj = quaternion;
			return obj;
		}
	}
}
