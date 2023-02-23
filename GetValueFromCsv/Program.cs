using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

string filePath = "\\..\\..\\..\\..\\..\\TouchPanelData.csv";
StreamReader sr = new StreamReader(filePath);
var dic = new Dictionary<int, FrameData>();
int frameCount = 0;
while (!sr.EndOfStream)
{
    string[] frame = sr.ReadLine().Split(',');

    int[] tempArray = new int[frame.Length];
    for (int i = 0; i < tempArray.Length; i++)
    {
        if (int.TryParse(frame[i], out int result))
        {
            tempArray[i] = result;
        }
    }
    var frameDataObj = new FrameData()
    {
        Values = tempArray
    };
    dic.Add(frameCount, frameDataObj);
    frameCount++;
}



foreach (var kvp in dic)
{
    Console.Write($"frame:{kvp.Key}: ");
    foreach (var value in kvp.Value.Values)
    {
        Console.Write($"{value} ");
    }
    Console.WriteLine();

    Console.WriteLine($"value:{kvp.Value.Values[1]}");
}

foreach (var kvp in dic)
{
    Console.Write($"{kvp.Key}: ");
    Console.Write($"position:{Array.IndexOf(kvp.Value.Values, kvp.Value.Values.Max())} max:{kvp.Value.Values.Max()} ");
    Console.Write($"min:{kvp.Value.Values.Min()} ");


    Console.WriteLine();
}
public class FrameData
{
    public int[] Values { get; set; }
}

