using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class UpdateDB
    {
        private Dbconx _dbconx;

        public UpdateDB(Dbconx dbconx)
        {
            this._dbconx = dbconx;  
        }

        //Metodo para la Actualizacion de datos en la base de datos segun su ID
        //Actualmente actualiza toda la informacion de la fila, tengo que cambiarlo para que actualize no mas email y telefono
        public void UpdateUser(int id, String newName, String newApellido, String newEmail, String newTelefono)
        {
            String consulta = "UPDATE Clientes SET Nombre = @name, Apellido = @Apellido, Email = @Email, Telefono = @Telefono WHERE id = @id";

            String stringdeconection = _dbconx.Getconexion();

            using (MySqlConnection con = new MySqlConnection(stringdeconection))
            {
                MySqlCommand cmd = new MySqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@Apellido", newApellido);
                cmd.Parameters.AddWithValue("@Email", newEmail);
                cmd.Parameters.AddWithValue("@Telefono", newTelefono);
                cmd.Parameters.AddWithValue("@id", id);


                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} filas actualizadas");
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Error" + e.Message);
                }

            }
        }


    }
}
