define(['knockout', 'dataservice'], (ko, dataservice) => {
    return function(params) {
        let ratings = ko.observableArray();
        let pageSizes = ko.observableArray();
        let selectedPageSize = ko.observableArray([10]);
        let prev = ko.observable();
        let next = ko.observable();

        let getData = url => {
            dataservice.getRatings(url, data => {
                pageSizes(data.pageSizes);
                prev(data.prev || undefined);
                next(data.next || undefined);
                ratings(data.items);
            });
        }

        let showPrev = rating => {
            console.log(prev());
            getData(prev());
        }

        let enablePrev = ko.computed(() => prev() !== undefined);

        let showNext = rating => {
            console.log(next());
            getData(next());
        }

        let enableNext = ko.computed(() => next() !== undefined);

        selectedPageSize.subscribe(() => {
            var size = selectedPageSize()[0];
            getData(dataservice.getRatingsUrlWithPageSize(size));
        });

        getData();

        return {
            pageSizes,
            selectedPageSize,
            ratings,
            showPrev,
            enablePrev,
            showNext,
            enableNext
        };

    }
})