// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#CategoryId").on("change", function () {
        var categoryId = $(this).val();
        var areaList = $("#BookCategoryId");
        $.ajax({
            type: "Get",
            url: '/api/Library/getSubCategoryParentId/' + categoryId,
            success: function (SubCategories) {
                areaList.empty();
                $.each(SubCategories, function (i, subCategory) {
                    areaList.append($('<option></option>').attr('value', subCategory.id).text(subCategory.name));
                });
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
    });
});

