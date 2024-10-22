using MovieDemo2.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDemo2
{



   public class SimpleMoviesApp
    {
        static Movie[] movies = MovieSerializer.DeserializeMovies();
        static int movieCount = movies.Length;
        private const string MovieFile = "movies.json";

        static void Main(string[] args)
        {
             string filepath= ConfigurationManager.AppSettings["Moviefile"];
            Console.WriteLine(filepath);
            Console.WriteLine();
            Console.WriteLine("============Welcome to Movie Menu ==========\n");
            while (true)
            {
              
                Console.WriteLine("=>Choose Your Option<=");
                Console.WriteLine("1. Display movies");
                Console.WriteLine("2. Add movie");
                Console.WriteLine("3. Clear all movies");
                Console.WriteLine("4. Exit");
               

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayMovies();
                        break;

                    case "2":
                        AddMovie();
                        break;

                    case "3":
                        ClearAllMovies();
                        break;

                    case "4":
                        ExitProgram();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void DisplayMovies()
        {
            if (movies.Length == 0)
            {
                Console.WriteLine("No movies to display.");
            }
            else
            {
                foreach (var movie in movies)
                {
                    Console.WriteLine(movie);
                }
            }
        }
        static void AddMovie()
        {
            if (movieCount >= 5)
            {
                Console.WriteLine("Cannot add more than 5 movies.");
                return;
            }

            Console.Write("Enter movie id: ");
            int movieId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter movie name: ");
            string name = Console.ReadLine();

            Console.Write("Enter movie genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter movie year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Movie newMovie = new Movie(movieId, name, genre, year);

            /* Array.Resize(ref movies, movieCount + 1); 
             movies[movieCount] = newMovie;
             movieCount++;*/

            Movie[] MoviesArray = new Movie[movieCount + 1];
            for (int i = 0; i < movieCount; i++)
            {
                MoviesArray[i] = movies[i];
            }
            MoviesArray[movieCount] = newMovie;

            movies = MoviesArray;
            movieCount++;

            Console.WriteLine("Movie added successfully!");

            MovieSerializer.SerializeMovies(movies); 
        }
        static void ClearAllMovies()
        {
           movies = new Movie[0]; 
            movieCount = 0;
            Console.WriteLine("All movies cleared.");
        }
        static void ExitProgram()
        {
            MovieSerializer.SerializeMovies(movies); 
            Console.WriteLine("Exiting... Your movies have been saved.");
            Environment.Exit(0); 
        }
    }
}

    
