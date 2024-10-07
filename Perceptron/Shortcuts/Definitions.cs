using System.Runtime.Serialization;

namespace Shortcuts
{

    /// <summary>
    /// A structure that packs data with corresponding labels, useful for datasets in machine learning applications.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the pack.</typeparam>
    public struct Data_label_pack <T>
    {
        readonly T[][] data;
        readonly string[] labels;

        /// <summary>
        /// Initializes a new instance of the <see cref="Data_label_pack{T}"/> struct with specified data and labels.
        /// </summary>
        /// <param name="data_cut">A 2-dimensional array of data.</param>
        /// <param name="label_cut">An array of labels corresponding to the data.</param>
        public Data_label_pack(T[,] data_cut, string[] label_cut)
        {
            data = ConvertToJaggedArray(data_cut);
            labels = label_cut;
        }

        /// <summary>
        /// Gets the 2-dimensional array of data.
        /// </summary>
        public T[][] Data { get => data;}

        /// <summary>
        /// Gets the array of labels corresponding to the data.
        /// </summary>
        public string[] Labels { get => labels; }

        private static T[][] ConvertToJaggedArray<T>(T[,] twoDimensionalArray)
        {
            int rows = twoDimensionalArray.GetLength(0);
            int columns = twoDimensionalArray.GetLength(1);

            T[][] jaggedArray = new T[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new T[columns];
                for (int j = 0; j < columns; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }
            return jaggedArray;
        }
    }

    public struct Weight
    {
        public ML_Node left;
        float strength;
        public ML_Node right;

        public float calculated_value { get => left.Value * strength; }
        //public ML_Node Left { get => left; set => left = value; }
        public float Strength { get => strength; set => strength = value; }
        //public ML_Node Right { get => right; set => right = value; }

        public Weight(ML_Node left, ML_Node right)
        {
            Random rand = new Random();
            this.left = left;
            strength = (float)(rand.NextDouble() - .5f) * 10;
            this.right = right;
        }

        public void SetWeight(float weight)
        {
            strength = weight;
        }
    }

    public enum Activation
    {
        Sigmoid,
        ReLU
    }
}

