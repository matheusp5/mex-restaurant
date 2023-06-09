import Image from 'next/image'
import { IProduct } from "@/requests/ProductRequest";

export default function Product({product}: {product: IProduct}){
  return <div className="border py-6 px-6 border-purple-500 mb-8 rounded w-auto">
    <h5 className="text-2xl font-bold text-purple-900 text-center">{product.name}</h5>
    <h6 className="text-xl text-center text-purple-900 italic mt-4">R${product.price.toLocaleString('pt-br')}</h6>
    <img alt={product.name} src={product.imageUrl} style={{width: 240}}/>
    
  </div>
} 