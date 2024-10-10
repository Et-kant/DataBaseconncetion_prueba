using MySql.Data.MySqlClient;
using System;


namespace ConsoleApp1
{
    public class AccesoaDB
    {

        private Dbconx _dbconx;

        public AccesoaDB(Dbconx dbconx)
        {
            this._dbconx = dbconx;
        }

        //Metodo para agregar informacion a la base de datos
        public bool InsertarUsuario(Usuario usuario)
        {
            string consulta = "INSERT INTO Clientes (Nombre, Apellido, Email, Telefono) VALUES (@Nombre, @Apellido, @Email, @Telefono)";

            String stringdeconexion = _dbconx.Getconexion();

            using (MySqlConnection con = new MySqlConnection(stringdeconexion))
            {
                try
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);

                        int filasAfect = cmd.ExecuteNonQuery();

                        return filasAfect > 0;
                    }

                }
                catch (MySqlException e)
                {
                    Console.WriteLine("ERROR" + e.Message);
                    return false;
                }
                finally
                {
                    con.Close();
                    Console.WriteLine("Coneccion cerrada satisfactoriamente");
                }

            }
        }

    }
}
