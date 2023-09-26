export default function FormCadastro() {
    return (
        <form action={null} className="h-3/5 w-2/5 px-48 py-32 border-2 rounded-lg shadow-md flex flex-col justify-around items-center">
            <div className="flex flex-row">
                <div className="flex flex-col">
                    <label htmlFor="nome">Nome</label>
                    <input className="border-2" type="text" name="nome" id="nome" required />
                </div>

                <div className="flex flex-col">
                    <label htmlFor="sobrenome">Sobrenome</label>
                    <input className="border-2" type="text" name="sobrenome" id="sobrenome" required />
                </div>
            </div>
                
            <div className="flex flex-col">
                <label htmlFor="email">Email</label>
                <input className="border-2" type="email" name="email" id="email" required />
            </div>

            <div className="flex flex-col">
                <label htmlFor="senha">Senha</label>
                <input className="border-2" type="password" name="senha" id="senha" required />
            </div>

            <button className="border-2" type="submit">Cadastrar</button>
        </form>
    )
}