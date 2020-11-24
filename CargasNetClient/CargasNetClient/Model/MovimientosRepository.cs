using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CargasNetClient.Model
{
    public class MovimientosRepository
    {
        private SQLiteConnection cnn;

        private static MovimientosRepository instancia;

        public static MovimientosRepository GetInstancia
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
            
            instancia = new MovimientosRepository(FileName);
        }




        private MovimientosRepository(string DbPath)
        {
            cnn = new SQLiteConnection(DbPath);
            cnn.CreateTable<Movimientos>();
        }

       
        public int AddNewMovement(string IdDispositivo,string Desc)
        {
            int result = 0;
            try
            {
                result = cnn.Insert(new Movimientos { IdDispositivo=IdDispositivo,Descripcion=Desc,FechaMovimiento=DateTime.Now});

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public IList<Movimientos> GetAllMovement()
        {
            try
            {
                return cnn.Table<Movimientos>().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int DeleteAllMovement()
        {
            int result = 0;
            try
            {
                result = cnn.DeleteAll<Movimientos>();
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    
    }

}
