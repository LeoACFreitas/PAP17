$(document).ready(function () {
    $('#darken').on('click', function (e) {
        if (e.target !== this)
            return;

        closeModal();
    });
});

function showModal(title) {
    if (title) {
        $('#modal hr').show();
    }
    $('#modalTitle').text(title);
    $('#darken').fadeIn(200);
    $('#darken').css('display', 'inline-flex');
    $('#modal').fadeIn(200);
}

function closeModal() {
    $('#darken').fadeOut(100);
    $('#modal').fadeOut(100, function () {
        $('#retorno').text('');
        $('#modalTitle').text('');
        $('#modal hr').hide();
    });
}

function sendAjax(destinationUrl, params) {
    $.data(document, 'success');
    $.ajaxSetup({async: false});

    $.get(destinationUrl, params,
        function (data) {
            $('#retorno').css('color', 'green');
            $('#retorno').text(data.responseText);
            $.data(document, 'success', true);
        },
    ).fail(function (data) {
        $('#retorno').css('color', 'red');
        $('#retorno').text(data.responseText);
        $.data(document, 'success', false);
    });

    $.ajaxSetup({ async: true });
    return $.data(document, 'success');
}

function confirmaSenha(caller, alvo, aviso) {
    if ($(caller).val() !== $('#' + alvo).val()) {
        $('#' + aviso).text('As senhas devem coincidir.');
    }
    else {
        $('#' + aviso).text('');
    }
}