using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CargasNetClient.Model
{
    public class UserRepository
    {
        private SQLiteConnection cnn;

        private static UserRepository instancia;

        public static UserRepository GetInstancia
        {
            get
            {
                if (instancia==null)
                {
                    throw new Exception("Debe llamar al inicializador");
                }
                return  instancia; 
            }            
        }


        public static void Inicializador(string FileName)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                throw new ArgumentException();
            }
            if (instancia!=null)
                instancia.cnn.Close();
            
            instancia = new UserRepository(FileName);
        }




        private UserRepository(string DbPath)
        {
            cnn = new SQLiteConnection(DbPath);
            cnn.CreateTable<Users>();
        }

       
        public int AddNewUser(string username,string password,string email)
        {
            int result = 0;
            try
            {
                result = cnn.Insert(new Users { Usuario = username, Email = email, Password = password });

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            try
            {
                return cnn.Table<Users>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    
    }

}
