using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDato
{
    public class Conexion
    {
        private SqlConnection ConexionSql = new SqlConnection("Server=DESKTOP-61VL0KL;DataBase= Bodega;Integrated Security=true");
        public SqlConnection AbrirConexion()
        {
            if (ConexionSql.State == ConnectionState.Closed)
                ConexionSql.Open();
            return ConexionSql;
        }
        public SqlConnection CerrarConexion()
        {
            if (ConexionSql.State == ConnectionState.Open)
                ConexionSql.Close();
            return ConexionSql;
        }
    }
}
