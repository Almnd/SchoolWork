using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib;
using DataServiceLib.Framework;
using DataServiceLib.Moviedata;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorController : ControllerBase
    {
        MovieIDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public ActorController(MovieIDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetActors))]
        public IActionResult GetActors(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var actors = _dataService.GetActorInfo(page, pageSize);

            var result = CreateResult(page, pageSize, actors);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetActor))]
        public IActionResult GetActor(string id)
        {
            var actors = _dataService.GetActor(id);
            if (actors == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ActorDto>(actors);
            dto.Url = Url.Link(nameof(GetActor), new { id });

            return Ok(dto);
        }

        private ActorDto CreateActorElementDto(Actors actors)
        {
            var dto = _mapper.Map<ActorDto>(actors);
            dto.Url = Url.Link(nameof(GetActor), new { id = actors.Nconst.Trim() }); //trim to fix id whitespace in urls

            return dto;
        }

        //Helpers

        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pageSize, int count)
        {
            string prev = null;

            if (page > 0)
            {
                prev = Url.Link(nameof(GetActors), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetActors), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetActors), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Actors> actors)
        {
            var items = actors.Select(CreateActorElementDto);

            var count = _dataService.NumberOfActors();

            var navigationUrls = CreatePagingNavigation(page, pageSize, count);


            var result = new
            {
                navigationUrls.prev,
                navigationUrls.cur,
                navigationUrls.next,
                count,
                items
            };

            return result;
        }

    }

    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        MovieIDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public MovieController(MovieIDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetMovies))]
        public IActionResult GetMovies(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var movies = _dataService.GetMovieInfo(page, pageSize);

            var result = CreateResult(page, pageSize, movies);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetMovie))]
        public IActionResult GetMovie(string id)
        {
            var movies = _dataService.GetMovie(id);
            if (movies == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<MovieDto>(movies);
            dto.Url = Url.Link(nameof(GetMovie), new { id });

            return Ok(dto);
        }

        private MovieDto CreateMovieElementDto(Movies movies)
        {
            var dto = _mapper.Map<MovieDto>(movies);
            dto.Url = Url.Link(nameof(GetMovie), new { id = movies.TitleId.Trim() }); //trim to fix id whitespace in urls

            return dto;
        }

        //Helpers

        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pageSize, int count)
        {
            string prev = null;

            if (page > 0)
            {
                prev = Url.Link(nameof(GetMovies), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetMovies), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetMovies), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Movies> movies)
        {
            var items = movies.Select(CreateMovieElementDto);

            var count = _dataService.NumberOfMovies();

            var navigationUrls = CreatePagingNavigation(page, pageSize, count);


            var result = new
            {
                navigationUrls.prev,
                navigationUrls.cur,
                navigationUrls.next,
                count,
                items
            };

            return result;
        }

    }

    [ApiController]
    [Route("api/genres")]
    public class GenreController : ControllerBase
    {
        MovieIDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public GenreController(MovieIDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetGenres))]
        public IActionResult GetGenres(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var genres = _dataService.GetGenreInfo(page, pageSize);

            var result = CreateResult(page, pageSize, genres);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetGenre))]
        public IActionResult GetGenre(string id)
        {
            var genres = _dataService.GetGenre(id);
            if (genres == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<GenreDto>(genres);
            dto.Url = Url.Link(nameof(GetGenre), new { id });

            return Ok(dto);
        }

        private GenreDto CreateGenreElementDto(Genres genres)
        {
            var dto = _mapper.Map<GenreDto>(genres);
            dto.Url = Url.Link(nameof(GetGenre), new { id = genres.TitleId.Trim() }); //trim to fix id whitespace in urls

            return dto;
        }

        //Helpers

        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pageSize, int count)
        {
            string prev = null;

            if (page > 0)
            {
                prev = Url.Link(nameof(GetGenres), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetGenres), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetGenres), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Genres> genres)
        {
            var items = genres.Select(CreateGenreElementDto);

            var count = _dataService.NumberOfGenres();

            var navigationUrls = CreatePagingNavigation(page, pageSize, count);


            var result = new
            {
                navigationUrls.prev,
                navigationUrls.cur,
                navigationUrls.next,
                count,
                items
            };

            return result;
        }

    }

    [ApiController]
    [Route("api/details")]
    public class DetailController : ControllerBase
    {
        MovieIDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public DetailController(MovieIDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetDetails))]
        public IActionResult GetDetails(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var details = _dataService.GetDetailInfo(page, pageSize);

            var result = CreateResult(page, pageSize, details);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetDetail))]
        public IActionResult GetDetail(string id)
        {
            var details = _dataService.GetDetail(id);
            if (details == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<DetailDto>(details);
            dto.Url = Url.Link(nameof(GetDetail), new { id });

            return Ok(dto);
        }

        private DetailDto CreateDetailElementDto(Details details)
        {
            var dto = _mapper.Map<DetailDto>(details);
            dto.Url = Url.Link(nameof(GetDetail), new { id = details.TitleId.Trim() }); //trim to fix id whitespace in urls

            return dto;
        }

        //Helpers

        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pageSize, int count)
        {
            string prev = null;

            if (page > 0)
            {
                prev = Url.Link(nameof(GetDetails), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetDetails), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetDetails), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Details> details)
        {
            var items = details.Select(CreateDetailElementDto);

            var count = _dataService.NumberOfDetails();

            var navigationUrls = CreatePagingNavigation(page, pageSize, count);


            var result = new
            {
                navigationUrls.prev,
                navigationUrls.cur,
                navigationUrls.next,
                count,
                items
            };

            return result;
        }

    }

    [ApiController]
    [Route("api/omdbs")]
    public class OmdbController : ControllerBase
    {
        MovieIDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public OmdbController(MovieIDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetOmdbs))]
        public IActionResult GetOmdbs(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var omdbs = _dataService.GetOmdbInfo(page, pageSize);

            var result = CreateResult(page, pageSize, omdbs);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetOmdb))]
        public IActionResult GetOmdb(string id)
        {
            var omdbs = _dataService.GetOmdb(id);
            if (omdbs == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<OmdbDto>(omdbs);
            dto.Url = Url.Link(nameof(GetOmdb), new { id });

            return Ok(dto);
        }

        private OmdbDto CreateOmdbElementDto(Omdb omdbs)
        {
            var dto = _mapper.Map<OmdbDto>(omdbs);
            dto.Url = Url.Link(nameof(GetOmdb), new { id = omdbs.Tconst.Trim() }); //trim to fix id whitespace in urls

            return dto;
        }

        //Helpers

        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pageSize, int count)
        {
            string prev = null;

            if (page > 0)
            {
                prev = Url.Link(nameof(GetOmdbs), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetOmdbs), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetOmdbs), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Omdb> omdbs)
        {
            var items = omdbs.Select(CreateOmdbElementDto);

            var count = _dataService.NumberOfOmdbs();

            var navigationUrls = CreatePagingNavigation(page, pageSize, count);


            var result = new
            {
                navigationUrls.prev,
                navigationUrls.cur,
                navigationUrls.next,
                count,
                items
            };

            return result;
        }

    }

    [ApiController]
    [Route("api/languages")]
    public class LanguageController : ControllerBase
    {
        MovieIDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public LanguageController(MovieIDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetLanguages))]
        public IActionResult GetLanguages(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var languages = _dataService.GetLanguageInfo(page, pageSize);

            var result = CreateResult(page, pageSize, languages);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetLanguage))]
        public IActionResult GetLanguage(string id)
        {
            var languages = _dataService.GetLanguage(id);
            if (languages == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<LanguageDto>(languages);
            dto.Url = Url.Link(nameof(GetLanguage), new { id });

            return Ok(dto);
        }

        private LanguageDto CreateLanguageElementDto(Languages languages)
        {
            var dto = _mapper.Map<LanguageDto>(languages);
            dto.Url = Url.Link(nameof(GetLanguage), new { id = languages.TitleId.Trim() }); //trim to fix id whitespace in urls

            return dto;
        }

        //Helpers

        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pageSize, int count)
        {
            string prev = null;

            if (page > 0)
            {
                prev = Url.Link(nameof(GetLanguages), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetLanguages), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetLanguages), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Languages> languages)
        {
            var items = languages.Select(CreateLanguageElementDto);

            var count = _dataService.NumberOfLanguages();

            var navigationUrls = CreatePagingNavigation(page, pageSize, count);


            var result = new
            {
                navigationUrls.prev,
                navigationUrls.cur,
                navigationUrls.next,
                count,
                items
            };

            return result;
        }

    }

    [ApiController]
    [Route("api/directors")]
    public class DirectorController : ControllerBase
    {
        MovieIDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public DirectorController(MovieIDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetDirectors))]
        public IActionResult GetDirectors(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var directors = _dataService.GetDirectorInfo(page, pageSize);

            var result = CreateResult(page, pageSize, directors);

            return Ok(result);
        }


        [HttpGet("{id}", Name = nameof(GetDirector))]
        public IActionResult GetDirector(string id)
        {
            var directors = _dataService.GetDirector(id);
            if (directors == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<DirectorDto>(directors);
            dto.Url = Url.Link(nameof(GetDirector), new { id });

            return Ok(dto);
        }

        private DirectorDto CreateDirectorElementDto(Directors directors)
        {
            var dto = _mapper.Map<DirectorDto>(directors);
            dto.Url = Url.Link(nameof(GetDirector), new { id = directors.DirectorId.Trim() }); //trim to fix id whitespace in urls

            return dto;
        }

        //Helpers

        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pageSize, int count)
        {
            string prev = null;

            if (page > 0)
            {
                prev = Url.Link(nameof(GetDirectors), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetDirectors), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetDirectors), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Directors> directors)
        {
            var items = directors.Select(CreateDirectorElementDto);

            var count = _dataService.NumberOfDirectors();

            var navigationUrls = CreatePagingNavigation(page, pageSize, count);


            var result = new
            {
                navigationUrls.prev,
                navigationUrls.cur,
                navigationUrls.next,
                count,
                items
            };

            return result;
        }

    }


}
