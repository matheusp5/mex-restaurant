
import { IProduct } from "@/requests/ProductRequest";

export default function Product({product}: {product: IProduct}){
  return <div className="border py-6 px-6 border-purple-500 mb-8 rounded w-auto flex flex-col items-center">
    <h5 className="text-2xl font-bold text-purple-900 ">{product.name}</h5>
    <h6 className="text-xl text-purple-900 italic mt-4">R${product.price.toLocaleString('pt-br')}</h6>
    <img alt={product.name} src={product.imageUrl} style={{width: 240}}/>
    <button className="bg-purple-500 mt-4 w-100 hover:bg-purple-700 text-white font-bold py-2 px-4 rounded">
      Adicionar ao carrinho
    </button>
  </div>
} 