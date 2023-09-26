export const metadata = {
    title: "Login/Cadastro",
    description: "Faça login na plataforma",
}

export default function FormsLayout({
    children,
}) {
    return (
        <section className="h-screen flex justify-center items-center">
            {children}
        </section>
    )
}
