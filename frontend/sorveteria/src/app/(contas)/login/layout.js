export const metadata = {
    title: "Login",
    description: "Faça login na plataforma",
}

export default function LoginLayout({
    children,
}) {
    return (
        <section className="h-screen flex justify-center items-center">
            {children}
        </section>
    )
}
