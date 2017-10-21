function SetAjaxContent(div, url)
{
    $.ajax({
        url: url,
        //method: "POST",
        //data: { id: menuId },
        success: function (data) {
            $('#' + div).html(data);
        }
    });
}

