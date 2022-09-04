define([], () => {

    //framework resources
    const userApiUrl = "api/users";
    const searchApiUrl = "api/searches";
    const ratingApiUrl = "api/ratings";
    const abooksApiUrl = "api/actorbookings";
    const tbooksApiUrl = "api/titlebookings";

    //moviedata resources
    const movieApiUrl = "api/movies";
    const actorApiUrl = "api/actors";
    const genreApiUrl = "api/genres";
    const detailApiUrl = "api/details";
    const omdbApiUrl = "api/omdbs";
    const languageApiUrl = "api/languages";
    const directorApiUrl = "api/directors";

    //private
    let getJson = (url, callback) => {
        fetch(url).then(response => response.json()).then(callback);
    };

    //framework dataservice
    //browse ratings
    let getRatings = (url, callback) => {
        if (url === undefined) {
            url = ratingApiUrl;
        }
        getJson(url, callback);
    };

    let getRatingsUrlWithPageSize = size => ratingApiUrl + "?pageSize=" + size;

    // example method for a POST (create) in frontend dataservice
/*    let createRatings = function(rating, callback) {

        let headers = new Headers();
        headers.append("Content-Type", "application/json");
        fetch("api/ratings", { method: "POST", body: JSON.stringify(ratings), headers })
            .then(response => response.json())
            .then(data => callback(data));
    };*/

    // example on create method being used
    /*createRatings({Name: "ffsf", Description: "sfsfsf"},
        function(data) {
        //console.log(data);
    });*/

    //moviedata dataservice
    //browse actors
    let getActors = (url, callback) => {
        if (url === undefined) {
            url = actorApiUrl;
        }
        getJson(url, callback);
    };
    let getActorsUrlWithPageSize = size => actorApiUrl + "?pageSize=" + size;

    //browse movies
    let getMovies = (url, callback) => {
        if (url === undefined) {
            url = movieApiUrl;
        }
        getJson(url, callback);
    };
    let getMoviesUrlWithPageSize = size => movieApiUrl + "?pageSize=" + size;

    //moviecompare
    let getMoviesCompare = (url, callback) => {
        if (url === undefined) {
            url = movieApiUrl;
        }
        getJson(url, callback);
    };

    let getGenres = (url, callback) => {
        if (url === undefined) {
            url = genreApiUrl;
        }
        getJson(url, callback);
    };

    let getDetails = (url, callback) => {
        if (url === undefined) {
            url = detailApiUrl;
        }
        getJson(url, callback);
    };

    let getOmdbs = (url, callback) => {
        if (url === undefined) {
            url = omdbApiUrl;
        }
        getJson(url, callback);
    };

    let getLanguages = (url, callback) => {
        if (url === undefined) {
            url = languageApiUrl;
        }
        getJson(url, callback);
    };

    let getDirectors = (url, callback) => {
        if (url === undefined) {
            url = directorApiUrl;
        }
        getJson(url, callback);
    };

    let getMoviesCompareUrlWithPageSize = size => movieApiUrl + "?pageSize=" + size;

    // public
    return {
        getMoviesCompare,
        getMovieCompare: getJson,
        getActors,
        getActor: getJson,
        getGenres,
        getGenre: getJson,
        getDetails,
        getDetail: getJson,
        getOmdbs,
        getOmdb: getJson,
        getLanguages,
        getLanguage: getJson,
        getDirectors,
        getDirector: getJson,
        getMoviesCompareUrlWithPageSize,
        getMovies,
        getMovie: getJson,
        getMoviesUrlWithPageSize,
        getRatings,
        getRating: getJson,
        getRatingsUrlWithPageSize
    };
});