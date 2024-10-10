using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class ReadDB
    {
        private Dbconx _dbconx;

        public ReadDB(Dbconx dbconx)
        {
            this._dbconx = dbconx;
        }

        //Metodo que recib una lista para el disply de la informacion del objeto 
        public List<Usuario> GetUsers()
        {
            List<Usuario> users = new List<Usuario>();
            String consulta = "SELECT Nombre, Apellido, Email, Telefono FROM Clientes";

            String stringdeConexion = _dbconx.Getconexion();

            using (MySqlConnection con = new MySqlConnection(stringdeConexion))
            {
                try
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(consulta, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Usuario usuarios = new Usuario(
                                    reader["Nombre"].ToString(),
                                    reader["Apellido"].ToString(),
                                    reader["Email"].ToString(),
                                    reader["Telefono"].ToString()
                                    );

                                users.Add(usuarios);
                            }
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("ERROR" + e);
                }
            }

            return users;
        }

    }
}
