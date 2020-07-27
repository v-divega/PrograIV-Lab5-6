using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaDatos.Entidades;
using System.Configuration;

namespace CapaDatos
{
  public class UpdateBD
    {

        SqlConnection conexion; //me permite la conexion
        SqlCommand comando; //me permite mandar comandos a la BD
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionFerreteria"].ConnectionString;

        public List<Disponible> listadoDisponible()
        {

            SqlDataReader leerDatos;

            List<Disponible> listaRetorno;


            conexion = new SqlConnection();

            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["conexionFerreteria"].ConnectionString;



            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "Select * from Disponible";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandTimeout = 0;


            conexion.Open();


            leerDatos = comando.ExecuteReader();


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
        public bool ActualizarHerramienta(Herramienta objHerramienta)
        {
            int controlAfectado = -1;
            bool respuesta = false;

            using (SqlConnection conxion = new SqlConnection(cadenaConexion))
            {
                comando = new SqlCommand();
                comando.Connection = conxion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE Herramienta SET CodHerramienta = @CodHerramienta, Nombre = @Nombre, Disponible = @Disponible, Cantidad = @Cantidad WHERE CodHerramienta = @CodHerramienta ";

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
    }
}
