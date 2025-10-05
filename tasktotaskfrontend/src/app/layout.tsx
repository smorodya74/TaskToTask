import Sidebar from "@/src/components/Sidebar";
import "./globals.css";
import Header from "../components/Header";

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className="min-h-screen flex bg-background text-foreground">
  {/* === Sidebar слева === */}
  <Sidebar />

  {/* === Контейнер справа (Header + Main) === */}
  <div className="flex-1 flex flex-col">
    <Header />
    <main className="flex-1 p-6 bg-muted">
      Hello
    </main>
  </div>
</body>

    </html>
  );
}
