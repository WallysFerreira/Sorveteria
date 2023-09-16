import Link from 'next/link'

export default function Nav() {
    return (
        <nav className='flex flex-row justify-end p-[1vh] bg-slate-500'>
            <Link href="/login" className='border-2 px-4 bg-white'>Entrar</Link>
        </nav>
    )

}