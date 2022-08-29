// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//const { error } = require("jquery")

//const { signalR } = require("../lib/microsoft/signalr/dist/browser/signalr")

// Write your JavaScript code.

$(() => {
    let connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build()

    connection.start();//({ transport: 'longPolling' });


    connection.on("updatedEmployeesList", function () {
        loadData()
    })

    loadData();

    function loadData() {
        var tr = ''

        $.ajax({
            url: '/Employees/GetEmployees',
            method: 'GET',
            datatype: 'json',
            //contentType: 'application/json', // content type to Json
            success: (result) => {
                $.each(result, (k, v) => {
                    tr = tr + `<tr> 
                        <td>${v.empid}</td>
                        <td>${v.empName}</td>
                        <td>${v.empCountry}</td>
                        </tr>`
                })

                $("#tableBody").html(tr)
            },
            error: (error) => {
                console.log(error)
            }
        })
    }

})