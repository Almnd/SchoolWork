// this is like the viewmodel for the index page. each component have their own viewmodels

define(['knockout', 'postman'], (ko, postman) => {

    let menuElements = [
        { name: "Home", component: "home" },
        { name: "User", component: "user" },
        { name: "Actors", component: "browse-actors" },
        { name: "Movies", component: "browse-movies" },       
        { name: "Compare", component: "movie-compare" },
        { name: "Login", component: "login" }
    ];

    let currentComponent = ko.observable(menuElements[0].component);
    let changeContent = element => {

        currentComponent(element.component);
    }

    let gotoHome = () => {
        
        currentComponent(menuElements[0].component);
    }

    let isActive = element => {
        return element.component === currentComponent() ? "active" : "";
    }

    postman.subscribe("changeContent", component => {
        changeContent(component);
    });

    return {
        currentComponent,
        menuElements,
        changeContent,
        isActive,
        gotoHome
    };

});