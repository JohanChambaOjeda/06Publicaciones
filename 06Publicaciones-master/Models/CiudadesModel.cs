using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _06Publicaciones.config;
using System.Data.SqlClient;

namespace _06Publicaciones.Models
{
    public class CiudadesModel
    {
        public int IdCiudad { get; set; }
        public string Detalle { get; set; }
        public int idPais { get; set; }

        public DataTable todosconrelacion()
        {
            var cadena = "SELECT Ciudades.IdCiudad, Ciudades.Detalle as Ciudad, Paises.IdPais, Paises.Detalle AS 'Pais' FROM Ciudades INNER JOIN Paises ON Ciudades.idPais = Paises.IdPais";
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    SqlDataAdapter adaptador = new SqlDataAdapter(cadena, cn);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al obtener ciudades.");
                    return null;
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener ciudades.");
                    return null;
                }
            }
        }

        public DataTable ObtenerCiudadPorId(int idCiudad)
        {
            var cadena = "SELECT Ciudades.IdCiudad, Ciudades.Detalle as Ciudad, Ciudades.idPais FROM Ciudades WHERE IdCiudad = @IdCiudad";
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(cadena, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdCiudad", idCiudad);
                        SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                        DataTable tabla = new DataTable();
                        adaptador.Fill(tabla);
                        return tabla;
                    }
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al obtener la ciudad.");
                    return null;
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener la ciudad.");
                    return null;
                }
            }
        }

        public bool ActualizarCiudad(int idCiudad, string detalle, int idPais)
        {
            var cadena = "UPDATE Ciudades SET Detalle = @Detalle, idPais = @idPais WHERE IdCiudad = @IdCiudad";
            using (var cn = Conexion.GetConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(cadena, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdCiudad", idCiudad);
                        cmd.Parameters.AddWithValue("@Detalle", detalle);
                        cmd.Parameters.AddWithValue("@idPais", idPais);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (SqlException ex)
                {
                    ErrorHandler.ManejarErrorSql(ex, "Error al actualizar la ciudad.");
                    return false;
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error al actualizar la ciudad.");
                    return false;
                }
            }
        }
    }
}