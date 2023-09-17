// Lista dos produtos com botão pra apagar e pra editar

import { getListaProdutos } from "@/app/cardapio/[categoria]/page"
import ListaProdutos from "@/app/components/listaprodutos";

export default async function Page() {
    const produtos = await getListaProdutos();
    var visivel = false

    return (
        <section className="h-screen flex justify-center items-center">
            <ListaProdutos produtos={produtos}></ListaProdutos>
            
        </section>
    )
}