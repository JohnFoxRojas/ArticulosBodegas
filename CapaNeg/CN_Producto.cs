using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDato;
using System.Windows.Forms;






namespace CapaNeg
{
    public class CN_Producto
    {
        
        private CProductos objetoCP = new CProductos();
        public DataTable MostrarProd()
        {
        
            DataTable tabla = new DataTable();
            tabla = objetoCP.Mostrar();
            return tabla;
        }
        public void InsertarArt(string Descripcion, string Fecha_ing, string Valor, string StockMinimo, int Codigo_Bodega )
        {
            
            objetoCP.Insertar(Descripcion, Fecha_ing,Valor, StockMinimo, Codigo_Bodega);
            
        }
        public void actualizarArt(string Descripcion, string Fecha_ing, string Valor, string StockMinimo, int Codigo_Bodega, string codigo)
        {

            objetoCP.Actualizar(Descripcion, Fecha_ing, Valor, StockMinimo, Codigo_Bodega, codigo);

        }
        public void eliminarArt(string codigo)
        {
            objetoCP.Eliminar(codigo);
        }
        
    }
}