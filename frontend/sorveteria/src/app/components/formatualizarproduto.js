export default function FormAtualizarProduto({ produto }) {
    return (
        <div className="h-screen w-screen flex justify-center items-center">
        <form className="flex flex-col justify-center items-baseline">
            <div className="flex flex-col">
            <label htmlFor="categoria">Categoria</label>
            <input id="categoria" name="categoria" placeholder={produto.categoria}></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="nome">Nome</label>
            <input id="nome" name="nome" placeholder={produto.nome}></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="preco">Preço</label>
            <input id="preco" name="preco" placeholder={produto.preco}></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="descricao">Descrição</label>
            <input id="descricao" name="preco" placeholder={produto.descricao}></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="foto">Foto</label>
            <input id="foto" name="foto" placeholder={produto.foto}></input>
            </div>
        </form>
        </div>
    )
}