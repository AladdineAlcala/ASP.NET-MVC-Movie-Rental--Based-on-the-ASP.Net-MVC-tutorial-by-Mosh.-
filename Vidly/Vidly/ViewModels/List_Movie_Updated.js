$(document).ready(function () {
    //$("#mymodal").modal();
    console.log("Ready");
    
   
    
    var table;// = $("#mytable1").DataTable();

    var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"];

    $.ajax({
        url: "/api/Moviess",
        type: 'Get',
        dataType: 'json',
        success: function (data) {
            table = $("#mytable").DataTable({

                data: data,
                columns: [
                    {
                        data: "name",
                        "targets": 'no-sort',
                        render: function (data, type, row, meta) {
                            return "<a href='/Movies/Edit/" + row.id + "'>" + row.name + "</a>";
                        }
                    },
                    {
                        data: "releaseDate",
                        render: function (jsonDate) {
                            try {
                                var date = jsonDate.substring(0, 10);
                                var t = new Date(date);
                                return t.getDate() + "-" + monthNames[t.getMonth()] + "-" + t.getFullYear();
                            } catch (e) {
                                return 'error';
                            }

                        }
                    },
                    {
                        data: "dateAdded",
                        render: function (jsonDate) {
                            try {
                                var date = jsonDate.substring(0, 10);
                                return date;
                            } catch (e) {
                                return 'error';
                            }
                        }
                    },
                    {
                        data: "genre.name",
                    },
                    {
                        data: "numberInStock",
                    },
                    {
                        data: "id",
                        orderable: false,
                        render: function (data, type, row, meta) {
                            return "<button class='btn-link js-delete' title='" + row.name + "' delrow='" + row.id + "'> Delete</button >";
                        }
                    }
                ]
            });//data table closing
        },// succes function closing
        error: function (e) {
            alert('Error Loading Table');
        }
    }); //data table data insertion from API

    $("#mytable tbody").on('click', '.js-delete', function () {
        var button = $(this);

        bootbox.confirm("Are YOu Sure You want to delete this User '" + $(this).attr('title') + "' ?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/Moviess/" + button.attr('delrow'), //$(this).attr("data-user-id"),
                    method: "DELETE",
                    success: function () {
                        alert("Sucess");
                        button.closest('tr').addClass('selected');
                        table.row('.selected').remove().draw(false);
                    }
                });
            }
        });
    }); //delete from api

});
