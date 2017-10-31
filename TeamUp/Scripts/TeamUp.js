(function ($) {
    $.fn.change = function (cb, e) {
        e = e || {
            subtree: true,
            childList: true,
            characterData: true
        };
        $(this).each(function () {
            function callback(changes) {
                cb.call(node, changes, this);
            }
            var node = this;
            (new MutationObserver(callback)).observe(node, e);
        });
    };
})(jQuery);

$(document).ready(function () {
    $('#darken').on('click', function (e) {
        if (e.target !== this)
            return;

        closeModal();
    });
});

var ModalSize = { SMALL: 1, LARGE: 2 };

function showModal(title, idModalToShow, size) {
    if (title)
        $('#modal hr').show();
    $('#modalTitle').text(title);
    $('#darken').fadeIn(200);
    $('#darken').css('display', 'inline-flex');
    $('#modal').fadeIn(200);

    if (idModalToShow)    
        $(idModalToShow).show();
    if (size == ModalSize.LARGE) {
        $("#modal").removeClass("col-md-4 col-md-offset-4");
        $("#modal").addClass("col-md-6 col-md-offset-3");
    }
}

function closeModal(idModalToClose) {
    $('#darken').fadeOut(100);
    $('#modal').fadeOut(100, function () {
        $('#retorno').text('');
        $('#modalTitle').text('');
        $('#modal hr').hide();
        if (idModalToClose)
            $(idModalToClose).hide();        
        $("#modal").removeClass("col-md-6 col-md-offset-3");
        $("#modal").addClass("col-md-4 col-md-offset-4"); // retorna ao normal se foi alterado
        $("#modalContent").children().each(function () {
            $(this).hide();
        });
    });
}

function sendAjax(destinationUrl, params) {
    $.data(document, 'success');
    $.ajaxSetup({ async: false });

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