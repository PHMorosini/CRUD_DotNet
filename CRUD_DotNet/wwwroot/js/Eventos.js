$(document).ready(function() {
    $('#eventosTable').DataTable({
        "paging": true,
        "pageLength": 10
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