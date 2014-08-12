

$('#start').click(function() {

    var freightCount = getFreightValue();

    $('#grid').show();

    $("#grid").kendoGrid({
        dataSource: {
            type: "odata",
            transport: {
                read: "http://demos.telerik.com/kendo-ui/service/Northwind.svc/Orders"
            },
            schema: {
                model: {
                    fields: {
                        OrderID: { type: "number" },
                        Freight: { type: "number" },
                        ShipName: { type: "string" },
                        OrderDate: { type: "date" },
                        ShipCity: { type: "string" }
                    }
                }
            },
            pageSize: 20,
            serverPaging: true,
            serverFiltering: true,
            filter: { field: "Freight", operator: "gt", value: freightCount }
        },
        height: 550,
        filterable: true,
        sortable: true,
        pageable: true,
        columns: [{
            field: "OrderID",
            filterable: false
        },
            "Freight",
            {
                field: "OrderDate",
                title: "Order Date",
                format: "{0:MM/dd/yyyy}"
            }, {
                field: "ShipName",
                title: "Ship Name"
            }, {
                field: "ShipCity",
                title: "Ship City"
            }
        ]
    });
});

function getFreightValue() {

    console.log('getFreightValue');

    var value = $('#freight').val();
    var returnValue = parseInt(value);

    if (!returnValue) {
        returnValue = 0;
    }

    return returnValue;
}

