using System;
using System.Drawing;
using System.Runtime.Serialization;
using Tools;

namespace Perceptron
{
    /// <summary>
    /// Represents a layer in a neural network, consisting of multiple nodes.
    /// </summary>
    public class Layer
	{
        int layerNumber = 0;
        /// <summary>
        /// Array of nodes contained in this layer.
        /// </summary>
        ML_Node[] nodes;

        /// <summary>
        /// Array of nodes contained in this layer.
        /// </summary>
        public ML_Node[] Nodes { get => nodes; }
        public int LayerNumber { get => layerNumber; set => SetLayerNumber(value); }

        private void SetLayerNumber(int val)
        {
            layerNumber = val;
            foreach (ML_Node node in nodes)
            {
                node.LayerNumber = val;
            }
        }

        public void CalculateValues(Activation activation)
        {
            if (layerNumber == 0) return;
            foreach (ML_Node node in nodes)
            {
                node.CalculateValue(activation);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Layer"/> class with a specified number of nodes.
        /// </summary>
        /// <param name="size">The number of nodes in the layer.</param>
        public Layer(int size)
		{
			Random rand = new Random();
			nodes = new ML_Node[size];
			for (int i = 0; i < size; i++)
			{
				nodes[i] = new ML_Node(0f, (float)(rand.NextDouble() - .5f) * 10);
                //Console.WriteLine($"Created node: {nodes[i]}");
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Layer"/> class with a specified array of nodes.
        /// </summary>
        /// <param name="Nodes">An array of <see cref="ML_Node"/> to initialize the layer with.</param>
        public Layer(ML_Node[] Nodes)
		{
			nodes = Nodes;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Layer"/> class with a specified array of values.
        /// Each value initializes a node with a random bias.
        /// </summary>
        /// <param name="Values">An array of integer values to initialize the nodes.</param>
		public Layer(int[] Values)
		{
            nodes = new ML_Node[Values.Length];
            Random rand = new Random();

            for (int i = 0; i < Values.Length; i++)
            {
                nodes[i] = new ML_Node(Values[i], (float)(rand.NextDouble() - .5f) * 10);
            }
        }

        public Layer(float[] Values)
        {
            nodes = new ML_Node[Values.Length];
            Random rand = new Random();

            for (int i = 0; i < Values.Length; i++)
            {
                nodes[i] = new ML_Node(Values[i], (float)(rand.NextDouble() - .5f) * 10);
            }
        }
    }
}

