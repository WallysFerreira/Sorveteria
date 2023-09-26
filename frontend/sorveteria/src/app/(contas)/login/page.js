import FormLogin from "@/app/components/formlogin"
import Link from "next/link"

export default function Page() {
    return (
                <div className="h-3/5 w-2/5 px-48 py-32 border-2 rounded-lg shadow-md flex flex-col justify-around items-center">
                    <FormLogin />
                
                    <Link href="/cadastro">Cadastre-se</Link>
                </div>
    )
}
