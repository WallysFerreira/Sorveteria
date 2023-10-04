export async function GET(req) {
    const res = await fetch('http://produtos-service:80/api/produtos')
    const data = await res.json()

    return new Response(data, {
        status: 200
    })
}

export async function POST(req) {
    const formData = await req.formData()

    const categoria = formData.get('categoria')
    const nome = formData.get('nome')
    const preco = parseFloat(formData.get('preco'))
    const descricao = formData.get('descricao')
    const foto = formData.get('foto')

    const json = {
        'categoria': categoria,
        'nome': nome,
        'preco': preco,
        'descricao': descricao,
        'foto': foto
    }

    await fetch('http://produtos-service:80/api/produtos', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(json)
    })

    return new Response('Ok', {
        status: 200
    })
}