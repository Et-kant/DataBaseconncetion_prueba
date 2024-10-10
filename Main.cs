
using System;
using System.Collections.Generic;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string conexionString = "server=127.0.0.1;user id=root;password=1234;database=users";

            Usuario user = new Usuario("Ryan", "Trujillo", "Email@gmail.com", "3145481234"); //Instancia del usuario, que llama al constructor para crar el object
            Usuario user2 = new Usuario("Pedro", "Sanchez", "Emaail@gmail.com", "123456789");
            Usuario user3 = new Usuario("juian", "Sanchez", "Emaail@gmail.com", "123456789");

            Dbconx server = new Dbconx(conexionString); //Instancia del constructor que conecta la base de datos

            AccesoaDB data = new AccesoaDB(server); //instancia del acceso a la base de datos, recibe un parametro String,

            bool prueba = data.InsertarUsuario(user);
            data.InsertarUsuario(user2);
            data.InsertarUsuario(user3);

            if (prueba)
            {
                Console.WriteLine("La prueba fue exitiosa");
            }
            else
            {
                Console.WriteLine("El usuario no pudo se añadido");
            }

            ReadDB readDB = new ReadDB(server);
            List<Usuario> usuarios = readDB.GetUsers();

            Console.WriteLine("\nUsuario en la base de datos");

            foreach (var usr in usuarios)
            {
                Console.WriteLine($"Nombre: {usr.Nombre}, Apellido: {usr.Apellido}, Email: {usr.Email}, Telefono: {usr.Telefono}");
            }

            UpdateDB updateDB = new UpdateDB(server);
            updateDB.UpdateUser(1, "Roberto", "Lorenzo", "123@gmail.com", "1111111111");
            //updateDB.UpdateUser(10, "JoseAlonso");

            DeleteDB deleteDB = new DeleteDB(server);
            deleteDB.DeleteUser(2);
        }

    }

}

//Pendiente por modularizar el codigo lo mas posible y aplicar MVC, integrar interfaz de usuario as well.