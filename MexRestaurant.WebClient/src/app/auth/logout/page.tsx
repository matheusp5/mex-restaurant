import { handleLogoutContext } from "@/services/AuthService";
import {redirect} from "next/navigation"

export default function Logout() {
  handleLogoutContext()
  return redirect("/")
}