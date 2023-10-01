import { getListaProdutos } from "@/app/cardapio/[categoria]/page";
import FormAtualizarProduto from "@/app/components/formatualizarproduto";

// Mostrar um formulario para editar um produto especifico
export default async function Page({ params }) {
    const produto = await fetch(`http://produtos-service:80/api/produtos/${params.id}`).then((res) => res.json())

    return (
        <FormAtualizarProduto produto={produto} />
    )
} 