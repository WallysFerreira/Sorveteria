import { getListaProdutos } from "@/app/cardapio/[categoria]/page";
import FormAtualizarProduto from "@/app/components/formatualizarproduto";

export async function generateStaticParams() {
    const produtos = await getListaProdutos();

    return produtos.map((_, idx) => ({
        id: idx.toString(),
    }))
}

// Mostrar um formulario para editar um produto especifico
export default async function Page({ params }) {
    const produtos = await getListaProdutos()
    const produto = produtos[params.id]

    return (
        <FormAtualizarProduto produto={produto} />
    )
} 