using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaDatos.OBJETOS;

namespace Lab3
{
    public partial class index1 : System.Web.UI.Page
    {
        GestionDB objBD;
        List<CategoriaHerramienta> listadoTool;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarCmbHerramientas();
            }
        }
        void cargarCmbHerramientas()
        {
            objBD = new GestionDB();
            listadoTool = objBD.ListadoHerramienta();
            DropDownListcategoriaHerramienta.DataSource = listadoTool;
            DropDownListcategoriaHerramienta.DataTextField = "cat_desc";
            DropDownListcategoriaHerramienta.DataValueField = "cat_id";
            DropDownListcategoriaHerramienta.DataBind();

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            objBD = new GestionDB();
            ControlHerramienta objTool = new ControlHerramienta();
            objTool.ct_nombre = txtCT_nombre.Text;
            objTool.ct_codigo = txtCT_codigo.Text;
            objTool.ct_marca = txtCT_marca.Text;
            objTool.ct_cate=DropDownListcategoriaHerramienta.Text;
            objTool.ct_precio=Convert.ToDecimal(txtCT_precio.Text);

            bool resultado = objBD.registrarHerramienta(objTool) ;


            if (resultado)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "Swal.fire('Registro con exito')", true);
                return;
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "alert('No se logro registrar')", true);

        }

        protected void btnborrar_Click(object sender, EventArgs e)
        {
            objBD = new GestionDB();
            ControlHerramienta objTool = new ControlHerramienta();
            objTool.ct_codigo = txtCT_codigo.Text;


            bool resultado = objBD.borrado(objTool);


            if (resultado)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "Swal.fire('Eliminación del registro con exito')", true);
                return;
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "alert('No se pudo eliminar el registro')", true);

        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            objBD = new GestionDB();
            ControlHerramienta objTool = new ControlHerramienta();
            objTool.ct_codigo = txtCT_codigo.Text;


            bool resultado = objBD.actualizarRegistro(objTool);


            if (resultado)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "Swal.fire('Se actualizó con exito el registro')", true);
                return;
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr1", "alert('No se pudo actualizar el registro')", true);

        }
    }
}