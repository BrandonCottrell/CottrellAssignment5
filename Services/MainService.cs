using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using CottrellAssignment5.Models;
using CottrellAssignment5.Services;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace CottrellAssignment5.Services;

/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
{
    private readonly IFileService _fileService;
    public MainService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void Invoke()
    {
        string choice;
        do
        {
            List<UInt64> MovieIds = new List<UInt64>();
            List<Movie> MoviesList = new List<Movie>();

            // display choices to user
            Console.WriteLine("1) Add Movie");
            Console.WriteLine("2) View All Movies");
            Console.WriteLine("Enter to quit");

            // input selection
            choice = Console.ReadLine();
            Console.WriteLine($"User Choice: {choice}");

            if (choice == "1")
            {
                var sw = new StreamWriter("movies.json");

                var movie = new Movie();
                Console.WriteLine("Enter Movie Title");
                movie.Title = Console.ReadLine();
                Console.WriteLine("Enter Genre");
                movie.Genre = Console.ReadLine();
                movie.Id = MovieIds.Count + 1;


                var json = JsonConvert.SerializeObject(movie);
                sw.WriteLine(json);
                sw.Close();

            }
            else if (choice == "2")
            {
                var sr = new StreamReader("movies.json");
                var line = sr.ReadLine();

                Movie m = JsonConvert.DeserializeObject<Movie>(line);



                Console.WriteLine($"My movie is: {m.Id}, {m.Title}, {m.Genre}");
                sr.Close();
            }
        } while (choice == "1" || choice == "2");
    }
}