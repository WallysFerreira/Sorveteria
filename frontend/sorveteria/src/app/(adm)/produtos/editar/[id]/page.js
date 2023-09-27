import { getListaProdutos } from "@/app/cardapio/[categoria]/page";
import FormAtualizarProduto from "@/app/components/formatualizarproduto";

export async function generateStaticParams() {
    const produtos = await getListaProdutos();

    return produtos.map((prod) => ({
        id: prod.Id,
        produto: prod,
    }))
}

// Mostrar um formulario para editar um produto especifico
export default async function Page({ params }) {
    const produto = params.produto

    return (
        <FormAtualizarProduto produto={produto} />
    )
} 