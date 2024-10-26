function removerClienteEvento(clienteId, eventoId) {
    console.log("Cliente ID: ", clienteId);
    console.log("Evento ID: ", eventoId);

    $.ajax({
        url: '/Eventos/RemoverClienteEvento',
        type: 'POST',
        data: {
            eventoId: eventoId,
            clienteId: clienteId
        },
        success: function (response) {
            if (response.success) {
                alert(response.mensagem);
                if (response.redirectUrl) {
                    window.location.href = response.redirectUrl;
                }
                else {
                    console.error("Erro ao remover cliente do evento:", response.errorDetail || "Detalhes não disponíveis.");
                    alert("Erro: " + (response.errorDetail ? "\nDetalhes: " + response.errorDetail : ""));
                }
            }
        },
        error: function () {
            alert("Falha na comunicação com o servidor.");
        }
    });
}



$(document).ready(function () {
    $('#eventosTable').DataTable({
        "paging": true,
        "pageLength": 10
    });
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
    $('#ValorMeioIngresso').on('input', function () {
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
    $('#ValorTerceiraIdade').on('input', function () {
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

    $('#btnAdicionarCliente').click(function () {
        var idCliente = $('#clienteId').val();
        var idEvento = $('#eventoId').val();

        console.log("Cliente ID: ", idCliente);
        console.log("Evento ID: ", idEvento);

        $.ajax({
            url: '/Eventos/AdicionarClienteEvento',
            type: 'POST',
            data: {
                eventoId: idEvento,
                clienteId: idCliente
            },
            success: function (response) {
                if (response.success) {
                    alert(response.mensagem);
                        window.location.href = response.redirectUrl;
                }

            },
            error: function () {
                alert("Falha na comunicação com o servidor.");
            }
        });
    });
    $('#QuantidadeMaxParticipantantes').on('input', function () {
        let valor = $(this).val();
        valor = valor.replace(/[^0-9]/g, '');
        $(this).val(valor);
    });
    $('#btnRemoverCliente').click(function () {
        removerClienteEvento(); // A função já está disponível globalmente
    });
});

function atualizarAtivo(eventoId, isAtivo) {
    fetch(`/Eventos/UpdateAtivo/${eventoId}`,
        {
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