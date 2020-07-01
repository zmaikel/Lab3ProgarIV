using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaDatos.OBJETOS;

namespace CapaDatos
{
    public class GestionDB
    {
        SqlCommand comando;
        string CadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public List<CategoriaHerramienta> ListadoHerramienta()
        {
            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {
                SqlDataReader datosLeidos;
                List<CategoriaHerramienta> listadoRentornar;
                comando = new SqlCommand();
                comando.Connection = conex;

                comando.CommandText = "select * from CategoriaHerramienta";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandTimeout = 0;

                conex.Open();
                datosLeidos = comando.ExecuteReader();

                listadoRentornar = new List<CategoriaHerramienta>();
                while (datosLeidos.Read())
                {

                    CategoriaHerramienta objTool = new CategoriaHerramienta();
                    objTool.cat_id = datosLeidos.GetInt32(0);
                    objTool.cat_desc = datosLeidos.GetString(1);
                    listadoRentornar.Add(objTool);

                }

                return listadoRentornar;

            }
        }

        public bool borrado(ControlHerramienta objTool)
        {
            int control = -1;
            bool respuesta = false;
            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {
                    comando = new SqlCommand(); 
                    comando.Connection = conex; 
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandTimeout = 0;
                    comando.CommandText = "Delete from ControlHerramienta where CT_CODIGO = @codigo";
                    
                    comando.Parameters.Add(new SqlParameter("@codigo", objTool.ct_codigo));

                    conex.Open();

                    control = comando.ExecuteNonQuery();

            }
            if (control > 0)
            {
                respuesta = true;
            }return respuesta;
        }


        public bool registrarHerramienta(ControlHerramienta objTool)
        {
            int control = -1;
            bool respuesta = false;

            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {

                comando = new SqlCommand();
                comando.Connection = conex;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandTimeout = 0;
                comando.CommandText = "insert into ControlHerramienta (CT_NOMBRE ,CT_CODIGO, CT_MARCA , CT_CAT , CT_PRECIO) values(@nombreTool ,@codigoTool, @marcaTool , @categoriaTool , @precio)";
                

                comando.Parameters.Add(new SqlParameter("@nombreTool", objTool.ct_nombre));
                comando.Parameters.Add(new SqlParameter("@codigoTool", objTool.ct_codigo));
                comando.Parameters.Add(new SqlParameter("@marcaTool", objTool.ct_marca));
                comando.Parameters.Add(new SqlParameter("@categoriaTool",objTool.ct_cate));
                comando.Parameters.Add(new SqlParameter("@precio",objTool.ct_precio));


                conex.Open();
                
                control = comando.ExecuteNonQuery();

            }

            if (control > 0)
            {
                respuesta = true;
            }

            return respuesta;

      
        }
        public bool actualizarRegistro(ControlHerramienta objTool)
        {

            int control = -1;
            bool respuesta = false;

            using (SqlConnection conex = new SqlConnection(CadenaConexion))
            {

                comando = new SqlCommand();
                comando.Connection = conex;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandTimeout = 0;
                comando.CommandText = "update ControlHerramienta set [CT_NOMBRE]=@nombreTool, [CT_CODIGO]=@codigoTool,[CT_MARCA]=@marcaTool,[CT_CAT]=@categoriaTool,[CT_PRECIO]=@precio where CT_CODIGO=@codigoTool";


                comando.Parameters.Add(new SqlParameter("@nombreTool", objTool.ct_nombre));
                comando.Parameters.Add(new SqlParameter("@codigoTool", objTool.ct_codigo));
                comando.Parameters.Add(new SqlParameter("@marcaTool", objTool.ct_marca));
                comando.Parameters.Add(new SqlParameter("@categoriaTool", objTool.ct_cate));
                comando.Parameters.Add(new SqlParameter("@precio", objTool.ct_precio));


                conex.Open();

                control = comando.ExecuteNonQuery();

            }

            if (control > 0)
            {
                respuesta = true;
            }

            return respuesta;
        }




    }
}
