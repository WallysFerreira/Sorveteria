export async function GET(req, { params }) {
    const res = await fetch(`http://produtos-service:80/api/produtos/${params.id}`)
    const data = await res.json()

    return new Response(data, {
        status: 200
    })
}

export async function DELETE(req, { params }) {
    const res = await fetch(`http://produtos-service:80/api/produtos/${params.id}`, {
        method: 'DELETE'
    })

    return new Response('Ok', {
        status: 200
    })
}

export async function PUT(req, { params }) {
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

    const res = await fetch(`http://produtos-service:80/api/produtos${params.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(json)
    })
}