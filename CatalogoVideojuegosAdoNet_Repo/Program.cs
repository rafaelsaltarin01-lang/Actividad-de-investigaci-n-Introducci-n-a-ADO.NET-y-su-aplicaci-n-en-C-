using System;
using Microsoft.Data.Sqlite;

namespace CatalogoVideojuegosAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string cadenaConexion = "Data Source=catalogo_juegos.db";

            Console.WriteLine("=== GESTIÓN DE VIDEOJUEGOS CON ADO.NET Y SQLITE ===\n");

           
            using (var conexion = new SqliteConnection(cadenaConexion))
            {
                conexion.Open();
                Console.WriteLine("[OK] Conexión establecida con 'catalogo_juegos.db'.");

                
                string sqlCrearTabla = @"
                    CREATE TABLE IF NOT EXISTS Videojuegos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Titulo TEXT NOT NULL,
                        Genero TEXT NOT NULL,
                        AnioLanzamiento INTEGER NOT NULL
                    );";

                using (var cmdTabla = new SqliteCommand(sqlCrearTabla, conexion))
                {
                    cmdTabla.ExecuteNonQuery();
                    Console.WriteLine("[OK] Tabla 'Videojuegos' verificada/creada.");
                }

                using (var cmdLimpiar = new SqliteCommand("DELETE FROM Videojuegos;", conexion))
                {
                    cmdLimpiar.ExecuteNonQuery();
                }

                InsertarJuego(conexion, "The Legend of Zelda: Breath of the Wild", "Aventura", 2017);
                InsertarJuego(conexion, "Hollow Knight", "Metroidvania", 2017);
                InsertarJuego(conexion, "Elden Ring", "RPG de Acción", 2022);

                Console.WriteLine("[OK] 3 registros insertados correctamente.\n");

                string sqlConsultar = "SELECT Id, Titulo, Genero, AnioLanzamiento FROM Videojuegos;";
                
                using (var cmdConsultar = new SqliteCommand(sqlConsultar, conexion))
                {
                    using (var lector = cmdConsultar.ExecuteReader())
                    {
                        Console.WriteLine("-------------------------------------------------------------------------");
                        Console.WriteLine(string.Format("{0,-4} | {1,-42} | {2,-16} | {3,-6}", "ID", "TÍTULO", "GÉNERO", "AÑO"));
                        Console.WriteLine("-------------------------------------------------------------------------");

                        while (lector.Read())
                        {
                            long id = lector.GetInt64(0);
                            string titulo = lector.GetString(1);
                            string genero = lector.GetString(2);
                            int anio = lector.GetInt32(3);

                            Console.WriteLine(string.Format("{0,-4} | {1,-42} | {2,-16} | {3,-6}", id, titulo, genero, anio));
                        }

                        Console.WriteLine("-------------------------------------------------------------------------");
                    }
                }
            }

            Console.WriteLine("\n[FIN] Recursos liberados. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        
        private static void InsertarJuego(SqliteConnection conexion, string titulo, string genero, int anio)
        {
            string sqlInsertar = "INSERT INTO Videojuegos (Titulo, Genero, AnioLanzamiento) VALUES (@titulo, @genero, @anio);";
            
            using (var cmd = new SqliteCommand(sqlInsertar, conexion))
            {
                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@anio", anio);
                
                cmd.ExecuteNonQuery();
            }
        }
    }
}
