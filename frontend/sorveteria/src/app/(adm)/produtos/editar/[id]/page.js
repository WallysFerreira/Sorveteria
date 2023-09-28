import { getListaProdutos } from "@/app/cardapio/[categoria]/page";
import FormAtualizarProduto from "@/app/components/formatualizarproduto";

export async function generateStaticParams() {
    const produtos = await getListaProdutos();

    return produtos.map((prod) => ({
        id: prod.id.toString(),
    }))
}

// Mostrar um formulario para editar um produto especifico
export default async function Page({ params }) {
    const produto = await fetch(`http://localhost:5172/api/produtos/${params.id}`).then((res) => res.json())

    return (
        <FormAtualizarProduto produto={produto} />
    )
} 