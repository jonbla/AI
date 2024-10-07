using System.Runtime.Serialization;

namespace Shortcuts
{
    /// <summary>
    /// A specialized node class for machine learning applications, inheriting from the base Node class with float values.
    /// </summary>
    public class ML_Node
    {
        float value;

        Weight[] weights_L = new Weight[0];

        Weight[] weights_R = new Weight[0];

        float bias = 0f; //b

        int layerNumber;

        public float Value { get => value; set => this.value = value; }
        public Weight[] Weights_L { get => weights_L; set => weights_L = value; }
        public Weight[] Weights_R { get => weights_R; set => weights_R = value; }
        public float Bias { get => bias; set => bias = value; }
        public int LayerNumber { get => layerNumber; set => layerNumber = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ML_Node"/> class with a specified value and bias.
        /// </summary>
        /// <param name="Value">The floating-point value of this node.</param>
        /// <param name="Bias">The bias value for this node.</param>
        public ML_Node(float Value, float Bias)
        {
            value = Value;
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
            return $"Layer: {LayerNumber, -2} | Value: {value, -13} | # of weights Left: {weights_L.Length,-5} | # of weights Right: {weights_R.Length,-5} | Bias: {bias}";
        }
    }
}

