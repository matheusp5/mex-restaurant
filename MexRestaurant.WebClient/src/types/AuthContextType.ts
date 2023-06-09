import User from "./User"
import * as AuthServices from "@/requests/AuthRequest"

type AuthContextType = {
  User: User
}

export default AuthContextType