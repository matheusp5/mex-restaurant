import axios from "axios"
import https from "https"

const URL_BASE = "https://localhost:7011"
const agent = new https.Agent({
  rejectUnauthorized: false
});
const api = axios.create({
  baseURL: URL_BASE,
  httpsAgent: agent
});
export interface IProduct { 
  productId: number
  name: string
  price: number
  imageUrl: string
}


export const GetAllProducts = async (): Promise<IProduct[] > => {
  const result: IProduct[] = (await api.get(`/api/products/all`)).data
  return result
}