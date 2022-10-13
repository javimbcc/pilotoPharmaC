namespace pilotoPharma.Models.DTOs
{
    public class ProductoDTO
    {
        public string? md_uuid { get; private set; }
        public string? md_fch { get; private set; }
        public string? id_producto { get; private set; }
        public string? cod_producto { get; private set; }
        public string? nombre_producto { get; private set; }
        public string? tipo_producto_origen { get; private set; }
        public string? tipo_producto_clase { get; private set; }
        public string? des_producto { get; private set; }
        public string? fch_alta_producto { get; private set; }
        public string? fch_baja_producto { get; private set; }


        //Constructor
        public ProductoDTO(string Md_uuid, string Md_fch, string Id_producto, string Cod_producto,
            string Nombre_producto, string Tipo_producto_origen, string Tipo_producto_clase, string Fch_alta_producto, string Fch_baja_producto)
        {
            md_uuid = Md_uuid;
            md_fch = Md_fch;
            id_producto = Id_producto;
            cod_producto = Cod_producto;
            nombre_producto = Nombre_producto;
            tipo_producto_origen = Tipo_producto_origen;
            tipo_producto_clase = Tipo_producto_clase;
            fch_alta_producto = Fch_alta_producto;
            fch_baja_producto = Fch_baja_producto;

        }

    }
}
