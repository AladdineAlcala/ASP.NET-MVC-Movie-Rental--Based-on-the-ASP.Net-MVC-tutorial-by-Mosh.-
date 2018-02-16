$(document).ready(function () {
    var table;// = $("#mytable").DataTable();

    var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"];


    $.ajax({
        url: "/api/Moviess",
        type: 'Get',
        dataType: 'json',
        success: function (data1) {
            console.log("here");

            table = $("#mytable").DataTable({
                data: data1,
                "columns": [
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


    var t = 0;
    $("#Mytst").click(function () {
        console.log(t);
        t++;
        table.rows.add([{
            "name": "aaaaaaaaaa",
             "dateAdded": "2018-01-09T16:34:46.58",
             "releaseDate":"2018-01-09T16:34:46.58",
             "numberInStock": "11",
             "id": "5421",
             "genre": {
                 "name": "Drama"
             }
        }]).draw();


        //$("#myform")[0].reset();
        //$("#ModalTitle").html("Add new Movie");
        //$("#mymodal").modal();
    });

});
