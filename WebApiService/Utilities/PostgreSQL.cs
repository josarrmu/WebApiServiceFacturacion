using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebApiService.Models;
using System.Data.SqlClient;
using System.Data;

namespace DockerTest1.Utilities
{
    public class PostgreSQL
    {
        SqlConnection connection = new SqlConnection();
        public PostgreSQL(IConfiguration configuration)
      {
            string connectionString;
        connectionString = configuration.GetConnectionString("postgresql");
            //connectionString = configuration.GetConnectionString("postgresql");
            connection = new SqlConnection(connectionString);
    }
        public bool OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open) return true; //Avoid opening again.
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw;
            }

            if (connection.State == System.Data.ConnectionState.Open)
                return true;
            return false;
        }

        //    NpgsqlConnection connection;
        //    public PostgreSQL(IConfiguration configuration)
        //    {
        //        string connectionString;
        //        connectionString = configuration.GetConnectionString("postgresqlnodocker");
        //        //connectionString = configuration.GetConnectionString("postgresql");
        //        connection = new NpgsqlConnection(connectionString);
        //    }
        //    public bool OpenConnection()
        //    {
        //        if (connection.State == System.Data.ConnectionState.Open) return true; //Avoid opening again.
        //        try
        //        {
        //            connection.Open();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }

        //        if (connection.State == System.Data.ConnectionState.Open)
        //            return true;
        //        return false;
        //    }
        //    public bool InsertPerson(string nombre, string apellido)
        //    {
        //        try
        //        {
        //            var command = connection.CreateCommand();
        //            command.CommandText = string.Format("INSERT INTO persona (nombre, apellido) VALUES ('{0}', '{1}');", nombre, apellido);
        //            command.ExecuteNonQuery();
        //            return true;

        //        }
        //        catch(Exception ex)
        //        {
        //            throw;
        //        }
        //    }
        //    public List<Person> GetAllPeople()
        //    {
        //        List<Person> people = new List<Person>();
        //        try
        //        {
        //            var command = connection.CreateCommand();
        //            command.CommandText = "SELECT* FROM public.persona";
        //            var reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                people.Add(new Person
        //                {
        //                    Id = (int)reader["id"],
        //                    Nombre= (string)reader["nombre"],
        //                    Apellido= (string)reader["apellido"]
        //                }) ;
        //            }

        //            return people;

        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }

        //}
        //    public bool DeletePerson(int id)
        //    {
        //        try
        //        {
        //            var command = connection.CreateCommand();
        //            command.CommandText = string.Format("DELETE FROM persona where id= {0};", id);
        //            if(command.ExecuteNonQuery()==-1) return false;
        //            return true;

        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }
        public bool InsertProducto(Producto produto)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_PRODUCTOS", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 2);
                cmd.Parameters.AddWithValue("@CODIGO_PRODUCTO", produto.Codigo_Producto);
                cmd.Parameters.AddWithValue("@NOMBRE_PRODUCTO", produto.Nombre_Producto);
                cmd.Parameters.AddWithValue("@DESCRIPCION_PRODUCTO", produto.Descripcion_Producto);
                cmd.Parameters.AddWithValue("@CANTIDAD_STOCK", produto.Cantidad_Stock);
                cmd.Parameters.AddWithValue("@PRECIO", produto.Precio);
                cmd.Parameters.AddWithValue("@ID_CATEGORIA", produto.Id_Categoria);
                cmd.Parameters.AddWithValue("@ID_PROVEEDOR", produto.Id_Proveedor);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool UpdateProducto(Producto produto)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_PRODUCTOS", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 3);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", produto.Id_Producto);
                cmd.Parameters.AddWithValue("@CODIGO_PRODUCTO", produto.Codigo_Producto);
                cmd.Parameters.AddWithValue("@NOMBRE_PRODUCTO", produto.Nombre_Producto);
                cmd.Parameters.AddWithValue("@DESCRIPCION_PRODUCTO", produto.Descripcion_Producto);
                cmd.Parameters.AddWithValue("@CANTIDAD_STOCK", produto.Cantidad_Stock);
                cmd.Parameters.AddWithValue("@PRECIO", produto.Precio);
                cmd.Parameters.AddWithValue("@ID_CATEGORIA", produto.Id_Categoria);
                cmd.Parameters.AddWithValue("@ID_PROVEEDOR", produto.Id_Proveedor);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool DeleteProducto(int id)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_PRODUCTOS", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 4);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public List<Producto> GetProductos(int? idProducto)
        {
            List<Producto> productos = new List<Producto>();
            SqlCommand cmd = new SqlCommand("CRUD_PRODUCTOS", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROCTYPE", 1);
            if (idProducto != null)
                cmd.Parameters.Add(new SqlParameter("@ID_PRODUCTO", idProducto));
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productos.Add(new Producto
                {
                    Id_Producto = (int)reader["ID_PRODUCTO"],
                    Codigo_Producto = (string)reader["CODIGO_PRODUCTO"],
                    Nombre_Producto = (string)reader["NOMBRE_PRODUCTO"],
                    Descripcion_Producto = (string)reader["DESCRIPCION_PRODUCTO"],
                    Cantidad_Stock = (int)reader["CANTIDAD_STOCK"],
                    Precio = (double)reader["PRECIO"],
                    Id_Categoria = (int)reader["ID_CATEGORIA"],
                    Id_Proveedor = (int)reader["ID_PROVEEDOR"]
                });
            }

            return productos;

        }

        public List<Person> GetAllPeople()
        {
            List<Person> people = new List<Person>();
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT* FROM public.persona";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    people.Add(new Person
                    {
                        Id = (int)reader["id"],
                        Nombre = (string)reader["nombre"],
                        Apellido = (string)reader["apellido"]
                    });
                }

                return people;

            }
            catch (Exception e)
            {
                throw;
            }

        }

        ///**   detalle factura
        ///
        public bool InsertDetalleFactura(DetalleFacturaDTO detalle)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_DETALLE_FACTURA", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 2);
                cmd.Parameters.AddWithValue("@ID_FACTURA", detalle.Id_Factura);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", detalle.Id_Producto);
                cmd.Parameters.AddWithValue("@CANTIDAD_PRODUCTO", detalle.Catidad_Producto);
                cmd.Parameters.AddWithValue("@PRECIO_PRODUCTO", detalle.PrecioProducto);


                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool UpdateDetalleFactura(DetalleFacturaDTO detalle)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_DETALLE_FACTURA", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 3);
                cmd.Parameters.AddWithValue("@ID_DETALLE_FACTURA", detalle.Id_Detalle);
                cmd.Parameters.AddWithValue("@ID_FACTURA", detalle.Id_Factura);
                cmd.Parameters.AddWithValue("@ID_PRODUCTO", detalle.Id_Producto);
                cmd.Parameters.AddWithValue("@CANTIDAD_PRODUCTO", detalle.Catidad_Producto);
                cmd.Parameters.AddWithValue("@PRECIO_PRODUCTO", detalle.PrecioProducto);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool DeleteDetalleFactura(int id)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_DETALLE_FACTURA", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 4);
                cmd.Parameters.AddWithValue("@ID_DETALLE_FACTURA", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public List<DetalleFacturaDTO> GetDetalles(int? idDetalle)
        {
            List<DetalleFacturaDTO> productos = new List<DetalleFacturaDTO>();
            SqlCommand cmd = new SqlCommand("CRUD_DETALLE_FACTURA", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROCTYPE", 5);
            if (idDetalle != null)
                cmd.Parameters.Add(new SqlParameter("@ID_DETALLE_FACTURA", idDetalle));
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productos.Add(new DetalleFacturaDTO
                {
                    Id_Detalle = (int)reader["ID_DETALLE_FACTURA"],
                    Id_Factura = (int)reader["ID_FACTURA"],
                    Id_Producto = (int)reader["ID_PRODUCTO"],
                    Catidad_Producto = (int)reader["CANTIDAD_PRODUCTO"],
                    PrecioProducto = (decimal)reader["PRECIO_PRODUCTO"]

                });
            }

            return productos;

        }

        /// <summary>
        /// FACTURA CRUD
        /// </summary>
        /// <param name="detalle"></param>
        /// <returns></returns>

        public bool InsertarFactura(FacturaDTO factura)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_FACTURA", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 2);

                cmd.Parameters.AddWithValue("@CODIGO_FACTURA", factura.Codigo_Factura);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", factura.Id_Cliente);
                cmd.Parameters.AddWithValue("@FECHA_CREACION", factura.Fecha_Creacion);
                cmd.Parameters.AddWithValue("@ID_ESTADO_FACTURA", factura.Id_EstadoFactura);
                cmd.Parameters.AddWithValue("@ID_MEDIO_PAGO", factura.Id_EstadoFactura);


                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool UpdateFactura(FacturaDTO factura)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_FACTURA", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 3);
                cmd.Parameters.AddWithValue("@ID_FACTURA", factura.Id_Factura);
                cmd.Parameters.AddWithValue("@CODIGO_FACTURA", factura.Codigo_Factura);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", factura.Id_Cliente);
                cmd.Parameters.AddWithValue("@FECHA_CREACION", factura.Fecha_Creacion);
                cmd.Parameters.AddWithValue("@ID_ESTADO_FACTURA", factura.Id_EstadoFactura);
                cmd.Parameters.AddWithValue("@ID_MEDIO_PAGO", factura.Id_EstadoFactura);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool DeleteFactura(int id)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_FACTURA", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 4);
                cmd.Parameters.AddWithValue("@ID_FACTURA", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public List<FacturaDTO> GetFacturas(int? idDetalle)
        {
            List<FacturaDTO> productos = new List<FacturaDTO>();
            SqlCommand cmd = new SqlCommand("CRUD_FACTURA", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROCTYPE", 1);
            if (idDetalle != null)
                cmd.Parameters.Add(new SqlParameter("@ID_FACTURA", idDetalle));
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productos.Add(new FacturaDTO
                {
                    Id_Factura = (int)reader["ID_FACTURA"],
                    Codigo_Factura = (string)reader["CODIGO_FACTURA"],
                    Id_Cliente = (int)reader["ID_CLIENTE"],
                    Fecha_Creacion = (DateTime)reader["FECHA_CREACION"],
                    Id_EstadoFactura = (int)reader["ID_ESTADO_FACTURA"],
                    Id_MedioPago = (int)reader["ID_MEDIO_PAGO"]

                });
            }

            return productos;

        }

        /// <summary>
        /// CLIENTE CRUD
        /// </summary>
        /// <param name="detalle"></param>
        /// <returns></returns>
        /// 
        public bool InsertarCliente(Cliente cliente)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_CLIENTES", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 2);
                                
                cmd.Parameters.AddWithValue("@IDENTIFICACION_CLIENTE", cliente.Identificacion_Cliente);
                cmd.Parameters.AddWithValue("@NOMBRE_CLIENTE", cliente.NombreCliente);
                cmd.Parameters.AddWithValue("@DIRECCION_CLIENTE", cliente.Direccion);
                cmd.Parameters.AddWithValue("@TELEFONO_CLIENTE", cliente.Telefono);
                cmd.Parameters.AddWithValue("@EMAIL", cliente.Correo);
                cmd.Parameters.AddWithValue("@ID_TIPO_IDENTIFICACION", cliente.Id_TipoIDentificacion);
                cmd.Parameters.AddWithValue("@EDAD", cliente.Edad);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool UpdateCliente(Cliente cliente)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_CLIENTES", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 3);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", cliente.Id_Cliente);
                cmd.Parameters.AddWithValue("@IDENTIFICACION_CLIENTE", cliente.Identificacion_Cliente);
                cmd.Parameters.AddWithValue("@NOMBRE_CLIENTE", cliente.NombreCliente);
                cmd.Parameters.AddWithValue("@DIRECCION_CLIENTE", cliente.Direccion);
                cmd.Parameters.AddWithValue("@TELEFONO_CLIENTE", cliente.Telefono);
                cmd.Parameters.AddWithValue("@EMAIL", cliente.Correo);
                cmd.Parameters.AddWithValue("@ID_TIPO_IDENTIFICACION", cliente.Id_TipoIDentificacion);
                cmd.Parameters.AddWithValue("@EDAD", cliente.Edad);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool DeleteCliente(int id)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_CLIENTES", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 4);
                cmd.Parameters.AddWithValue("@ID_CLIENTE", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public List<Cliente> GetAllClientes(int? idCliente)
        {
            List<Cliente> productos = new List<Cliente>();
            SqlCommand cmd = new SqlCommand("CRUD_CLIENTES", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROCTYPE", 1);
            if (idCliente != null)
                cmd.Parameters.Add(new SqlParameter("@ID_CLIENTE", idCliente));
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productos.Add(new Cliente
                {

                    Id_Cliente= (int) reader["ID_CLIENTE"],
                    Identificacion_Cliente = (string)reader["IDENTIFICACION_CLIENTE"],
                    NombreCliente = (string)reader["NOMBRE_CLIENTE"],
                    Direccion = (string)reader["DIRECCION_CLIENTE"],
                    Telefono =Convert.ToInt64((decimal)reader["TELEFONO_CLIENTE"]),
                    Correo = (string)reader["EMAIL"],
                    Id_TipoIDentificacion = (int)reader["ID_TIPO_IDENTIFICACION"],
                    Edad=(int)reader["EDAD"]
                });
            }

            return productos;

        }

        public bool InsertarVendedor(Vendedor cliente)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_VENDEDOR", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 2);

                cmd.Parameters.AddWithValue("@CODIGO_VENDEDOR", cliente.CodigoVendedro);
                cmd.Parameters.AddWithValue("@ID_TIPO_IDENTIFICACION", cliente.Id_TipoIdentificacion);
                cmd.Parameters.AddWithValue("@NUMERO_IDENTIFICACION", cliente.NumeroIdentificacion);
                cmd.Parameters.AddWithValue("@NOMBRE_VENDEDOR", cliente.Nombre_Vendedor);
                
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool UpdateVendedor(Vendedor cliente)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_VENDEDOR", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 3);
                cmd.Parameters.AddWithValue("@ID_VENDEDOR", cliente.Id_Vendedor);
                cmd.Parameters.AddWithValue("@CODIGO_VENDEDOR", cliente.CodigoVendedro);
                cmd.Parameters.AddWithValue("@ID_TIPO_IDENTIFICACION", cliente.Id_TipoIdentificacion);
                cmd.Parameters.AddWithValue("@NUMERO_IDENTIFICACION", cliente.NumeroIdentificacion);
                cmd.Parameters.AddWithValue("@NOMBRE_VENDEDOR", cliente.Nombre_Vendedor);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool DeleteVendedor(int id)
        {
            try
            {


                SqlCommand cmd = new SqlCommand("CRUD_VENDEDOR", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PROCTYPE", 4);
                cmd.Parameters.AddWithValue("@ID_VENDEDOR", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public List<Vendedor> GetAllVendedores(int? idVendedor)
        {
            List<Vendedor> productos = new List<Vendedor>();
            SqlCommand cmd = new SqlCommand("CRUD_VENDEDOR", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PROCTYPE", 1);
            if (idVendedor != null)
                cmd.Parameters.Add(new SqlParameter("@ID_VENDEDOR", idVendedor));
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productos.Add(new Vendedor
                {

                    Id_Vendedor = (int)reader["ID_VENDEDOR"],
                    CodigoVendedro = (string)reader["CODIGO_VENDEDOR"],
                    Id_TipoIdentificacion = (int)reader["ID_TIPO_IDENTIFICACION"],
                    NumeroIdentificacion = Convert.ToString((decimal)reader["NUMERO_IDENTIFICACION"]),
                    Nombre_Vendedor = (string)reader["NOMBRE_VENDEDOR"]
                    
                });
            }

            return productos;

        }


    }
}
