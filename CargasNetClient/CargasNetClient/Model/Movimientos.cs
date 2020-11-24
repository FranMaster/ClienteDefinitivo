using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CargasNetClient.Model
{
    [Table("Movimientos")]
    public class Movimientos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100), Unique]
        public string IdDispositivo { get; set; }

        [MaxLength(100), Unique]
        public string Descripcion { get; set; }

        public DateTime FechaMovimiento { get; set; }

    }
}
