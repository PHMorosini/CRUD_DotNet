$(document).ready(function () {
    $('#clientesTable').DataTable({
        "paging": true,
        "pageLength": 10
    });

    $('#Cpf').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });

    $('#DataNascimento').on('keydown', function (e) {
        e.preventDefault();
    });

    $('#btnAdicionarEvento').click(function () { 
        var idCliente = $('#clienteId').val();
        var idEvento = $('#eventoId').val();

        console.log("Cliente ID: ", idCliente);
        console.log("Evento ID: ", idEvento);
        $.ajax({
            url: '/Clientes/AdicionarEventoCliente',
            type: 'POST',
            data: {
                eventoId: idEvento,
                clienteId: idCliente
            },
            success: function (response) {
                if (response.success) {
                    alert(response.mensagem);
                    if (response.redirectUrl) {
                        window.location.href = response.redirectUrl;
                    }
                }
            },
            error: function () {
                alert("Falha na comunicação com o servidor.");
            }
        }); 
    }); 
    
});

function atualizarAtivo(eventoId, isAtivo) {
    fetch(`/Clientes/UpdateAtivo/${eventoId}`, {
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