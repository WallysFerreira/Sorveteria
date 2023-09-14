$(document).ready(() => {
    var corpoTabela = $('#tabela tbody')
    corpoTabela.append('<tr><td>Teste</td><td>Teste</td><td>Teste</td></tr>')
})

function pegarProdutos() {
    var url = "localhost:8080/produtos"
    
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: url,
        success: function (data, status, xhr) {
            console.log(data)
        }
    })
}
