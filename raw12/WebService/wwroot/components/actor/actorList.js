define(['knockout', 'dataservice'], (ko, dataservice) => {
    return function(params) {
        let actors = ko.observableArray();
        let pageSizes = ko.observableArray();
        let selectedPageSize = ko.observableArray([10]);
        let prev = ko.observable();
        let next = ko.observable();

        let getData = url => {
            dataservice.getActors(url, data => {
                pageSizes(data.pageSizes);
                prev(data.prev || undefined);
                next(data.next || undefined);
                actors(data.items);
            });
        }

        let showPrev = actor => {
            console.log(prev());
            getData(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = actor => {
            console.log(next());
            getData(next());
        }

        let enableNext = ko.computed(() => next() !== undefined);

        selectedPageSize.subscribe(() => {
            var size = selectedPageSize()[0];
            getData(dataservice.getActorsUrlWithPageSize(size));
        });

        getData();

        return {
            pageSizes,
            selectedPageSize,
            actors,
            showPrev,
            enablePrev,
            showNext,
            enableNext
        };
    }
})