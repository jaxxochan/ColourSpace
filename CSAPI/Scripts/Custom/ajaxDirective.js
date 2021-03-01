function Get(action, controller, e) {
    $('.modal-backdrop').remove();
    showLoader();
    var url = ('/' + controller + '/' + action).toString();
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            $('#dashboard_partial_view').html('');
            $('#ContentSection').html(response);
        },
        error: function (response) {
            alert("error");
        }
    });
    e.preventDefault();
}

function GetById(action, controller, parameter, e) {
    showLoader();
    var url = ('/' + controller + '/' + action).toString();
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify({ id: parameter }),
        dataType: "html",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#ContentSection').html(response);
        },
        error: function (response) {
            alert("error");
        }
    });
    e.preventDefault();
}

function GetBySubModuleId(action, controller, parameter1, parameter2, e) {
    showLoader();
    var url = ('/' + controller + '/' + action).toString();
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify({ id: parameter1, subid: parameter2 }),
        dataType: "html",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#ContentSection').html(response);
        },
        error: function (response) {
            alert("error");
        }
    });
    e.preventDefault();
}

function Post(action, controller, parameter, e) {
    //showLoader();
    var url = ('/' + controller + '/' + action).toString();
    var formdata = new FormData($(parameter).get(0));
    $.ajax({
        type: "POST",
        url: url,
        data: formdata,
        processData: false,
        contentType: false,
        success: function (response) {
            $('#ContentSection').html(response);
        },
        error: function (response) {
            alert("error");
        }
    });
    e.preventDefault();
}

function PostAndValidate(action, controller, parameter, e) {
    var url = ('/' + controller + '/' + action).toString();
    var formdata = new FormData($(parameter).get(0));
    $.ajax({
        type: "POST",
        url: url,
        data: formdata,
        processData: false,
        contentType: false,
        success: function (response) {
            $(".errormsg").html("");
            var alertHtml = "";
            if (response.Success == false) {
                $.each(response.Errors, function (key, value) {
                    if (value != null) {
                        key = key.replace('.', '');
                        $("#Err_" + key).html(value[value.length - 1].ErrorMessage);
                    }
                });
                alertHtml = "<div class='alert alert-error'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button> <strong>Error! </strong> " + response.Message + "</div>";
            }
            else {
                alertHtml = "<div class='alert alert-success'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button> <strong>Success! </strong> " + response.Message + "</div>";
            }
            $(".alertBox").html(alertHtml);
            $(".alertBox").fadeIn(300).delay(1500).fadeOut(400);
        },
        error: function (response) {
            alert("error");
        }
    });
    e.preventDefault();
}

function PostWithIdAndValidate(id, action, controller, parameter, e) {
    debugger;
    var url = ('/' + controller + '/' + action).toString();
    var formdata = new FormData($(parameter).get(0));
    formdata.append('id', id);
    $.ajax({
        type: "POST",
        url: url,
        data: formdata,
        processData: false,
        contentType: false,
        success: function (response) {
            $(".errormsg").html("");
            var alertHtml = "";
            if (response.Success == false) {
                $.each(response.Errors, function (key, value) {
                    if (value != null) {
                        key = key.replace('.', '');
                        $("#Err_" + key).html(value[value.length - 1].ErrorMessage);
                    }
                });
                alertHtml = "<div class='alert alert-error'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button> <strong>Error! </strong> " + response.Message + "</div>";
            }
            else {
                alertHtml = "<div class='alert alert-success'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button> <strong>Success! </strong> " + response.Message + "</div>";
            }
            $(".alertBox").html(alertHtml);
            $(".alertBox").fadeIn(300).delay(1500).fadeOut(400);
        },
        error: function (response) {
            alert("error");
        }
    });
    e.preventDefault();
}

function PostAndValidateAnnotation(action, controller, parameter, e) {
    var url = ('/' + controller + '/' + action).toString();
    var formdata = new FormData($(parameter).get(0));
    $.validator.unobtrusive.parse($(parameter));
    if ($(parameter).valid()) {
        $.ajax({
            type: "POST",
            url: url,
            data: formdata,
            processData: false,
            contentType: false,
            success: function (response) {
                $(".errormsg").html("");
                // $('#ContentSection').html(response);
                var alertHtml = "";
                if (response.Success == false) {
                    alertHtml = "<div class='alert alert-error'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button> <strong>Error! </strong> " + response.Message + "</div>";
                }
                else {
                    alertHtml = "<div class='alert alert-success'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button> <strong>Success! </strong> " + response.Message + "</div>";
                }
                $(".alertBox").html(alertHtml);
                $(".alertBox").fadeIn(300).delay(1500).fadeOut(400);
            },
            error: function (response) {
                alert("error");
            }
        });
        e.preventDefault();
    }
    else {
        alert("Fill appropriate data");
    }
}

function Delete(action, controller, parameter, e) {
    showLoader();
    var url = ('/' + controller + '/' + action).toString();
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify({ id: parameter }),
        dataType: "html",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $('#ContentSection').html(response);
        },
        error: function (response) {
            alert("error");
        }
    });
    e.preventDefault();
}

function DownloadFile(action, controller, parameter, e) {
    var url = ('/' + controller + '/' + action).toString();
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify({ id: parameter }),
        dataType: "text",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
          //  window.location = "http://localhost:56571/Report/DownloadAttachment?fileName=" + response;
           window.location = "http://131.153.129.63/Report/DownloadAttachment?fileName=" + response;
        },
        error: function (errorThrown) {
       
            alert("Error while downloading file from server");
        }
    });
    e.preventDefault();
}


function DownloadDocument(parameter, e) {
    if (parameter != "") {
      // window.location = "http://localhost:56571/Common/DownloadDocument" + "?filePath=" + parameter;
       window.location = "http://131.153.129.63/Common/DownloadDocument" + "?filePath=" + parameter;
    }
}

function DownloadScheduledKMFile() {
    window.location = "http://localhost:56565/Report/DownloadScheduledKM?fileName=ScheduledKM.xlsx";
    //var url = ('/' + controller + '/' + action).toString();
    //$.ajax({
    //    type: "POST",
    //    url: url,
    //    data: JSON.stringify({ id: parameter }),
    //    dataType: "text",
    //    contentType: "application/json; charset=utf-8",
    //    success: function (response) {
    //        debugger;
    //        window.location = "http://localhost:56565/Report/DownloadScheduledKM?fileName=ScheduledKM.xlsx";
    //    },
    //    error: function (response) {
    //        alert("Error while downloading file from server");
    //    }
    //});
    //e.preventDefault();
}

function OnSelectFile(id) {
    document.getElementById(id).click();
}

function UploadFile(action, controller) {
    var url = ('/' + controller + '/' + action).toString();
    var formData = new FormData();
    var file = document.getElementById("FileUpload").files[0];
    formData.append("FileUpload", file);
    var alertHtml = "";
    $.ajax({
        type: "POST",
        url: url,
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.Success == false) {
                alertHtml = "<div class='alert alert-error'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button> <strong>Error! </strong> " + response.Message + "</div>";
            }
            else {
                if (response.Errors != null) {
                    alertHtml = "<div class='alert alert-warning'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button> <strong>Error! </strong> " + response.Message + "</div>";
                    //window.location = "http://localhost:56571/Report/DownloadAttachment?fileName=" + response.Errors.fileName;
                    window.location = "http://131.153.129.63/Report/DownloadAttachment?fileName=" + response.Errors.fileName;
                }
                else {
                    alertHtml = "<div class='alert alert-success'> <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button> <strong>Success! </strong> " + response.Message + "</div>";
                }
            }
            $(".alertBox").html(alertHtml);
        },
        error: function (response) {
            alert("error");
        }
    });
}

function RemoveFile(e, id) {
    document.getElementById(id).innerText = "";
}

function showFileName(event, labelId) {
    debugger;
    var infoArea = document.getElementById(labelId);
    var input = event.srcElement;
    var fileName = input.files[0].name;
    infoArea.textContent = fileName;
}

function RemoveProfilePicture() {
    document.getElementById('image').src = 'https://inlandfutures.org/wp-content/uploads/2019/12/thumbpreview-grey-avatar-designer.jpg';
}

function showLoader() {
    $('#ContentSection').html('<div class="loader"> <p>Loading...</p> <div class="loader-inner"></div> <div class="loader-inner"></div> <div class="loader-inner"></div> </div>');
}