using System;
namespace Tools
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

        public double Sigmoid(double x)
		{
            return 1f / (1f + MathF.Exp((float)-x));
			
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

        public double ReLU(double x)
        {
            double output = 0f;

            if (x > 0)
            {
                output = x;
            }

            return output;
        }

		public void Softmax(ref float[] nodes)
		{
			float sum = 0f;

			foreach (float nodeVal in nodes) {
				sum += nodeVal*nodeVal;
			}

			for (int i = 0; i < nodes.Length; i++)
			{
				nodes[i] = (nodes[i]* nodes[i]) / sum;
			}
		}
    }
}

