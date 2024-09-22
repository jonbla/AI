using System.Runtime.Serialization;

namespace Shortcuts
{

    /// <summary>
    /// A specialized node class for machine learning applications, inheriting from the base Node class with float values.
    /// </summary>
    public class ML_Node : Node<float>
    {
        //Dictionary<ML_Node, (float weight, float bias)> NodeWeightBias;
        public Dictionary<ML_Node, float> NodeWeightPair = new Dictionary<ML_Node, float>();

        public Weight[] weights_L = new Weight[0];

        public Weight[] weights_R = new Weight[0];

        public float bias = 0f;

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

        public float CalculateValue(Activation activation)
        {
            float calculatedValue = 0f;

            foreach (Weight weight in weights_L)
            {
                calculatedValue += weight.calculated_value;
            }
            calculatedValue += bias;

            switch (activation)
            {
                case Activation.Sigmoid:
                    calculatedValue = new ML_Math().Sigmoid(calculatedValue);
                    break;
                case Activation.ReLU:
                    calculatedValue = new ML_Math().ReLU(calculatedValue);
                    break;
            }

            Value = calculatedValue;
            return calculatedValue;
        }

        public void AddWeightsLeft(Weight[] weights_new)
        {
            Weight[] weights_old = weights_L;
            weights_L = new Weight[weights_old.Length + weights_new.Length];
            int i = 0;
            foreach (Weight weight in weights_old)
            {
                weights_L[i] = weight;
                i++;
            }

            foreach (Weight weight in weights_new)
            {
                weights_L[i] = weight;
                i++;
            }
        }

        public void AddWeightsRight(Weight[] weights_new)
        {
            Weight[] weights_old = weights_R;
            weights_R = new Weight[weights_old.Length + weights_new.Length];
            int i = 0;
            foreach (Weight weight in weights_old)
            {
                weights_R[i] = weight;
                i++;
            }

            foreach (Weight weight in weights_new)
            {
                weights_R[i] = weight;
                i++;
            }
        }

        public override string ToString()
        {
            return $"Layer: {LayerNumber, -2} | Value: {base.Value, -13} | # of weights Left: {weights_L.Length,-5} | # of weights Right: {weights_R.Length,-5} | Bias: {bias}";
        }
    }
}

