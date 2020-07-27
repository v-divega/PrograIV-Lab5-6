using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaDatos.Entidades;
using System.Configuration;
using System.Data;



namespace CapaDatos

{
    public class ActualizarBD
    {
        SqlConnection conexion; //me permite la conexion
        SqlCommand comando; //me permite mandar comandos a la BD
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionFerreteria"].ConnectionString;
        List<Factura> listadoItems; 
        public List<Disponible> listadoDisponible ()
        {

            SqlDataReader leerDatos;

            List<Disponible> listaRetorno;

            //crear la conexiom
            conexion = new SqlConnection();
            //conexion.ConnectionString = "Data Source=LAPTOP-6BUAEEM0;Initial Catalog=Ferreteria;Integrated Security=True";
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["conexionFerreteria"].ConnectionString;


            //configurar el comando
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "Select * from Disponible";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandTimeout = 0;

            //Abrir la conexion
            conexion.Open();

            //Ejecutar el comando
            leerDatos = comando.ExecuteReader();

            //Configurar la estructura
            listaRetorno = new List<Disponible>();
            while (leerDatos.Read())
            {
               
                Disponible objDisponible = new Disponible();
                objDisponible.numPalabra = leerDatos.GetInt32(0);
                objDisponible.Palabra = leerDatos.GetString(1);
                listaRetorno.Add(objDisponible);
            }

            return listaRetorno;

        }



        public bool registrarHerramienta(Herramienta objHerramienta)
        {
            int controlAfectado = -1;
            bool respuesta = false;

            using (SqlConnection conxion = new SqlConnection(cadenaConexion))
            {
                comando = new SqlCommand();
                comando.Connection = conxion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert into Herramienta (CodHerramienta, Nombre, Disponible, Cantidad)" +
                    "Values(@CodHerramienta, @Nombre, @Disponible, @Cantidad)";

                SqlParameter objParametro = new SqlParameter();
                objParametro.ParameterName = "@CodHerramienta";
                objParametro.SqlDbType = System.Data.SqlDbType.Int;
                objParametro.Value = objHerramienta.CodHerramienta;

                comando.Parameters.Add(objParametro);

                comando.Parameters.Add(new SqlParameter("@Nombre", objHerramienta.Nombre));

                comando.Parameters.Add(new SqlParameter("@Disponible", objHerramienta.Disponible));

                comando.Parameters.Add(new SqlParameter("@Cantidad", objHerramienta.Cantidad));

                conxion.Open();

                controlAfectado = comando.ExecuteNonQuery();
            }

            if (controlAfectado > 0)
            {
                respuesta = true;
            }

            return respuesta;
        }


        public List<Factura> listadoArticulos()
        {
            listadoItems = new List<Factura>();
            Factura objFactura = new Factura();
            objFactura = new Factura() { idFactura = 1, numLinea = 1, codProducto = "AX1", detProducto = "Martillo", cantProducto = 15, costUnitario = 7900, totalLinea = 8250 };
            listadoItems.Add(objFactura);
            objFactura = new Factura() { idFactura = 2, numLinea = 2, codProducto = "AX2", detProducto = "Broca", cantProducto = 100, costUnitario = 3000, totalLinea = 3500 };
            listadoItems.Add(objFactura);
            objFactura = new Factura() { idFactura = 3, numLinea = 3, codProducto = "AX3", detProducto = "Taladro", cantProducto = 30, costUnitario = 30000, totalLinea = 32350 };
            listadoItems.Add(objFactura);
            return listadoItems;
        }

        #region "Metodos CRUD"

        public DataTable cargarCarro()
        {
            DataTable objTabla = new DataTable();
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from Carro";
            comando.Connection = conexion;
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando);
            sqlAdaptador.Fill(objTabla);
            return objTabla;
        }

        public int registrarCarro(Carro objCarro)
        {
            int cantidadRegistros = -1;

            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Carro (idCarro, Marca, Modelo, Pais, Costo) Values (@idCarro, @Marca, @Modelo, @Pais, @Costo)";
                cmd.Parameters.Add(new SqlParameter("@idCarro", objCarro.idCarro));
                cmd.Parameters.Add(new SqlParameter("@Marca", objCarro.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", objCarro.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Pais", objCarro.Pais));
                cmd.Parameters.Add(new SqlParameter("@Costo", objCarro.Costo));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return cantidadRegistros;

        }
        public int actualizarCarro(Carro objCarro)
        {
            int cantidadRegistros = -1;
           
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Carro  SET idCarro = @idCarro, Marca = @Marca,  Modelo = @Modelo, Pais = @Pais, Costo = @Costo WHERE idCarro = @idCarro ";
                cmd.Parameters.Add(new SqlParameter("@idCarro", objCarro.idCarro));
                cmd.Parameters.Add(new SqlParameter("@Marca", objCarro.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", objCarro.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Pais", objCarro.Pais));
                cmd.Parameters.Add(new SqlParameter("@Costo", objCarro.Costo));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        public int eliminarCarro(Carro objCarro)
        {
            int cantidadRegistros = -1;
      
            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Carro WHERE idCarro = @idCarro";
                cmd.Parameters.Add(new SqlParameter("@idCarro", objCarro.idCarro));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); 
                sqlCon.Close();
            }

            return cantidadRegistros;
        }

        #endregion

    }





}
