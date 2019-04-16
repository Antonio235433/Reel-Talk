$(document).ready(function () {
    // Create event
    $("#searchForm").on('submit', (e) => {
        e.preventDefault();
    // Create variable for search text value
        let searchText = $("#searchText").val();
    // call searchTv function and pass search text value in function
        searchTV(searchText);
    });

    // click event for popular function
    $("#Popular").click(function () {
    // call function
        Popular();
    });


});

function searchTV(searchText) {
    //make request to TMDb api using axios
    //axios is a javaScript library http client
    axios.get("https://api.themoviedb.org/3/search/tv?api_key=1d52888fdde8705f2168b3f8dcf4b7b0&language=en-US&query=" + searchText)
        // return promise
        .then(function (response) {
       // set variable for object array in data array
            let tv = response.data.results;
            // loop through array and add it to output variable
            // use jQuery to display movie image and title
            let output = '';
            $.each(tv, (index, tv) => {
                output += `
          <div class="col-md-3">
            <div class="well text-center">
              <img src="https://image.tmdb.org/t/p/w500${tv.poster_path}">
              <h5>${tv.name}</h5>
              <a onclick="tvSelected('${tv.id}')" class="btn btn-success" href="#">TV Show Details</a>
            </div>
          </div>
        `;
            });
            $('#movies').html(output);
        })
        // catch error if function doesnt work
        .catch(function (error) {
            console.log(error);
        });
}

// create function to store id in local session storage 
function tvSelected(id) {
    sessionStorage.setItem('tvId', id);
    window.location = 'GetTV/' + id;
    return false;
}

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
        </div>
        </div>
    `;
            $('#movie').html(output);
        })
        .catch(function (error) {
            console.log(error);
        });
}
