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

export interface IDecodeToken {
  isSucceeded: boolean,
  email: string
  username: string
  id: string
}

export const DecodeToken = async (Token: string): Promise<IDecodeToken> => {
  const result: IDecodeToken = (await api.post(`/api/user/token`, {Token})).data
  return result
}