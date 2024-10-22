using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDemo2.Model
{

    public class MovieSerializer
    {
        public static string filepath = ConfigurationManager.AppSettings["Moviefile"];

        private const string MovieFile = "movie.json";
        public static void SerializeMovies(Movie[] movies)
        {
            var json = JsonConvert.SerializeObject(movies);
            File.WriteAllText(MovieFile, json);
        }
        public static Movie[] DeserializeMovies()
        {
            if (!File.Exists(MovieFile))
            {
                return new Movie[0];
            }

            var json = File.ReadAllText(MovieFile);
            return JsonConvert.DeserializeObject<Movie[]>(json);
        }

       
    }
    }



    

