export default function LoginLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
      <html lang="pt-br">
        <head>
          <title>
            Log-in | Mex Restaurant
          </title>
        </head>
        <body>{children}</body>
      </html>
  )
}
