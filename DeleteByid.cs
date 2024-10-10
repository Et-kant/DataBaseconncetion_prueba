using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DeleteDB
    {
        private Dbconx _dbconx;

        public DeleteDB(Dbconx dbconx)
        {
            this._dbconx = dbconx;
        }

        //Metodo para el Borrado de datos segun su ID
        public void DeleteUser(int id)
        {
            String consulta = "DELETE FROM Clientes WHERE id = @Id";

            String stringdeConexion = _dbconx.Getconexion();

            using (MySqlConnection con = new MySqlConnection(stringdeConexion))
            {
                MySqlCommand cmd = new MySqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Total de filas afectadas {rowsAffected}");

                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Error" + e.Message);
                }
            }
        }
    }
}
