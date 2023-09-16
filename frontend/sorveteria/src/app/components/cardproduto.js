import Image from "next/image"

export default function CardProduto({nome, preco, descricao, foto}) {
    return (
        <div className="h-2/5 w-60 min-h-[280px] mx-2 rounded-md shadow-md">
            <div className="h-4/6 relative">
            <Image 
                src={`${foto}`}
                alt="Foto de um sorvete"
                fill
                sizes="(max-width: 768px) 100vw, (max-width: 1200px) 50vw, 33vw"
            />
            </div>
            <div>
                <h1 className="text-xl font-bold">{nome}</h1>
                <p className="font-light mb-3">R${preco}</p>
                <p>{descricao}</p>
            </div>
        </div>
    )
}