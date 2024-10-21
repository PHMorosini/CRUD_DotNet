$(document).ready(function() {
    $('#valorIngresso').on('input', function () {
        let valor = $(this).val();
        // Remove caracteres que não sejam números ou vírgulas
        valor = valor.replace(/[^0-9,]/g, '');

        // Verifica se há mais de uma vírgula
        if ((valor.match(/,/g) || []).length > 1) {
            valor = valor.slice(0, -1);
            alert("Não é permitido inserir mais de uma vírgula.");
        }

        // Verifica se o valor tem mais de 8 números antes da vírgula
        const partes = valor.split(',');
        if (partes[0].length > 8) {
            partes[0] = partes[0].slice(0, 8); 
        }
        if (partes.length > 1 && partes[1].length > 2) {
            partes[1] = partes[1].slice(0, 2);
        }
        valor = partes.join(',');
        $(this).val(valor);
    });
});
function atualizarAtivo(eventoId, isAtivo) {
    fetch(`/Eventos/UpdateAtivo/${eventoId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ ativo: isAtivo })
    })
        .then(response => {
            if (!response.ok) {
                alert('Erro ao atualizar o estado.');
            }
        })
        .catch(error => {
            console.error('Erro:', error);
        });
}

