// Sample Code Usage

using _01._Stream_Progress_Info;
using File = _01._Stream_Progress_Info.File;

Console.WriteLine(new StreamProgressInfo(new File("Article", 364, 150)).CalculateCurrentPercent());
Console.WriteLine(new StreamProgressInfo(new Music("Metallica", "Master of Puppets", 6952, 100)).CalculateCurrentPercent());