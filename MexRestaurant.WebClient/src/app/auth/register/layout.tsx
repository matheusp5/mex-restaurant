export default function RegisterLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
      <html lang="pt-br">
        <head>
          <title>
            Register | Mex Restaurant
          </title>
        </head>
        <body>{children}</body>
      </html>
  )
}
