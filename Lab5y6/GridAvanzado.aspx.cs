using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaDatos.Entidades;

namespace Lab5y6
{
    public partial class GridAvanzado : System.Web.UI.Page
    {
        CapaDatos.ActualizarBD objGestion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaCarro();
            }
        }

        void cargaCarro()
        {

            DataTable datosCarro = new DataTable();
            objGestion = new CapaDatos.ActualizarBD();
            datosCarro = objGestion.cargarCarro();

            if (datosCarro.Rows.Count>0)
            {
                gridCarro.DataSource = datosCarro;
                gridCarro.DataBind();
            }
            else
            {
                datosCarro.Rows.Add(datosCarro.NewRow());
                gridCarro.DataSource = datosCarro;
                gridCarro.DataBind();
                gridCarro.Rows[0].Cells.Clear();
                gridCarro.Rows[0].Cells.Add(new TableCell());
                gridCarro.Rows[0].Cells[0].ColumnSpan = datosCarro.Columns.Count;
                gridCarro.Rows[0].Cells[0].Text = "No hay datos que mostrar";
                gridCarro.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        void mostrarMensaje(string txtMensaje, bool Tipo)
        {
            if (Tipo)
            {
                lblExitoso.Text = txtMensaje;
                lblError.Text = "";
            }
            else
            {
                lblExitoso.Text = "";
                lblError.Text = txtMensaje;
            }

        }

        protected void gridCarro_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objGestion = new CapaDatos.ActualizarBD();
            Carro objCarro = new Carro();
            objCarro.idCarro = Convert.ToInt32((gridCarro.DataKeys[e.RowIndex].Value.ToString()));
            objGestion.eliminarCarro(objCarro);
            gridCarro.EditIndex = -1;
            cargaCarro();
            mostrarMensaje("Se eliminó con éxito", true);
        }

        protected void gridCarro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("New"))
            {
                objGestion = new CapaDatos.ActualizarBD();
                Carro objCarro = new Carro();
                objCarro.idCarro = Convert.ToInt32((gridCarro.FooterRow.FindControl("txtidCarroPie") as TextBox).Text.Trim());
                objCarro.Marca = (gridCarro.FooterRow.FindControl("txtMarcaPie") as TextBox).Text.Trim();
                objCarro.Modelo = (gridCarro.FooterRow.FindControl("txtModeloPie") as TextBox).Text.Trim();
                objCarro.Pais = (gridCarro.FooterRow.FindControl("txtPaisPie") as TextBox).Text.Trim();
                objCarro.Costo = Convert.ToDouble((gridCarro.FooterRow.FindControl("txtCostoPie") as TextBox).Text.Trim());
                int resultado = objGestion.registrarCarro(objCarro);

                if (resultado == 1)
                {
                    cargaCarro();
                    mostrarMensaje("Se registró con éxito", true);
                }
                else
                {
                    mostrarMensaje("Hubo un error al registrar el carro", false);
                }

            }
        }

        protected void gridCarro_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridCarro.EditIndex = e.NewEditIndex;
            cargaCarro();
        }

        protected void gridCarro_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCarro.EditIndex = -1;
            cargaCarro();
        }

        protected void gridCarro_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
                objGestion = new CapaDatos.ActualizarBD();
                Carro objCarro = new Carro();
                objCarro.idCarro = Convert.ToInt32((gridCarro.Rows[e.RowIndex].FindControl("txtidCarro") as TextBox).Text.Trim());
                objCarro.Marca = (gridCarro.Rows[e.RowIndex].FindControl("txtMarca") as TextBox).Text.Trim();
                objCarro.Modelo = (gridCarro.Rows[e.RowIndex].FindControl("txtModelo") as TextBox).Text.Trim();
                objCarro.Pais = (gridCarro.Rows[e.RowIndex].FindControl("txtPais") as TextBox).Text.Trim();
                objCarro.Costo = Convert.ToDouble((gridCarro.Rows[e.RowIndex].FindControl("txtCosto") as TextBox).Text.Trim());
                int resultado = objGestion.actualizarCarro(objCarro);
                gridCarro.EditIndex = -1;
                if (resultado == 1)
                {
                    cargaCarro();
                    mostrarMensaje("Se actualizó con éxito", true);
                }
                else
                {
                    mostrarMensaje("Hubo un error al actualizar el carro", false);
                }
           
        }
    }
}