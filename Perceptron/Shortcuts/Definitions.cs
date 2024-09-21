namespace Shortcuts
{

    /// <summary>
    /// A structure that packs data with corresponding labels, useful for datasets in machine learning applications.
    /// </summary>
    /// <typeparam name="T">The type of data stored in the pack.</typeparam>
    public struct Data_label_pack <T>
    {
        readonly T[,] data;
        readonly string[] labels;

        /// <summary>
        /// Initializes a new instance of the <see cref="Data_label_pack{T}"/> struct with specified data and labels.
        /// </summary>
        /// <param name="data_cut">A 2-dimensional array of data.</param>
        /// <param name="label_cut">An array of labels corresponding to the data.</param>
        public Data_label_pack(T[,] data_cut, string[] label_cut)
        {
            data = data_cut;
            labels = label_cut;
        }

        /// <summary>
        /// Gets the 2-dimensional array of data.
        /// </summary>
        public T[,] Data { get => data;}

        /// <summary>
        /// Gets the array of labels corresponding to the data.
        /// </summary>
        public string[] Labels { get => labels; }
    }

    public struct Weight
    {
        public ML_Node Left;
        public float value;
        public ML_Node Right;

        public Weight(ML_Node left, ML_Node right)
        {
            Random rand = new Random();
            Left = left;
            value = (float)(rand.NextDouble() - .5f) * 10;
            Right = right;
        }

        public void SetWeight(float weight)
        {
            value = weight;
        }
    }
}

