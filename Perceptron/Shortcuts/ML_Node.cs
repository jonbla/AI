namespace Shortcuts
{

    /// <summary>
    /// A specialized node class for machine learning applications, inheriting from the base Node class with float values.
    /// </summary>
    public class ML_Node : Node<float>
    {
        //Dictionary<ML_Node, (float weight, float bias)> NodeWeightBias;
        Dictionary<ML_Node, float> NodeWeightPair = new Dictionary<ML_Node, float>();
        float bias;

        /// <summary>
        /// Initializes a new instance of the <see cref="ML_Node"/> class with a specified value and bias.
        /// </summary>
        /// <param name="Value">The floating-point value of this node.</param>
        /// <param name="Bias">The bias value for this node.</param>
        public ML_Node(float Value, float Bias) : base(Value)
        {
            bias = Bias;
        }

        /*public ML_Node(float Value, float Bias, List<Node<float>> neighbours) : base(Value, neighbours)
        {
            Random rand = new Random();

            bias = Bias;

            foreach (Node<float> node in neighbours)
            {
                NodeWeightPair.Add((ML_Node)node, (float)(rand.NextDouble()-.5f)*10);
            }
        }*/

        /// <summary>
        /// Adds a connection to another node with a randomly initialized weight.
        /// </summary>
        /// <param name="node">The node to connect to this node.</param>
        public void AddConnection(ML_Node node)
        {
            Random rand = new Random();
            NodeWeightPair.Add(node, (float)(rand.NextDouble() - .5f) * 10);
        }
    }
}

