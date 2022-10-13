using Npgsql;

namespace pilotoPharma.Models.Conexiones
{
    public class ConexionPostgreSQL
    {
        //creamos el metodo para hacer la conexion a la base de datos
        public NpgsqlConnection GeneraConexion(string host, string port,
            string db, string user, string pass)
        {
            System.Console.WriteLine("Entra en GeneraConexion");

            //Creamos la conexion
            NpgsqlConnection conexion = new NpgsqlConnection();
            var datosConexion = "Server=" + host + "; Port=" + port + "; User Id=" + user + "; Password=" + pass + "; Database=" + db;
            System.Console.WriteLine(datosConexion);
            var estado = "";
            if (!string.IsNullOrWhiteSpace(datosConexion))
            {
                try
                {
                    conexion = new NpgsqlConnection(datosConexion);
                    conexion.Open();
                    //recogemos el estado
                    estado = conexion.State.ToString();
                    System.Console.WriteLine(" Estado conexión: " + estado);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Error de conexion:" + e);
                    conexion.Close();
                }
            }

            return conexion;

        }

    }
}
