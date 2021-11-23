﻿var department = {};
var apiUrl = "https://localhost:5001/api/Department";
department.showData = function () {
    $.ajax({
        url: apiUrl,
        method: "GET",
        datatype: "json",
        success: function (data) {
            $('#tbDepartment>tbody').empty();
            $.each(data, function (index, item) {
                $('#tbDepartment>tbody').append(
                    `
                        <tr>
                            <td>${item.departmentId}</td>
                            <td>${item.departmentName}</td>
                            <td>${item.departmentPhoneNumber}</td>
                            <td>${item.departmentLocation}</td>
                            <td>
                                <span class="badge ${item.departmentStatus ? 'bg-success' : 'bg-danger'}">
                                ${item.departmentStatus ? 'active' : 'inactive'}
                                </span>
                            </td>
                            <td class="text-right">
                                <div class="dropdown dropdown-action">
                                    <a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="material-icons">more_vert</i></a>
                                    <div class="dropdown-menu dropdown-menu-right">
                                        <a class="dropdown-item" href="#" data-toggle="modal" data-target="#edit_department"><i class="fa fa-pencil m-r-5"></i> Edit</a>
                                        <a class="dropdown-item" href="#" data-toggle="modal" data-target="#delete_department"><i class="fa fa-trash-o m-r-5"></i> Delete</a>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    `
                );
            });
            $.fn.dataTable.ext.errMode = 'none';
            $('#tbDepartment').DataTable();

        }
    });
}
    department.save = function () {
        let createDepObj = {
            departmentName: $('#departmentName').val(),
            departmentPhoneNumber: $('#departmentPhoneNumber').val(),
            departmentLocation: $('#departmentLocation').val(),
            departmentStatus: $('#departmentStatus').is(':checked')
        };
            $.ajax({
                url: apiUrl,
                method: "POST",
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(createDepObj),
                success: function (data) {
                    if (data.success) {
                        $('#add_department').modal('hide');
                        $.notify("Product has been created successfully!", "success");
                        department.showData();
                    }
                    else {
                        $.notify("Something went wrong, please try again!", "error");
                    }
                }
            });
    }

$(document).ready(function () {
    department.showData();
});