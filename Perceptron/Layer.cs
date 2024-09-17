using System;
using System.Drawing;
using Shortcuts;

namespace Perceptron
{
    /// <summary>
    /// Represents a layer in a neural network, consisting of multiple nodes.
    /// </summary>
    public class Layer
	{
        /// <summary>
        /// Array of nodes contained in this layer.
        /// </summary>
        ML_Node[] nodes;

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
				nodes[i] = new ML_Node(0, (float)(rand.NextDouble() - .5f) * 10);
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
                nodes[i] = new ML_Node(Values.Length, (float)(rand.NextDouble() - .5f) * 10);
            }
        }

        /// <summary>
        /// Adds a previous layer to the current layer, connecting each node in the current layer
        /// to every node in the specified previous layer.
        /// </summary>
        /// <param name="layer">The previous <see cref="Layer"/> to connect to this layer.</param>
		public void AddPreviousLayer(Layer layer)
		{
			foreach (ML_Node node in nodes)
			{
				foreach (ML_Node old_node in layer.nodes)
				{
					node.Add_neighbour(old_node);
				}
			}
		}
	}
}

