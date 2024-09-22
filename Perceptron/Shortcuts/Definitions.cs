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

        static T[][] ConvertToJaggedArray<T>(T[,] twoDimensionalArray)
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
        public ML_Node Left;
        public float Strength;
        public ML_Node Right;

        public float calculated_value { get => Left.Value * Strength; }

        public Weight(ML_Node left, ML_Node right)
        {
            Random rand = new Random();
            Left = left;
            Strength = (float)(rand.NextDouble() - .5f) * 10;
            Right = right;
        }

        public void SetWeight(float weight)
        {
            Strength = weight;
        }
    }

    public enum Activation
    {
        Sigmoid,
        ReLU
    }
}

