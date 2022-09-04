define(['knockout', 'dataservice'], (ko, dataservice) => {
    return function (params) {
        let compares = ko.observableArray();
        let directors = ko.observableArray();
        let pageSizes = ko.observableArray();
        let selectedPageSize = ko.observableArray([10]);
        let prev = ko.observable();
        let next = ko.observable();

        let getMovie = url => {
            dataservice.getMoviesCompare(url, data => {
                pageSizes(data.pageSizes);
                prev(data.prev || undefined);
                next(data.next || undefined);
                compares(data.items);
            });
        }

        let getDirectors = url => {
            dataservice.getDirectors(url, data => {
                pageSizes(data.pageSizes);
                prev(data.prev || undefined);
                next(data.next || undefined);
                directors(data.items);
            });
        }

        let showPrev = compare => {
            console.log(prev());
            getMovie(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = compare => {
            console.log(next());
            getMovie(next());
        }

        let enableNext = ko.computed(() => next() !== undefined);

        selectedPageSize.subscribe(() => {
            var size = selectedPageSize()[0];
            getMovie(dataservice.getMoviesCompareUrlWithPageSize(size));
        });

        getMovie();
        getDirectors();

        return {
            pageSizes,
            selectedPageSize,
            compares,
            directors,
            showPrev,
            enablePrev,
            showNext,
            enableNext
        };

    }
})