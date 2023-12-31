'use client'

export default function FormAtualizarProduto({ produto }) {
    const enviar = async (e) => {
        e.preventDefault()

        const formData = new FormData(document.getElementById('formAtualizar'))

        const categoria = formData.get('categoria').length != 0 ? formData.get('categoria') : produto.categoria
        const nome = formData.get('nome').length != 0 ? formData.get('nome') : produto.nome
        const preco = !isNaN(parseFloat(formData.get('preco'))) ? parseFloat(formData.get('preco')) : produto.preco
        const descricao = formData.get('descricao').length != 0 ? formData.get('descricao') : produto.descricao
        const foto = formData.get('foto').length != 0 ? formData.get('foto') : produto.foto

        const json = {
            'categoria': categoria,
            'nome': nome,
            'preco': preco,
            'descricao': descricao,
            'foto': foto
        }

        await fetch(`/api/produtos/${produto.id}`, {
            method: 'PUT',
            body: JSON.stringify(json),
        })
    }

    console.log(produto)

    return (
        <div className="h-screen w-screen flex justify-center items-center">
        <form onSubmit={enviar} className="flex flex-col justify-center items-center" id="formAtualizar">
            <div className="flex flex-col">
            <label htmlFor="categoria">Categoria</label>
            <input className="border" id="categoria" name="categoria" placeholder={produto.categoria}></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="nome">Nome</label>
            <input className="border" id="nome" name="nome" placeholder={produto.nome}></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="preco">Preço</label>
            <input className="border" id="preco" name="preco" placeholder={produto.preco}></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="descricao">Descrição</label>
            <input className="border" id="descricao" name="descricao" placeholder={produto.descricao}></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="foto">Foto</label>
            <input className="border" id="foto" name="foto" placeholder={produto.foto}></input>
            </div>

            <button type="submit" className="mt-6 border" >Atualizar</button> 
        </form>
        </div>
    )
}