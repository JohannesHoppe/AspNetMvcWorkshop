define(['jquery', 'kendoGridModule'], function ($, kendoGrid) {

    var events = $({});

    var _grid;

    var _initGrid = function() {
        _grid = kendoGrid.init($("#grid"));
    };

    var _getSearch = function() {
        return $('#search').val();
    };

    var _bindButton = function() {
        $('#filterButton').click(function() {
            var dataSource = _grid.dataSource;

            var search = _getSearch().toLowerCase();
            dataSource.filter({
                logic: "or",
                filters: [
                    { field: "tolower(Vorname)", operator: "contains", value: search },
                    { field: "tolower(Nachname)", operator: "contains", value: search },
                    { field: "tolower(EMail)", operator: "contains", value: search }
                ]
            });

            events.trigger('userPressedTheButton', 'message!');
        });


    };

    var start = function() {
        _initGrid();
        _bindButton();
    };

    return {
        start: start,
        events: events
    };

    // ReSharper restore InconsistentNaming
});



