var data = [];

var defCol = [
    {
        dataField: "dateModified",
        caption: "Date Modified",
        alignment: "center",
        dataType: "date",
        format: "dd/MM/yyyy",
        width: 120,
        visible: false,
        allowHiding: true,
        showInColumnChooser: true,
        allowEditing: false,
    }, {
        dataField: "dateCreated",
        caption: "Date Created",
        alignment: "center",
        dataType: "date",
        format: "dd/MM/yyyy",
        width: 120,
        visible: false,
        allowHiding: true,
        showInColumnChooser: true,
        allowEditing: false,
    },
    {
        dataField: "createdBy",
        dataType: "string",
        caption: "Created By",
        alignment: "left",
        width: 120,
        visible: false,
        allowHiding: true,
        showInColumnChooser: true,
        allowEditing: false,
    },
    {
        dataField: "modifiedBy",
        dataType: "string",
        caption: "Modified By",
        alignment: "left",
        width: 120,
        visible: false,
        allowHiding: true,
        showInColumnChooser: true,
        allowEditing: false,
        showInColumnChooser: true,
    }];

columns = columns.concat(defCol);

var addBtn = $("#addBtn").dxButton({
    text: "Thêm",
    useIcon: true,
    type:"danger",
    icon: "dx-icon dx-icon-inserttable",
    onClick: function () {
        dataGrid.addRow();
    }
}).dxButton("instance");

var saveBtn = $("#saveBtn").dxButton({
    text: "Lưu",
    useIcon: true,
    type:"success",
    icon: "save",
    onClick: function () {
        dataGrid.saveEditData();
    }
}).dxButton("instance");

var refreshBtn = $("#refreshBtn").dxButton({
    text: "Nạp dữ liệu",
    useIcon: true,
    type:"default",
    icon: "refresh",
    onClick: function () {
        dataGrid.cancelEditData();
        dataGrid.clearFilter();
    }
}).dxButton("instance");

var store = new DevExpress.data.CustomStore({

    load: function (loadOptions) {
        var d = $.Deferred();
        $.ajax({
            url: "/" + table + "/GetList" + table,
            method: 'get',
            dataType: 'json',
            crossDomain: true,
            headers: {
                "Content-Type": 'application/json',
                "cache-control": "no-cache"
            },
        }).done(function (e) {
            d.resolve(e);
        }).fail(function (jqXhr, status, message) {
            d.reject();
            console.log(status + ": " + message);
        });
        return d.promise();
    }
})

var source = new DevExpress.data.DataSource({
    store: store
});

var dataGrid = $("#grid").dxDataGrid({
    dataSource: source,
    columnAutoWidth: true,
    showBorders: true,
    hoverStateEnabled: true,
    repaintChangesOnly: true,
    columnHidingEnabled: true,
    showRowLines: true,
    paging: {
        pageSize: 10
    },
    pager: {
        showPageSizeSelector: false,
        allowedPageSizes: [10, 25, 50, 100]
    },
    rowAlternationEnabled: true,
    editing: {
        useIcons: true,
        mode: 'batch',
        allowAdding: true,
        allowDeleting: true,
        allowUpdating: true,
    },
    columnFixing: {
        enabled: true
    },
    columnChooser: {
        enabled: true,
        mode: "select"
    },
    filterRow: {
        applyFilter: "auto",
        applyFilterText: "Apply filter",
        betweenEndText: "End",
        betweenStartText: "Start",
        operationDescriptions: {},
        resetOperationText: "Reset",
        showAllText: "",
        showOperationChooser: true,
        visible: true
    },
    onToolbarPreparing: function (e) {
        e.toolbarOptions.visible = false;
    },
    onContextMenuPreparing: function (e) {
        if (e.target == "header") {
            if (!e.items) e.items = [];
            e.items.push({
                text: "Hide",
                onItemClick: function () {
                    $("#grid").dxDataGrid("columnOption", e.column.name, "visible", false);
                }
            });
            e.items.push({
                text: "Unhide",
                onItemClick: function () {
                    dataGrid.showColumnChooser()
                }
            });
        }
    },
    remoteOperations: false,
    onSaving: function (e) {
        e.cancel = true;
        var changes = dataGrid.option("editing.changes");
        changes.forEach(function (item, index) {
            if (item.type === "insert")
                item.key = {};
        });
        if (changes.length > 0) {
            $.ajax({
                url: "/" + table + "/UpdateBatch" + table,
                method: "post",
                dataType: "json",
                headers: {
                    "Content-Type": "application/json",
                    "cache-control": "no-cache",
                },
                data: JSON.stringify(changes)
            }).done(function (rs) {
                if (rs.status == 1) {
                    e.component.refresh(true).done(function () {
                        e.component.cancelEditData();
                    });
                    DevExpress.ui.notify("Successful", "success", 2000);
                } else {
                    DevExpress.ui.notify("error: " + rs.message, "warning", 2000);
                }
            }).fail(function () {
                DevExpress.ui.notify("Update data failed", "warning", 2000);
            })
        } else {
            DevExpress.ui.notify("No data have been changed", "warning", 2000);
        }
        
    },
    headerFilter: {
        allowSearch: true,
        searchTimeout: 500,
        texts: {},
        visible: true,
    },
    columns: columns,

}).dxDataGrid("instance");