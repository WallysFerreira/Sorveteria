import Nav from "@/app/components/nav"

export const metadata = {
    title: "Cardapio",
    description: "Cardapio da Sorveteria Dwitti",
}

export default function CardapioLayout({children}) {
    return ( 
        <main>
        <Nav></Nav>
        <section className="w-screen h-[95vh]">
            {children}
        </section>
        </main>
    )
}