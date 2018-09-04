using System;

namespace cn.mob.unity3d.sdkporter
{
	#if UNITY_IOS
	public class MOBPathModel
	{
		public string rootPath;
		public string savePath;
		public string filePath;
		public MOBPathModel ()
		{
			rootPath = "";
			savePath = "";
			filePath = "";
		}
	}
	#endif
}

