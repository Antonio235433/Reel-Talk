$(document).ready(function () {
    // Create event
    $("#searchForm").on('submit', (e) => {
        e.preventDefault();
    // Create variable for search text value
        let searchText = $("#searchText").val();
    // call getMovies function and pass the searchtext value in function
        getMovies(searchText);
    });
    // click event for now playing function
    $("#NowPlaying").click(function () {
    //call function
        NowPlaying();
    });
    // click event for upcoming function
    $("#Upcoming").click(function () {
    // call function
        Upcoming();
    });
    // click event for popular function
    $("#Popular").click(function () {
    // call function
        Popular();
    });
}); 

function getMovies(searchText) {
    //make GET request to TMDb api using axios
    //axios is a javaScript library http client
    axios.get("https://api.themoviedb.org/3/search/movie?api_key=1d52888fdde8705f2168b3f8dcf4b7b0&language=en-US&query=" + searchText)
        .then(function (response) {
            // set variable for object array in data
            let movies = response.data.results;
            // loop through array and add it to output variable
            // use jQuery to display movie image and title
            let output = '';
            $.each(movies, (index, movie) => {
                output += `
          <div class="col-md-3">
            <div class="well text-center">
              <img src="https://image.tmdb.org/t/p/w500${movie.poster_path}">
              <h5>${movie.title}</h5>
              <a onclick="movieSelected('${movie.id}')" class="btn btn-success" href="#">Movie Details</a>
            </div>
          </div>
        `;
            });
            $('#movies').html(output);
        })
        // catch error if function doesnt work
        .catch(function (error) {
        });
}

// create function to store id in a local session storage
function movieSelected(id) {
    sessionStorage.setItem('movieId', id);
    window.location = 'GetMovie/'+ id;
    return false;
}

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
          </div>
        </div>
    `;
            $('#movie').html(output);
        })
        .catch(function (error) {
            console.log(error);
        });
}

function NowPlaying() {
    //make GET request to TMDb api using axios
    //axios is a javaScript library http client
    axios.get("https://api.themoviedb.org/3/movie/now_playing?api_key=1d52888fdde8705f2168b3f8dcf4b7b0&region=US&language=en-US&page=1")
        .then(function (response) {
            // set variable for object array in data
            let movies = response.data.results;
            // loop through array and add it to output variable
            // use jQuery to display movie image and title
            let output = '';
            $.each(movies, (index, movie) => {
                output += `
          <div class="col-md-3">
            <div class="well text-center">
              <img src="https://image.tmdb.org/t/p/w500${movie.poster_path}">
              <h5>${movie.title}</h5>
              <a onclick="movieSelected('${movie.id}')" class="btn btn-success" href="#">Movie Details</a>
            </div>
          </div>
        `;
            });
            $('#movies').html(output);
        })
        // catch error if function doesnt work
        .catch(function (error) {
        });
}

function Upcoming() {
    //make GET request to TMDb api using axios
    //axios is a javaScript library http client
    axios.get("https://api.themoviedb.org/3/movie/upcoming?api_key=1d52888fdde8705f2168b3f8dcf4b7b0&region=US&language=en-US&page=1")
        .then(function (response) {
            // set variable for object array in data
            let movies = response.data.results;
            // loop through array and add it to output variable
            // use jQuery to display movie image and title
            let output = '';
            $.each(movies, (index, movie) => {
                output += `
          <div class="col-md-3">
            <div class="well text-center">
              <img src="https://image.tmdb.org/t/p/w500${movie.poster_path}">
              <h5>${movie.title}</h5>
              <a onclick="movieSelected('${movie.id}')" class="btn btn-success" href="#">Movie Details</a>
            </div>
          </div>
        `;
            });
            $('#movies').html(output);
        })
        // catch error if function doesnt work
        .catch(function (error) {
        });
}

function Popular() {
    //make GET request to TMDb api using axios
    //axios is a javaScript library http client
    axios.get("https://api.themoviedb.org/3/movie/popular?api_key=1d52888fdde8705f2168b3f8dcf4b7b0&region=US&language=en-US&page=1")
        .then(function (response) {
            // set variable for object array in data
            let movies = response.data.results;
            // loop through array and add it to output variable
            // use jQuery to display movie image and title
            let output = '';
            $.each(movies, (index, movie) => {
                output += `
          <div class="col-md-3">
            <div class="well text-center">
              <img src="https://image.tmdb.org/t/p/w500${movie.poster_path}">
              <h5>${movie.title}</h5>
              <a onclick="movieSelected('${movie.id}')" class="btn btn-success" href="#">Movie Details</a>
            </div>
          </div>
        `;
            });
            $('#movies').html(output);
        })
        // catch error if function doesnt work
        .catch(function (error) {
        });
}