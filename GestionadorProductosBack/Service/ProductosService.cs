using GestionadorProductosBack.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GestionadorProductosBack.Service
{
    public class ProductosService
    {
        private readonly IConfiguration _Configuration;
        private readonly string cadenaSql;

        public ProductosService(IConfiguration configuration)
        {
            _Configuration = configuration;
            cadenaSql = _Configuration.GetConnectionString("CadenaSQL")!;
        }

        public async Task<List<Productos>> ConsultarProductos()
        {
            string query = "SP_ConsultarProductos";

            using (var con = new SqlConnection(cadenaSql))
            {
                var lista = await con.QueryAsync<Productos>(query,commandType:CommandType.StoredProcedure);
                return lista.ToList();
            }
        }

        public async Task<List<Productos>> ConsultarProducto(string Nombre)
        {
            string query = "SP_ConsultarProducto";
            var Parametros = new DynamicParameters();
            Parametros.Add("@IN_Nombre", Nombre, dbType: DbType.String);

            using (var con = new SqlConnection(cadenaSql))
            {
                var producto = await con.QueryAsync<Productos>(query, Parametros, commandType: CommandType.StoredProcedure);
                //var producto = await con.QueryFirstOrDefaultAsync<Productos>(query, Parametros, commandType: CommandType.StoredProcedure);
                return producto.ToList();
            }
        }

        public async Task<int> RegistrarProducto(Productos objProductos)
        {
            string query = "SP_RegistrarProducto";
            var Parametros = new DynamicParameters();
            Parametros.Add("@IN_Nombre", objProductos.Nombre, dbType: DbType.String);
            Parametros.Add("@IN_Precio", objProductos.Precio, dbType: DbType.Currency);
            Parametros.Add("@IN_Cantidad", objProductos.Cantidad, dbType: DbType.Int32);

            using (var con = new SqlConnection(cadenaSql))
            {
                var producto = await con.ExecuteScalarAsync<int>(query, Parametros, commandType: CommandType.StoredProcedure);
                return producto;
            }
        }

        public async Task<int> ModificarProducto(Productos objProductos)
        {
            string query = "SP_ModificarProducto";
            var Parametros = new DynamicParameters();
            Parametros.Add("@IN_Id", objProductos.Id, dbType: DbType.Int32);
            Parametros.Add("@IN_Nombre", objProductos.Nombre, dbType: DbType.String);
            Parametros.Add("@IN_Precio", objProductos.Precio, dbType: DbType.Currency);
            Parametros.Add("@IN_Cantidad", objProductos.Cantidad, dbType: DbType.Int32);
            

            using (var con = new SqlConnection(cadenaSql))
            {
                var producto = await con.ExecuteScalarAsync<int>(query, Parametros, commandType: CommandType.StoredProcedure);
                return producto;
            }
        }

        public async Task<int> EliminarProducto(int Id)
        {
            string query = "SP_EliminarProducto";
            var Parametros = new DynamicParameters();
            Parametros.Add("@IN_Id", Id, dbType: DbType.Int32);

            using (var con = new SqlConnection(cadenaSql))
            {
                var producto = await con.ExecuteAsync(query, Parametros, commandType: CommandType.StoredProcedure);
                return producto;
            }
        }
    }
}
