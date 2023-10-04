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