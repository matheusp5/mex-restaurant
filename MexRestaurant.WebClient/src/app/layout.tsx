import './globals.css'

export const metadata = {
  title: 'Mex Restaurant',
  description: 'Mex Restaurant Client App',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="pt-br">
      <body>{children}</body>
    </html>
  )
}
