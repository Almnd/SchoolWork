using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using DataServiceLib.Moviedata;

namespace DataServiceLib
{
    public interface MovieIDataService
    {
        //Movie Data interfaces///////////

        //actors interface
        IList<Actors> GetActors();
        Actors GetActor(string id);
        IList<Actors> GetActorInfo(int page, int pageSize);
        int NumberOfActors();

        //movies interface
        IList<Movies> GetMovies();
        Movies GetMovie(string id);
        IList<Movies> GetMovieInfo(int page, int pageSize);
        int NumberOfMovies();

        //genres interface
        IList<Genres> GetGenres();
        Genres GetGenre(string id);
        IList<Genres> GetGenreInfo(int page, int pageSize);
        int NumberOfGenres();

        //details interface
        IList<Details> GetDetails();
        Details GetDetail(string id);
        IList<Details> GetDetailInfo(int page, int pageSize);
        int NumberOfDetails();

        //omdb interface
        IList<Omdb> GetOmdbs();
        Omdb GetOmdb(string id);
        IList<Omdb> GetOmdbInfo(int page, int pageSize);
        int NumberOfOmdbs();

        //directors interface
        IList<Directors> GetDirectors();
        Directors GetDirector(string id);
        IList<Directors> GetDirectorInfo(int page, int pageSize);
        int NumberOfDirectors();

        //languages interface
        IList<Languages> GetLanguages();
        Languages GetLanguage(string id);
        IList<Languages> GetLanguageInfo(int page, int pageSize);
        int NumberOfLanguages();
		
		//moviecompare interface
        /*IList<MovieCompare> GetCompares();
        MovieCompare GetCompare(string id);
        IList<MovieCompare> GetCompareInfo(int page, int pageSize);
        int NumberOfCompares();*/
    }
}