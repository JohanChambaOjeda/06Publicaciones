using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using _06Publicaciones.config;

namespace _06Publicaciones.Models
{
    class PaisModel
    {
        public int IdPais { get; set; }
        public string Detalle { get; set; }


        public DataTable todos() {
            var cadena = "select * from paises";
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
                    ErrorHandler.ManejarErrorSql(ex, "Error al insertar el autor.");
                }
                catch (Exception ex)
                {
                    ErrorHandler.ManejarErrorGeneral(ex, "Error al insertar el autor.");
                }
                return null;
            }

        }

    }

    



    //leer todos
    // uno
}

/*
 USE [pubs]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudades](

[IdCiudad][int] IDENTITY(1, 1) NOT NULL,

[Detalle] [nvarchar](50) NULL,
	[idPais] [int] NULL,
 CONSTRAINT[PK_Ciudades] PRIMARY KEY CLUSTERED 
(
	[IdCiudad] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
) ON[PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](

[IdPais][int] IDENTITY(1, 1) NOT NULL,

[Detalle] [nvarchar](50) NULL,
 CONSTRAINT[PK_Paises] PRIMARY KEY CLUSTERED 
(
	[IdPais] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
) ON[PRIMARY]
GO
ALTER TABLE [dbo].[Ciudades]  WITH CHECK ADD  CONSTRAINT [FK_Ciudades_Paises] FOREIGN KEY([idPais])
REFERENCES[dbo].[Paises]([IdPais])
GO
ALTER TABLE [dbo].[Ciudades] CHECK CONSTRAINT[FK_Ciudades_Paises]
GO
 */