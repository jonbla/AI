using Shortcuts;

namespace Perceptron;

class Program
{
    static void Main(string[] args)
    {
        CSVReader<int> CSV = new CSVReader<int>("/Users/dannysedlov/Documents/School/Masters/Datasets/MNIST_CSV/mnist_test.csv");
        int[,] CSVdata = CSV.Read_CSV(true);
        Console.WriteLine(CSVdata.GetLength(0));
        Console.WriteLine(CSVdata.GetLength(1));
        Data_label_pack<int> CSVDataPack = CSV.Split_data(CSVdata, 1);
        int[] numericLabels = new int[CSVDataPack.Labels.Count()];

        for (int i = 0; i < CSVDataPack.Labels.Count(); i++)
        {
            numericLabels[i] = Int32.Parse(CSVDataPack.Labels[i]);
        }

        Console.WriteLine("\nCreating Network\n");
        Network network = new Network(CSVDataPack.Data[0], 16, 16, 16, 10);
        //Network network = new Network(100, 16, 16, 16, 10);
        Console.WriteLine("\nNetwork Creation Success\n");
        Console.WriteLine(network);


        for (int j = 0; j < network.Layers.Count; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine(network.Layers[j].Nodes[i]);
                }
                catch (IndexOutOfRangeException) { }
            }
            Console.WriteLine("---");
        }

        Console.WriteLine(network.Layers[0].Nodes[0].weights_R[0].Right.weights_R[0].Right.weights_R[0].Right);
    }
}

