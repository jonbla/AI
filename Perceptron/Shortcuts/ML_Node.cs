namespace Shortcuts
{

    /// <summary>
    /// A specialized node class for machine learning applications, inheriting from the base Node class with float values.
    /// </summary>
    public class ML_Node : Node<float>
    {
        //Dictionary<ML_Node, (float weight, float bias)> NodeWeightBias;
        Dictionary<ML_Node, float> NodeWeightPair = new Dictionary<ML_Node, float>();
        Weight[] weights = new Weight[0];
        float bias = 0f;
        public int LayerNumber;

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
        /*public void AddConnection(ML_Node node)
        {
            Random rand = new Random();
            NodeWeightPair.Add(node, (float)(rand.NextDouble() - .5f) * 10);
        }*/

        public void AddWeights(Weight[] weights_new)
        {
            Weight[] weights_old = weights;
            weights = new Weight[weights_old.Length + weights_new.Length];
            int i = 0;
            foreach (Weight weight in weights_old)
            {
                weights[i] = weight;
                i++;
            }

            foreach (Weight weight in weights_new)
            {
                weights[i] = weight;
                i++;
            }
        }

        public override string ToString()
        {
            return $"Layer: {LayerNumber} | Value: {base.Value} | # of weights: {weights.Length} | Bias: {bias}";
        }
    }
}

