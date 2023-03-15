var summitArray = [];
var submitAjax;

$(document).ready(function () {
    $(document).on('click', '.add-student-button', function () {
        var newStudentRow = $(".student-row").first().clone();

        var studentIdx = $(this).parent().find("#students-container .student-row").length;

        newStudentRow.find(".student-fullname").attr("name", "students[" + studentIdx + "].FullName");
        newStudentRow.find(".student-fullname").val("");

        newStudentRow.find(".student-dob").attr("name", "students[" + studentIdx + "].DateOfBirth");
        newStudentRow.find(".student-dob").val("");

        newStudentRow.appendTo($(this).parent().find("#students-container"));
    });

    $("#add-teacher-button").click(function () {
        var newTeacherForm = $(".form-template").first().clone();
        newTeacherForm.removeClass('form-template');
        newTeacherForm.attr('style', 'display: block');
        newTeacherForm.insertBefore("#actions");
    });

    $("#teacher-form").submit(function (event) {
        event.preventDefault();

        //resetMessage
        resetMessage();

        //check fill in all fields
        if (isHasEmptyInput()) {
            $('.error').text('Please fill in all fields!');
            $('.error').show();
            return false;
        }

        //check enter at least 2 teachers and 30 students
        var checkEnterConutMsg = checkEnterConut();
        if (checkEnterConutMsg) {
            $('.error').text(checkEnterConutMsg);
            $('.error').show();
            return false;
        }


        $('#teacher-form .form-detail').each(function (i) {
            var teacherData = $(this).find("#teacher-container :input").serialize();
            var studentData = $(this).find(".student-row :input").serialize();
            var formData = teacherData + "&" + studentData;

            submitAjax = $.ajax({
                type: "POST",
                url: "/Home/Index",
                data: formData,
                success: function (res) {
                    console.log(res.message);
                },
                error: function () {
                    alert("An error occurred while submitting the form.");
                }
            });

            summitArray.push(submitAjax);
        });

        $.when.apply($, summitArray).done(function () {
            $('.success').text('Update success!');
            $('.success').show();
            setTimeout(function () {
                window.location.reload(1);
            }, 3000)
        });


    });
});

//Function check enter at least 2 teachers and 30 students
function checkEnterConut() {
    if ($('#teacher-form .form-detail').length < 2) {
        return 'Please enter at least 2 teachers.';
    }
    if ($('#teacher-form .student-row').length < 3) {
        return 'Please enter at least 30 students.';
    }
}

//Function to hide all message
function resetMessage() {
    $(".message div").each(function (index) {
        $(this).hide();
    });
}


//Function check fill in all fields
function isHasEmptyInput() {
    $('#teacher-form').find('input').each(function () {
        if ($(this).val() == '') {
            return true;
        }
    });
    return false;
}