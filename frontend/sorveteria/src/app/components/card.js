export default function Card({ url, categoria, link}) {
    return (
        <a href={{link}}>
            <div className="container w-56 h-80 flex flex-col justify-center items-center text-gray-400 text-xs hover:text-white" style={{backgroundImage: `url(${url})`, backgroundSize: 'cover'}}> 
                <h1 className="text-white text-2xl">{categoria}</h1>
                veja +
            </div>
        </a>
    )
}