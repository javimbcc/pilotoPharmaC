using Microsoft.AspNetCore.Mvc;
using Npgsql;
using pilotoPharma.Models;
using pilotoPharma.Models.Conexiones;
using pilotoPharma.Models.Consultas;
using pilotoPharma.Models.DTOs;
using pilotoPharma.Utils;
using System.Diagnostics;

namespace pilotoPharma.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ConexionPostgreSQL conexionPostgreSQL)
        {
            System.Console.WriteLine("Entra en Index");

            //CONSTANTES
            const string HOST = VariablesConexionPostgreSQL.HOST;
            const string PORT = VariablesConexionPostgreSQL.PORT;
            const string USER = VariablesConexionPostgreSQL.USER;
            const string PASS = VariablesConexionPostgreSQL.PASS;
            const string DB = VariablesConexionPostgreSQL.DB;

            //Hacemos la variable de conexion y el estado de la misma junto con la lista de los productos
            var estadoGenerada = "";
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            List<ProductoDTO> listProductosDTO = new List<ProductoDTO>();

            //Hacemos la conexion
            System.Console.WriteLine("GENERA LA CONEXION");
            conexionGenerada = conexionPostgreSQL.GeneraConexion(HOST, PORT, DB, USER, PASS);
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("Estado de la conexión: " + estadoGenerada);
            //Hacemos la insercion antes de la consulta patra poder ver los resultados por pantalla
            ConsultasPostgreSQLcs.InsertarProductos(conexionGenerada);

            //Se realiza la consulta y se guarda una lista de ProductosDTO
            listProductosDTO = ConsultasPostgreSQLcs.ListarProductos(conexionGenerada);
            int cont = listProductosDTO.Count();
            //Listamos los productos

            for (int i = 0; i < listProductosDTO.Count; i++)
            {
                System.Console.WriteLine("[HomeController] Lista Productos: " + "md_uuid: "+listProductosDTO[i].md_uuid + " "+"md_fch: " + listProductosDTO[i].md_fch + " " + "id_producto: " +listProductosDTO[i].id_producto + " " + "cod_producto: " +listProductosDTO[i].cod_producto + " " + "nombre_producto: " +listProductosDTO[i].nombre_producto + " " + "tipo_producto_origen: " +listProductosDTO[i].tipo_producto_origen + " " + "tipo_producto_clase: " + listProductosDTO[i].tipo_producto_clase + " " + "des_producto: " +listProductosDTO[i].des_producto + " " + "fch_alta_producto: " +listProductosDTO[i].fch_alta_producto + " " + "fch_baja_producto: " +listProductosDTO[i].fch_baja_producto);
            }
            System.Console.WriteLine("CONEXION CERRADA");
            conexionGenerada.Close();
            return View();
        }
    }
}