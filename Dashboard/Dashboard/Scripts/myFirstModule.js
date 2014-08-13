define(['jquery', 'kendoGridModule'], function ($, kendoGrid) {

// ReSharper disable InconsistentNaming

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
        });
    };

    var start = function() {
        _initGrid();
        _bindButton();
    };

    return {
        start: start
    };

    // ReSharper restore InconsistentNaming
});



