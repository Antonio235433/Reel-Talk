# Reel-Talk

# Project Overview
The problem is sometimes people just don’t know what to watch, the average person spends around 23 minutes a day trying to find something to watch. Over a span of 80 years a person will have wasted 1.3 years of their life trying to something they like to watch. With this web application users will spend less time looking for something to watch because they can search for movies that are now playing, upcoming, popular, and by title. Users will also be able to do the same thing for TV shows. Users will be able to view details about movies and tv shows, details like the genre, rating, plot, etc. The website will also have a section where registered users can write reviews about a movie or tv show and they can search what other people think about certain movies or shows. I feel that sometimes its better to get an opinion about a movie or tv show from a regular person instead of a critic because the reviews are more genuine.

## Project Objectives
- Creating a web application that is easy to navigate.
- Finishing the project without going over budget.
- Creating a web application that can be used on any web browser with any device.
- Creating a web that is visually appealing.
- The project meets all business requirements.

# Project Scope

## In-Scope
- User shall be able to register to the website.
- User shall be able to log into the website.
- User shall be able to search for movies by title.
- User shall be able to search now playing movies in the theater.
- User shall be able to search upcoming movies in the theater.
- User shall be able to search movies by popularity.
- User shall be able to search for tv shows by title.
- Registered User shall be able to create a review on a movie or show.
- Registered User shall be able to search reviews on a movie or show by title.
- Registered User shall be able to view reviews on a movie or show.
- Registered User shall be able to view the reviews they created.
- Registered User shall be able to edit the reviews they created.
- Registered User shall be able to delete the reviews they created.
- Registered User shall be able to logout.
## Out-of-Scope
- User shall be able to create a watch list.
- User can view a recommended list of movies and tv shows based of their searches.
- User can share their favorite movies and tv shows on their social media.
- User shall be able to search for Actors and Actresses and get details about them.
- User shall be able to view trailers.
- User shall be able to comment on reviews.
- User shall be able to retrieve a random movie selection based of filters that include genre, score, etc.
- User shall be able to comment on a review.

# Technology Used
- Visual Studio
  - Microsoft Visual Studio is an integrated development environment (IDE) from Microsoft. Version 2017
 - Java Script
   - An object-oriented computer programming language commonly used to create interactive effects within web browsers. Version 6
 - Razor
   - Markup syntax for embedding server-based code into webpages. Version 6.0
 - C#
   - An object-oriented programming language from Microsoft. Version 6.0
 - Bootstrap
   - Open-source front-end framework for designing websites and web applications. Version 4
 - MVC architecture
   - Separates an application into three main components: the model, the view, and the controller.
 - Azure
    - A cloud computing service created by Microsoft for building, testing, deploying, and managing applications
 - REST API TMDB
   - Methods for movies, tv shows, and images. Version 3
 
# Code Snippets
## Public bool method to create a review
```C#
public class ReviewDAO
    {
        public bool CreateReview(Review review)
        {
            bool result = false;

            try
            {
                // Setup INSERT query with parameters
                string query = "INSERT INTO dbo.Review (TITLE, CONTENT, OWNER_ID) " +
                    "VALUES (@Title, @Content, @Owner_ID)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 215).Value = review.Title;
                    cmd.Parameters.Add("@Content", SqlDbType.Text).Value = review.Content;
                    cmd.Parameters.Add("@Owner_ID", SqlDbType.Int, 11).Value = review.Owner_ID;

                    // Open the connection, execute INSERT, and close the connection
                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                        result = true;
                    else
                        result = false;
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of create
            return result;
        }
       
```
## Public bool method to create a user
```C#
 public class UserDAO
    {
        public bool CreateUser(User user)
        {
            bool result = false;

            try
            {
                // Setup INSERT query with parameters
                string query = "INSERT INTO dbo.Account (USER_NAME, PASSWORD) " +
                    "VALUES (@UserName, @Password)";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 24).Value = user.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 14).Value = user.Password;



                    // Open the connection, execute INSERT, and close the connection
                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                        result = true;
                    else
                        result = false;
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of create
            return result;
        }
```
## Review Model class
```C#
 public class Review
    {
        // variables for review
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(215, ErrorMessage = "Maxium length for title is 215 Characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for title is 1 Character.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        [StringLength(1000, ErrorMessage = "Maxium length for content is 1000 Characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for content is 3 Characters.")]
        public string Content { get; set; }
        public int Owner_ID { get; set; }
        public int id { get; set; }
     
      
    }
```
## User Model Class
```C#
{
    public class User
    {
        // variables for user 
        [Required(ErrorMessage = "User name is required.")]
        [StringLength(24, ErrorMessage = "Maxium length for Username is 24 Characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for Username is 3 Characters.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(14, ErrorMessage = "Maxium length for Password is 14 Characters.")]
        [MinLength(8, ErrorMessage = "Minimum length for Password is 8 Characters.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public int UserID { get; set; }
    
}
```
## Naviagtion Bar
```C#
<div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Reel-Talk", "Home", "Home", new { area = "" }, new { @class = "navbar-brand" })
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Movies", "SearchMovie", "Movie")</li>
                    <li>@Html.ActionLink("TV Shows", "SearchTV", "TV")</li>

                    @if (Session["user"] != null)
                    {
                        <li>@Html.ActionLink("Reviews", "Review", "Review")</li>
                    }
                 
         
                </ul>
                <ul class="nav navbar-nav navbar-right">

                    @if (Session["user"] != null)
                    {
                        <li>@Html.ActionLink("Logout", "Logout", "User")</li>
                    }
                    else
                    {
                        <li>@Html.ActionLink("Register", "Register", "User")</li>
                        <li>@Html.ActionLink("Log In", "Login", "User")</li>

                    }
                </ul>
     

            </div>
        </div>
    </div>
```
## Javascript Get Movie Function
```Javascript
function getMovie() {
    // create variable to get id from seassion storage
    let movieId = sessionStorage.getItem('movieId');
    // Make a request for a user with a given ID usin axio
    axios.get("https://api.themoviedb.org/3/movie/" + movieId + "?api_key=1d52888fdde8705f2168b3f8dcf4b7b0")
        .then(function (response) {
            // create variable for data object
            let movie = response.data;

            // create output for movie using jQuery and list group
            let output = `
        <div class="row">
          <div class="col-md-4">
            <img src="https://image.tmdb.org/t/p/w500${movie.poster_path}" class="thumbnail">
          </div>
          <div class="col-md-8">
            <h2>${movie.title}</h2>
            <ul class="list-group">
              <li class="list-group-item"><strong>Genre:</strong> ${movie.genres[0].name}, ${movie.genres[1].name}</li>
              <li class="list-group-item"><strong>Released:</strong> ${movie.release_date}</li>
              <li class="list-group-item"><strong>Rated:</strong> ${movie.vote_average}</li>
              <li class="list-group-item"><strong>Runtime:</strong> ${movie.runtime} min.</li>
              <li class="list-group-item"><strong>Revenue:</strong> ${movie.revenue}</li>
              <li class="list-group-item"><strong>Production Companies:</strong> ${movie.production_companies[0].name}</li>
              <div class="row">
          <div class="well">
            <h3>Plot</h3>
            ${movie.overview}
            <hr>
          <div class="row">
          <div class="well">
          <h3>IMDB</h3>
          <a href="http://imdb.com/title/${movie.imdb_id}" target="_blank" class="btn btn-primary">View IMDB</a>
            </ul>
          </div>
        </div>
            <hr>
            <a href="SearchMovie" class="btn btn-default">Go Back To Search</a>
          </div>
        </div>
    `;
            $('#movie').html(output);
        })
        .catch(function (error) {
            console.log(error);
        });
}
```
## Javascript Get TV function
```Javascript
function getTV() {
    // create variable 
    let tvId = sessionStorage.getItem('tvId');
    // Make a request for a user with a given ID using axio
    axios.get("https://api.themoviedb.org/3/tv/" + tvId + "?api_key=1d52888fdde8705f2168b3f8dcf4b7b0")
        .then(function (response) {
            // create variable for data object
            let tv = response.data;
            let output = `
        <div class="row">
          <div class="col-md-4">
            <img src="https://image.tmdb.org/t/p/w500${tv.poster_path}" class="thumbnail">
          </div>
          <div class="col-md-8">
            <h2>${tv.name}</h2>
            <ul class="list-group">
            <li class="list-group-item"><strong>Genre:</strong> ${tv.genres[0].name}</li>
            <li class="list-group-item"><strong>Released:</strong> ${tv.first_air_date}</li>
            <li class="list-group-item"><strong>Seasons:</strong> ${tv.number_of_seasons}</li>
            <li class="list-group-item"><strong>Episodes:</strong> ${tv.number_of_episodes}</li>
            <li class="list-group-item"><strong>Last Episode :</strong> ${tv.last_air_date}</li>
            <li class="list-group-item"><strong>Runtime:</strong> ${tv.episode_run_time} Min</li>
            <li class="list-group-item"><strong>Network:</strong> ${tv.networks[0].name}</li>
            <li class="list-group-item"><strong>Production Companies:</strong> ${tv.production_companies[0].name}</li>
            <li class="list-group-item"><strong>Status:</strong> ${tv.status}</li>
            <li class="list-group-item"><strong>Popularity:</strong> ${tv.popularity}</li>
            
            <div class="row">
            <div class="well">
            <h3>Plot</h3>
             
            ${tv.overview}
          </div>
        </div>
        <hr>
         <a href="SearchTV" class="btn btn-default">Go Back To Search</a>
        </div>
        </div>
    `;
            $('#movie').html(output);
        })
        .catch(function (error) {
            console.log(error);
        });
}

```
