export default function Page() {
    return (
                <form action={null} className="h-3/5 w-2/5 px-52 py-48 flex flex-col justify-around items-center border-2 rounded-lg ">
                    <div className="flex flex-col">
                        <label for="login">Email</label>
                        <input className="border-2" type="email" name="login" />
                    </div>

                    <div className="flex flex-col">
                        <label>Senha</label>
                        <input className="border-2" type="password" name="senha" />
                    </div>

                    <button className="border-2 w-[25%]" type="submit">Entrar</button>
                </form>
    )
}
