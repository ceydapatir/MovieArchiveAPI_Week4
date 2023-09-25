# MovieArchiveAPI_Week4
It is the final version of the assignments required for Week 4. Genre and Director entities have been added to the project along with their controllers. The API provides the user with HTTP request methods for the genre, director and movie information that should be in a movie archive.

---
## Installation
Clone this repo and run these commands in the project file directory:
```
dotnet build
dotnet run
```

---
## Requests
### MoviesController.cs
* GET   /api/Movies: This request throws an error if there is no movie in the database, otherwise it returns movies data.
* GET   /api/Movies/{id}: This request returns the movie data has the received id, and if there is no such movie, it throws an error.
* GET   /api/Movies/{name}: This request returns the movie data has the received name, and if there is no such movie, it throws an error.
* GET   /api/Movies/{year}: This request returns the movies data has the received year, and if there is no such movie, it throws an error.
* POST  /api/Movies: This request creates a new movie if there is no movie with the same name in the database, otherwise it throws an error.
* PUT   /api/Movies/{id}: This request updates the movie data, with the received id, and if there is no such movie, it throws an error.
* DELETE   /api/Movies/{id}: This request deletes the movie data, with the received id, and if there is no such movie, it throws an error.
  
### DirectorsController.cs
* GET   /api/Directors: This request throws an error if there is no director in the database, otherwise it returns directors data.
* GET   /api/Directors/{id}: This request returns the director data has the received id, and if there is no such director, it throws an error.
* GET   /api/Directors/fullname: This request returns the director data has the received name and surname ([FromQuery] GetDirectorByIdDTO fuulname), and if there is no such director, it throws an error.
* POST  /api/Directors: This request creates a new director if there is no director with the same id, otherwise it throws an error.
* PUT   /api/Directors/{id}: This request updates the director data, with the received id, and if there is no such director, it throws an error.
* DELETE   /api/Directors/{id}: This request deletes the director data, with the received id, and if there is no such director, it throws an error.
  
### GenresController.cs
* GET   /api/Genres: This request throws an error if there is no genre in the database, otherwise it returns genres data.
* GET   /api/Genres/{id}: This request returns the genre data has the received id in the database, and if there is no such genre, it throws an error.
* GET   /api/Genres/{name}: This request returns the genre data has the received name in the database, and if there is no such genre, it throws an error.
* POST  /api/Genres: This request creates a new genre if there is no genre with the same id, otherwise it throws an error.
* PUT   /api/Genres/{id}: This request updates the genre data, with the received id, and if there is no such genre, it throws an error.
* DELETE   /api/Genres/{id}: This request deletes the genre data, with the received id, and if there is no such genre, it throws an error.

---
## Mapping
The models were mapped to appropriate versions as follows.
```c#
public MapperProfile(){
            CreateMap<Movie, MovieViewModel>() // map to get
                .ForMember(i => i.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(i => i.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
                .ForMember(i => i.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyy")));
            CreateMap<MovieDTO, Movie>(); // map to create
            CreateMap<MovieDTO, Movie>().ReverseMap(); // map to update
            
            CreateMap<Genre, GenreViewModel>(); // map to get
            CreateMap<GenreDTO, Genre>(); // map to create
            CreateMap<GenreDTO, Genre>().ReverseMap(); // map to update
            
            CreateMap<Director, DirectorViewModel>() // map to get
                .ForMember(i => i.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd/MM/yyy")));
            CreateMap<DirectorDTO, Director>(); // map to create
            CreateMap<DirectorDTO, Director>().ReverseMap(); // map to update
        }
```

---
## Fluent Validation
Fluent Validation was applied for all entities. Especially when creating a movie, it was ensured that GenreId and DirectorId values were not entered with values that did not exist in the database.
Below is the Fluent Validation process performed for the POST request.
* Validation limits set in CreateMovieValidation.cs
```c#
public CreateMovieValidator(MovieArchiveDBContext context){
            RuleFor(i => i.Model.Name).NotNull();
            RuleFor(i => i.Model.DirectorId).NotEmpty().LessThan(context.Directors.Count()).GreaterThan(0);
            RuleFor(i => i.Model.GenreId).NotEmpty().LessThan(context.Genres.Count()).GreaterThan(0);
            RuleFor(i => i.Model.PublishDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date);
            RuleFor(i => i.Model.ImageURL).NotNull();
            RuleFor(i => i.Model.IMDB).NotEmpty().GreaterThan(0);
        }
```

* Validation performed in UsersController.cs
```c#
CreateMovieValidator validator = new CreateMovieValidator();
validator.ValidateAndThrow(command);
```

---
## Middleware
A basic middleware was created that provides HTTP request and response details. The necessary logging operations were carried out through an independent service.

---
## Models
* Movie
```
    {
        UserId        integer
        DirectorId    integer
        GenreId       integer
        Name          string
        PublishDate   string($date-time)
        IMDB          number($double)
        ImageURL      string

        Director      Director
        Genre         Genre
    }
```
* MovieDTO
```
    {
        DirectorId    integer
        GenreId       integer
        Name          string
        PublishDate   string($date-time)
        IMDB          number($double)
        ImageURL      string
    }
```
* MovieViewModel
```
    {
        UserId        integer
        Director      string
        Genre         string
        Name          string
        PublishDate   string
        IMDB          number($double)
        ImageURL      string
    }
```
* Director
```
    {
        DirectorId    integer
        Name          string
        Surname       string
        BirthDate     string($date-time)
    }
```
* DirectorDTO
```
    {
        Name          string
        Surname       string
        BirthDate     string($date-time)
    }
```
* GetDirectorByIdDTO
```
    {
        Name          string
        Surname       string
    }
```
* DirectorViewModel
```
    {
        DirectorId    integer
        Name          string
        Surname       string
        BirthDate     string
    }
```
* Genre
```
    {
        GenreId       integer
        Name          string
        IsActive      boolean
    }
```
* GenreDTO
```
    {
        Name          string
        IsActive      boolean
    }
```
* GenreViewModel
```
    {
        GenreId       integer
        Name          string
        IsActive      boolean
    }
```
