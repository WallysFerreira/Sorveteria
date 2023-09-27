export default function FormAtualizarProduto({ produto }) {
    return (
        <div className="h-screen w-screen flex justify-center items-center">
        <form action="https://localhost:5172/api/produtos/" method="put" className="flex flex-col justify-center items-center">
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
            <input className="border" id="descricao" name="preco" placeholder={produto.descricao}></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="foto">Foto</label>
            <input className="border" id="foto" name="foto" placeholder={produto.foto}></input>
            </div>

            <button type="submit" className="mt-6 border">Atualizar</button> 
        </form>
        </div>
    )
}