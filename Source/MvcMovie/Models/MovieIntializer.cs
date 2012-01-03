using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MvcMovie.Models {
    public class MovieInitializer : DropCreateDatabaseIfModelChanges<MovieDBContext> {
        protected override void Seed(MovieDBContext context) {
            var movies = new List<Movie> {  
  
                 new Movie { Title = "aa When Harry Met Sally",   
                             ReleaseDate=DateTime.Parse("1989-1-11"),   
                             Genre="Romantic Comedy",  
                             Rating="G",  
                             Price=7.99M},  

                     new Movie { Title = "Ghostbusters ",   
                             ReleaseDate=DateTime.Parse("1984-3-13"),   
                             Genre="Comedy",  
                              Rating="G",  
                             Price=8.99M},   
  
                 new Movie { Title = "Ghostbusters 2",   
                             ReleaseDate=DateTime.Parse("1986-2-23"),   
                             Genre="Comedy",  
                             Rating="G",  
                             Price=9.99M},   
                             
               new Movie { Title = "Rio Bravo",   
                             ReleaseDate=DateTime.Parse("1959-4-15"),   
                             Genre="Western",  
                             Rating="G",  
                             Price=3.99M}, 

                             
               new Movie { Title = "aaaaaaaaaaa",   
                             ReleaseDate=DateTime.Parse("1959-4-15"),   
                             Genre="Western",  
                             Rating="G",  
                             Price=3.99M}, 

               new Movie { Title = "Crazy Stupid love",   
                             ReleaseDate=DateTime.Parse("1999-4-15"),   
                             Genre="Comedy",  
                             Rating="G",  
                             Price=6.99M}   
             };

            movies.ForEach(d => context.Movies.Add(d));
        }
    }
}