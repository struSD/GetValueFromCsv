string filePath = ".....TouchPanelData.csv";
string[] lines = File.ReadAllLines(filePath);
int rowCount = lines.Length;
int colCount = lines[0].Split(',').Length;

int[,] data = new int[rowCount, colCount];
for (int i = 0; i < rowCount; i++)
{
    string[] values = lines[i].Split(',');
    for (int j = 0; j < colCount; j++)
    {
        for (int k = 0; k < values.Length; k++)
        {
            if (string.IsNullOrEmpty(values[k]))
            {
                values[k] = "0";
            }
        }
        data[i, j] = int.Parse(values[j]);
    }
}


GetMaxNumbers(data);
GetMaxSingleNum(1, data);


void ShowMass(int[,] mass)
{
    for (int i = 0; i < rowCount; i++)
    {
        for (int j = 0; j < colCount; j++)
        {
            Console.Write(data[i, j] + " ");
        }
        Console.WriteLine();
    }
}
void GetMaxSingleNum(int row, int[,] mass)
{
    int rowNumber = row;
    int max = mass[rowNumber, 0];

    for (int j = 1; j < mass.GetLength(1); j++)
    {
        if (mass[rowNumber, j] > max)
        {
            max = mass[rowNumber, j];
        }
    }
    Console.WriteLine("Max value on row {0} - {1}", rowNumber, max);
}

void GetMaxNumbers(int[,] mass)
{
    for (int i = 0; i < mass.GetLength(0); i++)
    {
        int max = mass[i, 0];
        int pos = 0;

        for (int j = 1; j < mass.GetLength(1); j++)
        {
            if (mass[i, j] > max)
            {
                max = mass[i, j];
                pos = j;
            }
        }
        Console.WriteLine("Max value on row {0}: {1}, position: {2}", i, max, pos);
    }
}






