﻿using MySql.Data.MySqlClient;
using System;

namespace ConsoleApp1
{
    //Objeto
    public class Dbconx
    {
        private String _Stringdeconexion;

        //Constructor
        public Dbconx(String conexionString)
        {
            this._Stringdeconexion = conexionString;
        }

        //Metodo para retornar el string d conexion
        public string Getconexion()
        {
            return _Stringdeconexion;
        } 
        
    }

}
