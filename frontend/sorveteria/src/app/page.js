import Card from '@/app/components/card'

export default function Home() {
  return (
    <main className="flex flex-col justify-between items-center min-h-screen p-24">
      <h1 className='text-6xl'>Bem vindo à Sorveteria Dwitti</h1>
      <div className='flex flex-col items-center justify-center w-full'>
        <h2 className='text-3xl mb-10'>Conheça nosso cardápio</h2>
        <div className="flex flex-row justify-between w-1/2">
          <Card categoria="Cafés" url="img_categoria-caffeteria4.jpg" link="cafes"></Card>
          <Card categoria="Sorvetes" url="img_categoria-gelatos.jpg" link="sorvetes"></Card>
          <Card categoria="Bolos" url="img_categoria-confeitaria.jpg" link="bolos"></Card>
        </div>
      </div>
    </main>
  )
}
