import CardProduto from "@/app/components/cardproduto"

export async function getListaProdutos() {
    const produtos = await fetch(`http://${process.env.URL_PRODUTOS}:${process.env.PORT_PRODUTOS}/api/produtos`).then((res) => res.json())

    return produtos
}
export async function generateStaticParams() {
    const produtos = await getListaProdutos()

    return produtos.map((produto) => ({
        categoria: produto.categoria,
    }))
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