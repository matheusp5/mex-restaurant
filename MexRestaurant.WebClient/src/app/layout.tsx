import { AuthProvider } from '@/contexts/AuthContext'
import './globals.css'
import Header from '@/components/Header'

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <AuthProvider>
      <html lang="pt-br">
        <head>
          <title>Mex Restaurant</title>
        </head>
        <body>
          <Header />
          {children}
        </body>
      </html>
    </AuthProvider>
  )
}
