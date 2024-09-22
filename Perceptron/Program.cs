﻿using Shortcuts;
using System.Text.Json;

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
        //Network network = new Network(CSVDataPack.Data[0], 16, 16, 16, 10);
        Network network = new Network(16, 16, 16, 16, 10);
        Console.WriteLine("\nNetwork Creation Success\n");
        Console.WriteLine(network);

        //network.PrintInfoVerbose();

        Console.WriteLine("\nCalculating values\n");

        network.CalculateNetwork(Activation.Sigmoid);

        string fileName = "/Users/dannysedlov/Documents/School/Masters/AM6007 (Computing with numerical)/AI/Network.json";
        JsonSerializerOptions JSONoptions = new JsonSerializerOptions();
        JSONoptions.WriteIndented = true;
        string jsonString = JsonSerializer.Serialize(network, options: JSONoptions);
        File.WriteAllText(fileName, jsonString);

        //network.PrintInfoVerbose();

        float avgCost = 0f;

        avgCost += network.GetCost(GetTargetVector(Int32.Parse(CSVDataPack.Labels[0])));

        for (int i = 1; i < CSVDataPack.Data.Length; i++)
        {
            network.SetInput(CSVDataPack.Data[i]);
            network.CalculateNetwork(Activation.Sigmoid);
            avgCost += network.GetCost(GetTargetVector(Int32.Parse(CSVDataPack.Labels[i])));
        }

        avgCost = avgCost / CSVDataPack.Data.Length;

        Console.WriteLine($"Avg Cost after {CSVDataPack.Data.Length} iterations: {avgCost}");

        //Console.ReadLine();
    }

    static float[] GetTargetVector(int target_value)
    {
        float[] target = new float[10];
        for (int i = 0; i < 10; i++)
        {
            target[i] = 0;
        }
        target[target_value] = 1;

        return target;
    }
}

