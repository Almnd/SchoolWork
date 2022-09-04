using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib.Framework;
using DataServiceLib.Moviedata;
using Microsoft.EntityFrameworkCore;

namespace DataServiceLib
{
    public class MovieDataService : MovieIDataService
    {
        //Movie Data dataservices ///////////////

        // actors dataservice
        public IList<Actors> ActorsToList()
        {
            var ctx = new Raw12Context();
            var actors = ctx.Actors.ToList();
            return actors;
        }

        public IList<Actors> GetActors()
        {
            return ActorsToList();
        }

        public Actors GetActor(string id)
        {
            var ctx = new Raw12Context();
            var actors = ctx.Actors;

            return actors.FirstOrDefault(x => x.Nconst == id); 
        }

        public IList<Actors> GetActorInfo(int page, int pageSize)
        {
            return ActorsToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfActors()
        {
            return ActorsToList().Count;
        }

        // movies dataservice
        public IList<Movies> MoviesToList()
        {
            var ctx = new Raw12Context();
            var movies = ctx.Movies.ToList();
            return movies;
        }

        public IList<Movies> GetMovies()
        {
            return MoviesToList();
        }

        public Movies GetMovie(string id)
        {
            var ctx = new Raw12Context();
            var movies = ctx.Movies;

            return movies.FirstOrDefault(x => x.TitleId.Trim() == id.Trim()); //trim to fix id whitespace
        }

        public IList<Movies> GetMovieInfo(int page, int pageSize)
        {
            return MoviesToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfMovies()
        {
            return ActorsToList().Count;
        }

        // genres dataservice
        public IList<Genres> GenresToList()
        {
            var ctx = new Raw12Context();
            var genres = ctx.Genres.ToList();
            return genres;
        }

        public IList<Genres> GetGenres()
        {
            return GenresToList();
        }

        public Genres GetGenre(string id)
        {
            var ctx = new Raw12Context();
            var genres = ctx.Genres;

            return genres.FirstOrDefault(x => x.TitleId == id);
        }

        public IList<Genres> GetGenreInfo(int page, int pageSize)
        {
            return GenresToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfGenres()
        {
            return GenresToList().Count;
        }


        // details dataservice
        public IList<Details> DetailsToList()
        {
            var ctx = new Raw12Context();
            var details = ctx.Details.ToList();
            return details;
        }

        public IList<Details> GetDetails()
        {
            return DetailsToList();
        }

        public Details GetDetail(string id)
        {
            var ctx = new Raw12Context();
            var details = ctx.Details;

            return details.FirstOrDefault(x => x.TitleId == id);
        }

        public IList<Details> GetDetailInfo(int page, int pageSize)
        {
            return DetailsToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfDetails()
        {
            return DetailsToList().Count;
        }

        // omdb dataservice
        public IList<Omdb> OmdbToList()
        {
            var ctx = new Raw12Context();
            var omdb = ctx.Omdb.ToList();
            return omdb;
        }

        public IList<Omdb> GetOmdbs()
        {
            return OmdbToList();
        }

        public Omdb GetOmdb(string id)
        {
            var ctx = new Raw12Context();
            var omdb = ctx.Omdb;

            return omdb.FirstOrDefault(x => x.Tconst == id);
        }

        public IList<Omdb> GetOmdbInfo(int page, int pageSize)
        {
            return OmdbToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfOmdbs()
        {
            return OmdbToList().Count;
        }

        // language dataservice
        public IList<Languages> LanguagesToList()
        {
            var ctx = new Raw12Context();
            var languages = ctx.Languages.ToList();
            return languages;
        }

        public IList<Languages> GetLanguages()
        {
            return LanguagesToList();
        }

        public Languages GetLanguage(string id)
        {
            var ctx = new Raw12Context();
            var languages = ctx.Languages;

            return languages.FirstOrDefault(x => x.TitleId == id);
        }

        public IList<Languages> GetLanguageInfo(int page, int pageSize)
        {
            return LanguagesToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfLanguages()
        {
            return LanguagesToList().Count;
        }

        // director dataservice
        public IList<Directors> DirectorsToList()
        {
            var ctx = new Raw12Context();
            var directors = ctx.Directors.ToList();
            return directors;
        }

        public IList<Directors> GetDirectors()
        {
            return DirectorsToList();
        }

        public Directors GetDirector(string id)
        {
            var ctx = new Raw12Context();
            var directors = ctx.Directors;

            return directors.FirstOrDefault(x => x.TitleId == id);
        }

        public IList<Directors> GetDirectorInfo(int page, int pageSize)
        {
            return DirectorsToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfDirectors()
        {
            return DirectorsToList().Count;
        }
    }
}
