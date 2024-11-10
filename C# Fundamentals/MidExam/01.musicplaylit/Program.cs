
namespace _01.musicplaylit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> songs = Console.ReadLine()
                .Split()
                .ToList();

            int countOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "Add":
                        if (songs.Contains(command[3]))
                        {
                            break;
                        }
                        songs.Add(command[3]);
                        Console.WriteLine($"{command[3]} successfully added");
                        break;
                    case "Delete":
                        int numberOfSongsToDelete = int.Parse(command[3]);
                        List<string> deletedSongs = new();
                        for (int j = 0; j < numberOfSongsToDelete; j++)
                        {
                            deletedSongs.Add(songs[0]);
                            songs.RemoveAt(0);
                        }
                        Console.WriteLine(string.Join(", ", deletedSongs) + " deleted");
                        break;
                    case "Shuffle":
                        int index1 = int.Parse(command[3]);
                        int index2 = int.Parse(command[5]);
                        if (InvalidIndex(index1, index2, songs))
                        {
                            break;
                        }                        
                        string temp = songs[index1];
                        songs[index1] = songs[index2];
                        songs[index2] = temp;
                        Console.WriteLine($"{songs[index1]} is swapped with {songs[index2]}");
                        break;
                    case "Insert":
                        string song = command[2];
                        int songIndex = int.Parse(command[4]);
                        if (songIndex < 0 || songIndex >= songs.Count)
                        {
                            Console.WriteLine("Index out of range");
                            break;
                        }
                        if (songs.Contains(song))
                        {
                            Console.WriteLine($"Song is already in the playlist");
                            break;
                        }
                        songs.Insert(songIndex, song);
                        Console.WriteLine($"{song} successfully inserted");
                        break;
                    case "Sort":
                        songs.Sort((x, y) => y.CompareTo(x));
                        break;
                    case "Play":
                        Console.WriteLine("Songs to Play:");
                        for (int k = 0; k < songs.Count; k++)
                        {
                            Console.WriteLine(songs[k]);
                        }
                        break;
                }
            }
        }

        static bool InvalidIndex(int one, int two, List<string> list)
        {
            return one < 0 || one >= list.Count || two < 0 || two >= list.Count;
        }
    }
}
