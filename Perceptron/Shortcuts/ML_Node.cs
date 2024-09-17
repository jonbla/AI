namespace Shortcuts
{

    public class ML_Node : Node<float>
    {
        //Dictionary<ML_Node, (float weight, float bias)> NodeWeightBias;
        Dictionary<ML_Node, float> NodeWeightPair = new Dictionary<ML_Node, float>();
        float bias;

        public ML_Node(float Bias) : base(Bias)
        {
            bias = Bias;
        }

        public ML_Node(float Bias, List<Node<float>> neighbours) : base(Bias, neighbours)
        {
            Random rand = new Random();

            bias = Bias;

            foreach (Node<float> node in neighbours)
            {
                NodeWeightPair.Add((ML_Node)node, (float)(rand.NextDouble()-.5f)*10);
            }
        }
    }
}

