export const metadata = {
    title: "Cardapio",
    description: "Cardapio da Sorveteria Dwitti",
}

export default function CardapioLayout({children}) {
    return (
        <section className="w-screen h-screen">
            {children}
        </section>
    )
}