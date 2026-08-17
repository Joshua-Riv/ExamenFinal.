using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using EcoReciclaje.modelo;
using EcoReciclaje.logica;

namespace EcoReciclaje
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipos();
                CargarUsuarios();
                CargarUsuariosTabla();
                CargarReciclajes();
                CargarEstadistica();
            }
        }

        private void CargarTipos()
        {
            List<cls_tipo> tipos = logica_tipo.ObtenerTipos();

            ddlMaterial.DataSource = tipos;
            ddlMaterial.DataTextField = "nombre";
            ddlMaterial.DataValueField = "id";
            ddlMaterial.DataBind();

            ddlMaterial.Items.Insert(
                0,
                new ListItem("-- Seleccione un material --", "0")
            );
        }

        private void CargarUsuarios()
        {
            List<cls_usuario> usuarios = logica_usuario.ObtenerUsuarios();

            ddlUsuario.DataSource = usuarios;
            ddlUsuario.DataTextField = "nombre";
            ddlUsuario.DataValueField = "id";
            ddlUsuario.DataBind();

            ddlUsuario.Items.Insert(
                0,
                new ListItem("-- Seleccione un usuario --", "0")
            );
        }

        private void CargarUsuariosTabla()
        {
            List<cls_usuario> usuarios = logica_usuario.ObtenerUsuarios();

            gvUsuarios.DataSource = usuarios;
            gvUsuarios.DataBind();
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            string cedula = txtCedulaUsuario.Text;
            string nombre = txtNombreUsuario.Text;
            string correo = txtCorreoUsuario.Text;

            int resultado = logica_usuario.AgregarUsuario(
                cedula,
                nombre,
                correo
            );

            if (resultado > 0)
            {
                Response.Write(
                    "<script>alert('Usuario agregado correctamente');</script>"
                );

                txtCedulaUsuario.Text = "";
                txtNombreUsuario.Text = "";
                txtCorreoUsuario.Text = "";

                CargarUsuarios();
                CargarUsuariosTabla();
            }
        }

        protected void btnActualizarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                Response.Write(
                    "<script>alert('Ingrese el ID del usuario.');</script>"
                );

                return;
            }

            int id = Convert.ToInt32(txtIdUsuario.Text);

            string cedula = txtCedulaUsuario.Text;
            string nombre = txtNombreUsuario.Text;
            string correo = txtCorreoUsuario.Text;

            int resultado = logica_usuario.ActualizarUsuario(
                id,
                cedula,
                nombre,
                correo
            );

            if (resultado > 0)
            {
                Response.Write(
                    "<script>alert('Usuario actualizado correctamente');</script>"
                );

                txtIdUsuario.Text = "";
                txtCedulaUsuario.Text = "";
                txtNombreUsuario.Text = "";
                txtCorreoUsuario.Text = "";

                CargarUsuarios();
                CargarUsuariosTabla();
            }
        }

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                Response.Write(
                    "<script>alert('Ingrese el ID del usuario.');</script>"
                );

                return;
            }

            int id = Convert.ToInt32(txtIdUsuario.Text);

            logica_usuario.BorrarReciclajesUsuario(id);

            int resultado = logica_usuario.BorrarUsuario(id);

            if (resultado > 0)
            {
                Response.Write(
                    "<script>alert('Usuario eliminado correctamente');</script>"
                );

                txtIdUsuario.Text = "";

                CargarUsuarios();
                CargarUsuariosTabla();
                CargarReciclajes();
                CargarEstadistica();
            }
            else
            {
                Response.Write(
                    "<script>alert('No se pudo eliminar el usuario.');</script>"
                );
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            int usuario = Convert.ToInt32(ddlUsuario.SelectedValue);
            int tipo = Convert.ToInt32(ddlMaterial.SelectedValue);
            decimal cantidad = Convert.ToDecimal(txtCantidad.Text);
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);

            int resultado = logica_reciclaje.AgregarReciclaje(
                usuario,
                tipo,
                cantidad,
                fecha
            );

            if (resultado > 0)
            {
                Response.Write(
                    "<script>alert('Reciclaje registrado correctamente');</script>"
                );

                txtCantidad.Text = "";
                txtFecha.Text = "";
                ddlUsuario.SelectedIndex = 0;
                ddlMaterial.SelectedIndex = 0;

                CargarReciclajes();
                CargarEstadistica();
            }
        }

        private void CargarReciclajes()
        {
            List<cls_reciclaje> reciclajes =
                logica_reciclaje.ObtenerReciclajes();

            gvReciclajes.DataSource = reciclajes;
            gvReciclajes.DataBind();
        }

        private void CargarEstadistica()
        {
            gvEstadistica.DataSource =
                logica_reciclaje.ObtenerEstadistica();

            gvEstadistica.DataBind();
        }
    }
}