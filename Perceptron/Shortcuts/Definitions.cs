namespace Shortcuts
{

    public struct Data_label_pack <T>
    {
        readonly T[,] data;
        readonly string[] labels;

        public Data_label_pack(T[,] data_cut, string[] label_cut)
        {
            data = data_cut;
            labels = label_cut;
        }

        public T[,] Data { get => data;}
        public string[] Labels { get => labels; }
    }
}

