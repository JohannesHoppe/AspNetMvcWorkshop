define(['jquery', 'kendo'], function ($) {

    var _grid;

    var _initGrid = function() {

        _grid = $("#grid").kendoGrid({
            dataSource: {
                type: "odata",
                transport: {
                    read: {
                        url: "/api/Gutachter",
                        dataType: "json"
                    }
                },
                schema: {
                    data: function (data) {
                        return data.value;
                    },
                    total: function (data) {
                        return data['odata.count'];

                    },
                    model: {
                        fields: {
                            Id: { type: "number" },
                            Vorname: { type: "string" },
                            Nachname: { type: "string" },
                            EMail: { type: "string" }
                        }
                    }
                },
                pageSize: 20,
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true
            },
            height: 550,
            filterable: true,
            sortable: true,
            pageable: true,
            columns: [
                {
                    field: "Id",
                    filterable: false
                }, {
                    field: "Vorname",
                    title: "Vorname",
                    filterable: false
                }, {
                    field: "Nachname",
                    title: "Nachname",
                    filterable: false
                }, {
                    field: "EMail",
                    title: "EMail",
                    filterable: false
                }
            ]
        }).data("kendoGrid");
    };

    var _getSearch = function() {
       return $('#search').val();
    }

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

    }

    var start = function() {
        _initGrid();
        _bindButton();
    }

    return {
        start: start
    };

});



