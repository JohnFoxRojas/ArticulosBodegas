using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Timers;
using CapaDato;




namespace CapaDato
{
    public class CProductos
    {
        
        private Conexion conexion = new Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

       
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_MostrarArticulos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Insertar(string Descripcion, string Fecha_ing, string Valor, string StockMinimo, int Codigo_Bodega)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_InsertarArticulos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Fecha_Ingreso", Convert.ToDateTime(Fecha_ing));
            comando.Parameters.AddWithValue("@Valor", Convert.ToDouble(Valor));
            comando.Parameters.AddWithValue("@StockMinimo", Convert.ToDouble(StockMinimo));
            comando.Parameters.AddWithValue("@Codigo_Bodega", Convert.ToDouble(Codigo_Bodega));
            


            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
            

        }
        public void Eliminar(string codigo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_eliminarArticulo";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCodigo", Convert.ToDouble(codigo));
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }
        public void Actualizar(string Descripcion, string Fecha_ing, string Valor, string StockMinimo, int Codigo_Bodega, string codigo)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SP_editarArticulos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Fecha_Ingreso", Convert.ToDateTime(Fecha_ing));
            comando.Parameters.AddWithValue("@Valor", Convert.ToDouble(Valor));
            comando.Parameters.AddWithValue("@StockMinimo", Convert.ToDouble(StockMinimo));
            comando.Parameters.AddWithValue("@Codigo_Bodega", Convert.ToDouble(Codigo_Bodega));
            comando.Parameters.AddWithValue("@idCodigo", Convert.ToDouble(codigo));
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
       

        }
       
    public class categoriaCMB 
    {
        Conexion cn = new Conexion();

        public DataTable cargarCombo()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_cargarCombo", cn.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            

        }

    }
    public class nombresBodegas
    {
        Conexion cn = new Conexion();

        public DataTable cargarNombreBodega()
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_cargarListBox", cn.AbrirConexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }

    }

}
