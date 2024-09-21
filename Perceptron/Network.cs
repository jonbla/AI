using System;
using Shortcuts;

namespace Perceptron
{
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

        public override string ToString()
        {
            string output = $"Number of Layers: {layers.Count}\n";

			int i = 0;
			foreach (Layer layer in layers){
				output += $"Nodes in layer {i}: {layer.Nodes.Count()}\n";
				i++;
			}

			return output;
        }

    }
}

