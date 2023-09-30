'use client'

import Link from "next/link"
import FormAdicionarProduto from "./formadicionarproduto"
import { useEffect, useState } from "react"

export default function ListaProdutos({ produtos }) {
    const [visivel, setVisivel] = useState(false)

    function toggleVisivel() {
        setVisivel(!visivel)
    }

    return (
        <>
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
                    {produtos.map((produto) => {
                        return (
                            <tr>
                                <td className="border">{produto.categoria}</td>
                                <td className="border">{produto.nome}</td>
                                <td className="border">R${produto.preco}</td>
                                <td className="border">{produto.descricao}</td>
                                <td className="border">{produto.foto}</td>
                                <td>
                                    <Link className="mr-5 ml-2 border bg-yellow-300 p-1" key={produto.Id} href={`/produtos/editar/${produto.Id}`}>Editar</Link>
                                    <button className="border bg-red-500 p-1" onClick={() => {
                                        fetch(`http://localhost:5172/api/produtos/${produto.id}`, {
                                            method: 'DELETE'
                                        })
                                    }}>Excluir</button>
                                </td>
                            </tr>
                        )
                    })}
                </tbody>
            </table>
            <button className="border mt-6 bg-green-500 w-[10%] h-11" onClick={() => {toggleVisivel()}} >Novo</button>
            </div>

            <div>
                    <FormAdicionarProduto styling={`ml-32 ${visivel ? "" : "hidden"}`} />
            </div>
        </>
    )
}