
import * as AuthServices from "@/requests/AuthRequest"
import * as UserServices from "@/requests/UserRequest"
import {setCookie, destroyCookie} from "nookies"

const setUserCookie = (token: string) => {
  setCookie(null, '__user_mr', token, {
    maxAge: 30 * 24 * 60 * 60,
    path: '/',
  })
}

export const handleLoginContext = async (email: string, password: string): Promise<AuthServices.ILoginRequest> => {
  let req: AuthServices.ILoginRequest = await AuthServices.LoginRequest(email, password)
  if(req.isApproved) setUserCookie(req.token)
  return req
}

export const handleRegisterContext = async (email: string, username: string, password: string): Promise<AuthServices.IRegisterRequest> => {
  let req: AuthServices.IRegisterRequest = await AuthServices.RegisterRequest(email, username, password)
  if(req.isSucceeded) setUserCookie(req.token)
  return req
}

export const handleLogoutContext = () => {
  destroyCookie(null, "__user_mr")
}