using System.Numerics;
using System.Runtime.Serialization;

namespace SloppyFox.FlappyBird
{
	public class Vector3SerialisationSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			var vector3 = (Vector3) obj;
			info.AddValue("x", vector3.X);
			info.AddValue("y", vector3.Y);
			info.AddValue("z", vector3.Z);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			var vector3 = (Vector3)obj;
			vector3.X = (float)info.GetValue("x", typeof(float));
			vector3.Y = (float)info.GetValue("y", typeof(float));
			vector3.Z = (float)info.GetValue("z", typeof(float));
			obj = vector3;
			return obj;
		}
	}
}
