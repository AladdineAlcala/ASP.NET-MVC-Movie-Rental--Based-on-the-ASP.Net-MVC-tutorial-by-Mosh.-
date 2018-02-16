$(document).ready(function () {
    
    var table;// = $("#mytable1").DataTable();

    var Movie_Name = false, Movie_ReleaseDate = false, NumberInStock = false;
    $('#btn_submit').prop("disabled", true);
    $("#mymodal").modal();

    
    $("#Movie_ReleaseDate").focusout(function () {
        Movie_ReleaseDate = false;
        //console.log("Movie_ReleaseDate");

        try {
            var tt = new Date($("#Movie_ReleaseDate").val());
            if (tt.getFullYear() > 1800) {
                Movie_ReleaseDate = true;        
            }
            BtnCHecker();
        } catch (e) {
        }

        if (Movie_ReleaseDate)
            $("#Movie_ReleaseDate").css('border', '2px solid green');
        else
            $("#Movie_ReleaseDate").css('border', '2px solid red');
    });

    $("#NumberInStock").focusout(function () {
        NumberInStock = false;
        try {
            try {
                if (($('#NumberInStock').val()).indexOf("."))
                    $('#NumberInStock').val(($('#NumberInStock').val()).substring(0, ($('#NumberInStock').val()).indexOf(".")));
            } catch (e) {
            }

            var t = $('#NumberInStock').val();//$("#Movie_Name1").val().replace(/[^a-zA-Z0-9\s()]/g, ''));

           var i;
           try {
               i = parseInt(t);
           } catch (e) {
               i = 0;
           }

           if (Number.isInteger(i)) {
               ///console.log(NumberInStock);
               if (i > 0) {
                   //console.log("trueeeeeeeee");
                   NumberInStock = true;
               }
           }
          // console.log(NumberInStock);
        } catch (e) {
            alert("error");
        }
        if (NumberInStock)
            $("#NumberInStock").css('border', '2px solid green');
        BtnCHecker();
    });

    $("#Movie_Name").focusout(function () {
        try {
            while ($('#Movie_Name').val().charAt(0) == ' ') {
                $('#Movie_Name').val($('#Movie_Name').val().substring(1, $('#Movie_Name').val().length));
            }
        } catch (e) {}
        Movie_Name = false;

        try {
            $('#Movie_Name').val($('#Movie_Name').val().replace(/[^a-zA-Z0-9\s()]/g, ''));
            $('#Movie_Name').text(' ');
            $('#Movie_Name').html(' ');
            $("#Movie_Name").val('');
        } catch (e) {
            alert(e);
        }
            Movie_Name = true;
            if (Movie_Name)
                $('#Movie_Name').css('border', '2px solid green');
        BtnCHecker();
    });

    var t = 0;
    function BtnCHecker() {
        t++;
        console.log(t);
        $("#btn_submit").prop("disabled", true);
        if ((Movie_Name == true) && (NumberInStock == true))
            $("#btn_submit").prop("disabled", false);
    }

    $("#Mybtn").click(function () {
        
    });

    var validator = $("#MyForm").validate({
        submitHandler: function () {
            console.log("sdsdd");
            $.ajax({
                url: "/api/NewRentalss",
                method: "post",
                data: vm
            }).done(function () {
                toastr.success(vm.MovieIds.length + " New Rental of " + vm.CustomerName + " successfully Added");
                //toastr.options.fadeOut = 2500;
                $('#customer_input').typeahead("val", "");
                $('#Movie_select').typeahead("val", "");
                $('#movies_list').empty();
                $('#customer_input_error').text("");

                // test = test.replace(/[^a-zA-Z0-9\s()]/g, '');

                validator.resetForm();
            }).fail(function () {
                toastr.error("Error");
            });
            return false;
        }
    });

    //open modal
    $('#Mytst').click(function () {
        $("#MyForm")[0].reset();
        $("#Modal_title").html("Add New Movie");
        $("#mymodal").modal();
    });

    //input data from modal
    $("#Mybtn1").click(function () {
        var t = $("#Movie_GenreId option:selected").text();
        console.log(t);
        t++;
        console.log($("#Movie.ReleaseDate").val());
        table.rows.add([{
            "name": $("#Movie_Name").val(),
            "dateAdded": new Date().toISOString(),
            "releaseDate": $("#Movie.ReleaseDate").val(),
            "numberInStock": "11",
            "id": "5421",
            "genre": {
                "name": "Drama"
            }
        }]).draw();
        $("#mymodal").modal('hide');
    });

    var movies = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/Moviess?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#Movie_Name').typeahead({
        minLength: 1,
        highlight: true
    }, {
            name: 'movies',
            display: 'name',
            source: movies
        });

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
                    //{
                    //    data: function (row, type, set) {
                    //        if (type === 'genre.name') {
                    //            return row.genreId;
                    //        }
                    //    }
                    // },
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
