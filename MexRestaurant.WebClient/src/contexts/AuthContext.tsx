import User from "@/types/User";
import { createContext, useState } from "react";

export const AuthContext = createContext({})
export const AuthProvider = ({children}: any) => {
  
  const [user, setUser] = useState<User>()
  const Login = (email: string, password: string) => {

  }
  const Register = (email: string, username: string, password: string) => {

  }

  return <AuthContext.Provider value={{user, Login, Register}}>{children}</AuthContext.Provider>

}