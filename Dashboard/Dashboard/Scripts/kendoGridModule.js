define(['kendo'], function() {

    var init = function($el) {

        return $el.kendoGrid({
            dataSource: {
                type: "odata",
                transport: {
                    read: {
                        url: "/api/Gutachter",
                        dataType: "json"
                    }
                },
                schema: {
                    data: function(data) {
                        return data.value;
                    },
                    total: function(data) {
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
                    title: "Vorname"
                    //filterable: false
                }, {
                    field: "Nachname",
                    title: "Nachname"
                    //filterable: false
                }, {
                    field: "EMail",
                    title: "EMail"
                    //filterable: false
                }
            ]
        }).data("kendoGrid");
    };

    return {
        init: init
    };
});