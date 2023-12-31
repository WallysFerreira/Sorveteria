import CardProduto from "@/app/components/cardproduto"

export async function getListaProdutos() {
    const produtos = await fetch(`http://produtos-service:80/api/produtos`).then((res) => res.json())

    return produtos
}

export default async function Page({ params }) {
    const produtos = await getListaProdutos()

    return (
        <section className="p-2 flex flex-wrap h-full w-full">
        {produtos.map((produto) => { 
            if (params.categoria == produto.categoria.toLowerCase()) {
            return (
                <CardProduto
                nome={produto.nome}
                descricao={produto.descricao}
                preco={produto.preco}
                foto={produto.foto}
            />
            )
            }
                
        })}
        </section>

    )
}