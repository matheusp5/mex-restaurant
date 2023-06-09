"use client"
import User from "@/types/User";
import {parseCookies} from "nookies"
import * as UserServices from "@/requests/UserRequest"
import { createContext, useState, useEffect } from "react";
import AuthContextType from "@/types/AuthContextType";

const getUserFromCookies = async () => {
  const {__user_mr} = parseCookies()
  return await UserServices.DecodeToken(__user_mr)
}

export const AuthContext = createContext({} as AuthContextType)
export const AuthProvider = ({children}: any) => {

  const [User, setUser] = useState<User>({email: "", id: "", username: ""})
  useEffect(() => {
    if(User.email == "") {
      getUserFromCookies().then(({isSucceeded, email, username, id}: UserServices.IDecodeToken) => {
        if(isSucceeded) setUser({email,username,id})
      })
    }
  }, [])

  return <AuthContext.Provider value={{User}}>{children}</AuthContext.Provider>
}