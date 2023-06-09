import Product from "@/components/Product"
import { GetAllProducts, IProduct } from "@/requests/ProductRequest"

export default async function Home() {
  const products: IProduct[] = await GetAllProducts()
  return (
    <div className="mx-44 mt-12">
      <h1 className="text-4xl">All Products</h1>
      <div className="d-flex max-w-8xl mt-12 flex justify-around flex-wrap">
        {products.map((e: IProduct) =><Product key={e.productId} product={e} />)}
      </div>
      
    </div>
  )
}
