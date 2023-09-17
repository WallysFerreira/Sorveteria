// Lista dos produtos com botão pra apagar e pra editar

import { getData } from "@/app/cardapio/[categoria]/page"
import Link from "next/link";

export default async function Page() {
    const produtos = await getData();

    return (
        <section className="h-screen flex justify-center items-center">
            <div className="border-2 rounded-lg p-11">
            <table className="table-fixed" >
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
                    {produtos.map((produto) => {
                        return (
                            <tr>
                                <td className="border">{produto.categoria}</td>
                                <td className="border">{produto.nome}</td>
                                <td className="border">{produto.preco}</td>
                                <td className="border">{produto.descricao}</td>
                                <td className="border">{produto.foto}</td>
                                <td>
                                    <Link href={`/editar/{id}`}>Editar</Link>
                                    <Link href={`/excluir/{id}`}>Excluir</Link>
                                </td>
                            </tr>
                        )
                    })}
                </tbody>
            </table>
            </div>
        </section>
    )
}