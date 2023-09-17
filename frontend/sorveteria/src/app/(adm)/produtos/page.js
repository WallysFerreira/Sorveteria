// Lista dos produtos com botão pra apagar e pra editar

import { getListaProdutos } from "@/app/cardapio/[categoria]/page"
import Link from "next/link";

export default async function Page() {
    const produtos = await getListaProdutos();

    return (
        <section className="h-screen flex justify-center items-center">
            <div className="border-2 rounded-lg p-11 flex flex-col items-center">
            <table className="table-fixed border-separate" >
                <thead>
                    <tr>
                        <th className="border">Categoria</th>
                        <th className="border">Nome</th>
                        <th className="border">Preço</th>
                        <th className="border">Descrição</th>
                        <th className="border">Foto</th>
                    </tr>
                </thead>
                <tbody>
                    {produtos.map((produto, idx) => {
                        return (
                            <tr>
                                <td className="border">{produto.categoria}</td>
                                <td className="border">{produto.nome}</td>
                                <td className="border">R${produto.preco}</td>
                                <td className="border">{produto.descricao}</td>
                                <td className="border">{produto.foto}</td>
                                <td>
                                    <Link className="mr-5 ml-2 border bg-yellow-300 p-1" key={idx} href={`/produtos/editar/${idx}`}>Editar</Link>
                                    <Link className="border bg-red-500 p-1" href={`/excluir/{id}`}>Excluir</Link>
                                </td>
                            </tr>
                        )
                    })}
                </tbody>
            </table>
            <button className="border mt-6 bg-green-500 w-[10%] h-11">Novo</button>
            </div>
        </section>
    )
}