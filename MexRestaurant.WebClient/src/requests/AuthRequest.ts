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

export interface ILoginRequest {
  isApproved: boolean
  token: string
}

export interface IRegisterRequest {
  isSucceeded: boolean
  token: string
}

export const LoginRequest = async (Email: string, Password: string): Promise<ILoginRequest> => {
  const result: ILoginRequest = (await api.post(`/api/auth/login`, {Email,Password})).data
  return result
}

export const RegisterRequest = async(Email: string, Username: string, Password: string): Promise<IRegisterRequest> => {
  const result: IRegisterRequest = (await api.post(`/api/auth/register`, {Email,Username,Password})).data
  return result
}