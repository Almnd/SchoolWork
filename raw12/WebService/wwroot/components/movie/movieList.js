define(['knockout', 'dataservice'], (ko, dataservice) => {
    return function(params) {
        let movies = ko.observableArray();
        let pageSizes = ko.observableArray();
        let selectedPageSize = ko.observableArray([10]);
        let prev = ko.observable();
        let next = ko.observable();

        let getData = url => {
            dataservice.getMovies(url, data => {
                pageSizes(data.pageSizes);
                prev(data.prev || undefined);
                next(data.next || undefined);
                movies(data.items);
            });
        }

        let showPrev = movie => {
            console.log(prev());
            getData(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = movie => {
            console.log(next());
            getData(next());
        }

        let enableNext = ko.computed(() => next() !== undefined);

        selectedPageSize.subscribe(() => {
            var size = selectedPageSize()[0];
            getData(dataservice.getMoviesUrlWithPageSize(size));
        });

        getData();

        return {
            pageSizes,
            selectedPageSize,
            movies,
            showPrev,
            enablePrev,
            showNext,
            enableNext
        };

    }
})