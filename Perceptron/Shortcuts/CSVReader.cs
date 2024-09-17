using System.IO;

namespace Shortcuts
{
    public class CSVReader<T>
    {
        string file_path = "";
        StreamReader sr;

        public string File_path { get => file_path; set => file_path = value; }

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

        public T[,] Read_CSV(bool has_header, string file = "")
        {
            if (file == "") file = file_path;
            string line;
            int x = 0;
            int y = 0;

            int line_number = 0;

            if (has_header) sr.ReadLine();

            while ((line = sr.ReadLine()) != null)
            {
                if(line_number == 0)
                {
                    x = line.Split(',').Length;
                }
                line_number++;
            }
            y = line_number;

            sr.BaseStream.Position = 0;
            if (has_header) sr.ReadLine();

            T[,] values = new T[y,x];

            line_number = 0;

            while ((line = sr.ReadLine()) != null)
            {
                string[] split_line = line.Split(',');

                for (int i = 0; i < split_line.Length; i++)
                {
                    try
                    {
                        values[line_number,i] = (T)Convert.ChangeType(split_line[i], typeof(T));
                    } catch
                    {
                        values[line_number,i] = default(T);
                    }
                }
                line_number++;
            }
            return values;
        }

        public Data_label_pack<T> Split_data(T[,] in_data, int cut)
        {
            T[,] data = new T[in_data.GetLength(0), in_data.GetLength(1) - cut];
            string[] labels = new string[in_data.GetLength(0)];

            for (int i = 0; i < in_data.GetLength(0); i++)
            {
                for (int j = 0; j < in_data.GetLength(1); j++)
                {
                    if(j < cut)
                    {
                        //Console.WriteLine($"{i}, {j}");
                        labels[i] = in_data[i, j].ToString();
                    }
                    else
                    {
                        data[i, j - cut] = in_data[i, j];
                    }
                }
            }
            return new Data_label_pack<T>(data, labels);
        }
    }
}

