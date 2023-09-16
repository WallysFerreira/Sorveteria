export default function Page() {
    return (
                <form action={null} className="h-3/5 w-2/5 px-52 py-48 flex flex-col justify-around items-center border-2 rounded-lg shadow-md">
                    <div className="flex flex-col">
                        <label htmlFor="login">Email</label>
                        <input className="border-2" type="email" id="login" name="login" placeholder="email@email.com" required/>
                    </div>

                    <div className="flex flex-col">
                        <label htmlFor="senha">Senha</label>
                        <input className="border-2" type="password" id="senha" name="senha" required/>
                    </div>

                    <button className="border-2 w-[25%] min-w-[80px]" type="submit">Entrar</button>
                </form>
    )
}
