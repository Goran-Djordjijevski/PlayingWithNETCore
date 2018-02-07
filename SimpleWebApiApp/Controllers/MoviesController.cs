using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApiApp.Models;

namespace SimpleWebApiApp.Controllers
{
    [Produces("application/json")]
    [System.Web.Http.Route("api/Movies")]
    public class MoviesController : ApiController
    {
        List<Movie> movies = new List<Movie>()
        {
            new Movie { Id = 1, Name = "Titanic", Genre = "Drama", Price = 10M },
            new Movie { Id = 2, Name = "Rocky", Genre = "Drama", Price = 15M },
            new Movie { Id = 3, Name = "Team America", Genre = "Comedy", Price = 20M }
        };

        public IEnumerable<Movie> GetAllMovies()
        {
            return movies;
        }

        public IHttpActionResult GetMovies(int id)
        {
            var movie = movies.FirstOrDefault(p => p.Id == id);

            if (movies == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}