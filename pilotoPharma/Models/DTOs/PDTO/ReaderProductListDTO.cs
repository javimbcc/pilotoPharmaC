using Npgsql;

namespace pilotoPharma.Models.DTOs.PDTO
{
    public class ReaderProductListDTO
    {
            public static List<ProductoDTO> ReaderProductDTO(NpgsqlDataReader resultadoConsulta)
            {
                List<ProductoDTO> listProductos = new List<ProductoDTO>();
                while (resultadoConsulta.Read())
                {
                listProductos.Add(new ProductoDTO(
                        
                        resultadoConsulta[0].ToString(),
                        resultadoConsulta[1].ToString(),
                        resultadoConsulta[2].ToString(),
                        resultadoConsulta[3].ToString(),
                        resultadoConsulta[4].ToString(),
                        resultadoConsulta[5].ToString(),
                        resultadoConsulta[6].ToString(),
                        resultadoConsulta[7].ToString(),
                        resultadoConsulta[8].ToString()
                        )
                        );

                }
                return listProductos;
            }
        
    }
}
