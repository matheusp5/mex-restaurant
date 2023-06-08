import User from "./User"

type AuthContextType = {
  Login: (email: string, password: string) => void
  Register: (email: string, username: string, password: string) => void
  User: User
}