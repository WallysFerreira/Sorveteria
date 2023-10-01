export default function FormAdicionarProduto({ styling }) {
    return (
        <form action={`http://${process.env.URL_PRODUTOS}:${process.env.PORT_PRODUTOS}/api/produtos`} method="post" id="adicionarProduto" className={styling}>
            <div className="flex flex-col">
            <label htmlFor="categoria">Categoria</label>
            <input className="border" id="categoria" name="categoria" ></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="nome">Nome</label>
            <input className="border" id="nome" name="nome" ></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="preco">Preço</label>
            <input className="border" id="preco" name="preco" ></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="descricao">Descrição</label>
            <input className="border" id="descricao" name="descricao" ></input>
            </div>

            <div className="flex flex-col">
            <label htmlFor="foto">Foto</label>
            <input className="border" id="foto" name="foto" ></input>
            </div>

            <button type="submit" className="mt-6 border">Criar</button> 
        </form>
    )
}