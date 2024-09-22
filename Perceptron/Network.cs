using System;
using System.Runtime.Serialization;
using Shortcuts;

namespace Perceptron
{
    [DataContract]
    public class Network
	{
        List<Layer> layers = new List<Layer>();
        int layerCount = 0;

        public List<Layer> Layers { get => layers; set => layers = value; }

        public Network(int[] FirstLayerValues, params int[] dimentions)
		{
			layers.Add(new Layer(FirstLayerValues));
            layerCount++;
            for (int i = 0; i < dimentions.Length; i++)
            {
				Layer newLayer = new Layer(dimentions[i]);
				newLayer.LayerNumber = layerCount;
                layers.Add(newLayer);
                layerCount++;
            }
			CombineLayers();
        }

		public Network(params int[] dimentions)
		{
			for (int i = 0; i < dimentions.Length; i++)
			{
                Layer newLayer = new Layer(dimentions[i]);
                newLayer.LayerNumber = layerCount;
                layers.Add(newLayer);
                layerCount++;
            }
            CombineLayers();
        }

		private void CombineLayers()
		{
			for (int i = 0; i < layers.Count-1; i++)
			{
				Console.WriteLine($"Combining Layer {i} and layer {i + 1}");
				AddLayers(layers[i], layers[i + 1]);
			}
		}

		private void AddLayers(Layer left, Layer right)
		{
			int right_node_size = right.Nodes.Length;

			for (int i = 0; i < left.Nodes.Length; i++)
			{
                Weight[] weights = new Weight[right_node_size];

				for (int j = 0; j < right_node_size; j++)
				{
					weights[j] = new Weight(left.Nodes[i], right.Nodes[j]);
                    right.Nodes[j].AddWeightsLeft(new Weight[] { weights[j] });
                }

				left.Nodes[i].AddWeightsRight(weights);
            }
		}

		public void CalculateNetwork(Activation activation)
		{
			foreach (Layer layer in layers)
			{
				layer.CalculateValues(activation);
			}
		}

		public void PrintInfoVerbose()
		{
            for (int j = 0; j < Layers.Count; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        Console.WriteLine(Layers[j].Nodes[i]);
                    }
                    catch (IndexOutOfRangeException) { }
                }
                Console.WriteLine("---");
            }
        }

        public override string ToString()
        {
            string output = $"Number of Layers: {layers.Count}\n---\n";

			int i = 0;
			foreach (Layer layer in layers){
				output += $"Nodes in layer {i}: {layer.Nodes.Count()}\n";
				i++;
			}

			return output;
        }

		public void SetInput(int[] input)
		{
			for (int i = 0; i < layers[0].Nodes.Length; i++)
			{
				layers[0].Nodes[i].Value = input[i];
            }
		}

		public float GetCost(float[] target)
		{
			float cost = 0f;

			for (int i = 0; i < layers[layerCount-1].Nodes.Length; i++)
			{
				cost += MathF.Pow(layers[layerCount-1].Nodes[i].Value - target[i], 2);
            }

			return cost;
		}
    }
}

