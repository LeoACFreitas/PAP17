function confirmaSenha(caller, alvo, aviso) {
    if ($(caller).val() != $('#' + alvo).val()) {
        $('#' + aviso).text('As senhas devem coincidir.');
    }
    else {
        $('#' + aviso).text('');
    }
}