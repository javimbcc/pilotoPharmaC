using Npgsql;
using pilotoPharma.Models.DTOs;

namespace pilotoPharma.Models.Consultas
{
    public class ConsultasPostgreSQLcs
    {
        public static List<ProductoDTO> ListarProductos(NpgsqlConnection conexionGenerada)
        {
            System.Console.WriteLine("ENTRAMOS AL METODO LISTARPRODUCTOS");
            List<ProductoDTO> listProductos = new List<ProductoDTO>();
            try
            {
                System.Console.WriteLine("HACEMOS LA CONSULTA DE LISTAR PRODUCTOS");
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"dlk_operacional_productos\".\"opr_cat_productos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listProductos = DTOs.PDTO.ReaderProductListDTO.ReaderProductDTO(resultadoConsulta);
                int cont = listProductos.Count();
                System.Console.WriteLine(" Lista compuesta por: " + cont + " productos");
                System.Console.WriteLine("SALIMOS DE LA CONSULTA Y DEL METODO LISTAR PRODUCTOS");
                System.Console.WriteLine("-----------------------------------------------------");
                System.Console.WriteLine("CERRANDO LA CONEXION");
                conexionGenerada.Close();
                resultadoConsulta.Close();
            }
            catch (Exception e)
            {

                System.Console.WriteLine(" Error al ejecutar consulta de los productos: " + e);
                conexionGenerada.Close();

            }
            return listProductos;
        }

        public static void InsertarProductos(NpgsqlConnection conexionGenerada)
        {
            try
            {
                System.Console.WriteLine("ENTRAMOS AL METODO INSERTARPRODUCTOS");
                //Se define y ejecuta la consulta Select
                System.Console.WriteLine("HACEMOS LA INSERCION");
                NpgsqlCommand consulta = new NpgsqlCommand("INSERT INTO \"dlk_operacional_productos\".\"opr_cat_productos\" (md_uuid, cod_producto, nombre_producto, tipo_producto_origen, tipo_producto_clase, des_producto) VALUES ('adf131029022fch12345','hig_p_gelf_f','Gel de aceite de fresa, Farlane.','Propio','Higiene','Gel de aceite de fresa producido por marca propia Farlane.')",conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();
                System.Console.WriteLine("SALIMOS DE INSERTARPRODUCTOS");
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {
                System.Console.WriteLine("[INDEX] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }

        }
    }
}
