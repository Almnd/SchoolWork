require.config({
    baseUrl: "js",
    paths: {
        knockout: "lib/knockout/knockout-latest.debug",
        text: "lib/require-text/text.min",
        jquery: "lib/jquery/jquery.min",
        bootstrap: "lib/twitter-bootstrap/js/bootstrap.bundle.min",
        dataservice: "services/dataService"

        //frameworkDataservice: "services/frameworkDataservice"
        //movieDataservice: "services/movieDataservice"
        //postman: "services/postman"
    },

    shim: {
        bootstrap: ['jquery']
    }
});

require(['knockout', 'text'], (ko) => {

    ko.components.register('home', {
        viewModel: { require: "components/home/home" }, // homes viemmodel
        template: { require: "text!components/home/home.html" } //homes view

    });

    ko.components.register('user', {
        viewModel: { require: "components/user/user" },
        template: { require: "text!components/user/user.html" }

    });

    ko.components.register('browse-actors', {
        viewModel: { require: "components/actor/actorList"},
        template: { require: "text!components/actor/actorList.html" }

    });

    ko.components.register('browse-movies', {
        viewModel: { require: "components/movie/movieList" },
        template: { require: "text!components/movie/movieList.html" }

    });

    ko.components.register('movie-compare', {
        viewModel: { require: "components/compare/compare" },
        template: { require: "text!components/compare/compare.html" }

    });

    ko.components.register('searchbar', {
        viewModel: { require: "components/Search/searchbar" },
        template: { require: "text!components/Search/searchbar.html" }

    });

    ko.components.register('login', {
        viewModel: { require: "components/login/login" },
        template: { require: "text!components/login/login.html" }

    });

    ko.components.register('rating-history', {
        viewModel: { require: "components/rating/ratingList" },
        template: { require: "text!components/rating/ratingList.html" }

    });

});

require(['knockout', 'viewModel', 'bootstrap'], (ko, vm) => {
    ko.applyBindings(vm);
});