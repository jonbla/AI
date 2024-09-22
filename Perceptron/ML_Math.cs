using System;
namespace Shortcuts
{
	public class ML_Math
	{
		public ML_Math()
		{
		}

		public float Sigmoid(float x)
		{
			return 1f / (1f + MathF.Exp(-x));
        }

		public float ReLU(float x)
		{
			float output = 0f;

			if(x > 0)
			{
				output = x;
			}

			return output;
		}
	}
}

