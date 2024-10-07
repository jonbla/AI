using System.IO;
using System.Diagnostics;

namespace Shortcuts
{
    /// <summary>
    /// A class to read CSV files and convert them into a 2D array of a specified data type.
    /// </summary>
    /// <typeparam name="T">The type of data to be read from the CSV file.</typeparam>
    public class CSVReader<T>
    {
        string file_path = "";
        StreamReader? sr;

        /// <summary>
        /// Gets or sets the file path of the CSV file to be read.
        /// </summary>
        public string File_path { get => file_path; set => file_path = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVReader{T}"/> class.
        /// </summary>
        /// <param name="file">The file path of the CSV file to read. If not provided, defaults to an empty string.</param>
        public CSVReader(string file = "")
        {
            try
            {
                sr = new StreamReader(file);
                file_path = file;
            } catch (FileNotFoundException)
            {
                file_path = "";
            }
        }

        /// <summary>
        /// Reads the CSV file and returns its contents as a 2-dimensional array of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="has_header">Indicates whether the CSV file has a header row.</param>
        /// <param name="file">The file path of the CSV file to read. If not provided, defaults to the stored file path.</param>
        /// <returns>A 2-dimensional array containing the data read from the CSV file.</returns>
        public T[,] Read_CSV(bool has_header, string file = "")
        {
            if (file == "") file = file_path;

            Debug.Assert(file != "");

            if (sr == null) sr = new StreamReader(file);

            string line;
            int x = 0;
            int y = 0;

            int line_number = 0;

            if (has_header) sr.ReadLine();

            //Counting Lines
            while ((line = sr.ReadLine()) != null)
            {
                if(line_number == 0)
                {
                    x = line.Split(',').Length;
                }
                line_number++;
            }
            y = line_number;

            //Resetting file reader pointer
            sr.BaseStream.Position = 0;
            if (has_header) sr.ReadLine();

            T[,] values = new T[y,x];

            line_number = 0;

            Console.WriteLine($"Dimentions are {x} Columns and {y} rows");

            //Reading lines
            while ((line = sr.ReadLine()) != null)
            {
                string[] split_line = line.Split(',');

                for (int i = 0; i < split_line.Length; i++)
                {
                    try
                    {
                        //Try convert CSV value into the type
                        values[line_number,i] = (T)Convert.ChangeType(split_line[i], typeof(T));
                    } catch
                    {
                        //Set to default value on fail (ie: 0 for int, 0f for float, "" for string, null for most others)
                        values[line_number,i] = default(T);
                    }
                }
                line_number++;
            }
            return values;
        }

        /// <summary>
        /// Splits the input data into separate data and label arrays
        /// </summary>
        /// <param name="in_data">The input 2-dimensional array to be split.</param>
        /// <returns>A <see cref="Data_label_pack{T}"/> containing the split data and labels.</returns>
        public Data_label_pack<T> Split_data(T[,] in_data)
        {
            T[,] data = new T[in_data.GetLength(0), in_data.GetLength(1) - 1];
            string[] labels = new string[in_data.GetLength(0)];

            for (int i = 0; i < in_data.GetLength(0); i++)
            {
                for (int j = 0; j < in_data.GetLength(1); j++)
                {
                    if(j < 1)
                    {
                        //Console.WriteLine($"{i}, {j}");
                        labels[i] = in_data[i, j].ToString();
                    }
                    else
                    {
                        data[i, j - 1] = in_data[i, j];
                    }
                }
            }
            return new Data_label_pack<T>(data, labels);
        }
    }
}

