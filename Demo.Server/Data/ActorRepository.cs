using Demo.Shared.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Demo.Server.Data
{
    public class ActorRepository
    {
        private readonly string _connectionString;
        public ActorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApplicationDbContext");
        }


        public List<Actor> ListarActores()
        {
            List<Actor> actores = new List<Actor>();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                conn = new SqlConnection(_connectionString);
                cmd = new SqlCommand("ListarActores", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", "123");
                conn.Open();

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Actor obj = new Actor();

                    obj.Nombre = dr["Nombre"].ToString();
                    obj.Biografia = dr["Biografia"].ToString();
                    obj.Id = Convert.ToInt32(dr["Id"].ToString());
                    obj.Foto = dr["Foto"].ToString();

                    actores.Add(obj);
                }
            }
            catch (Exception)
            {
                return actores;
            }

            return actores;
        }

        public async Task<string> InsertarActor(Actor actor)
        {
            string respuesta = null;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = new SqlConnection(_connectionString);
                cmd = new SqlCommand("I_U_D_Actor", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Trans", "I");

                cmd.Parameters.AddWithValue("@Nombre", actor.Nombre);
                cmd.Parameters.AddWithValue("@Biografia", actor.Biografia);
                cmd.Parameters.AddWithValue("@Foto", actor.Foto);
                cmd.Parameters.AddWithValue("@FechaNacimiento", actor.FechaNacimiento);


                SqlParameter output = new SqlParameter("@Result", SqlDbType.VarChar, 100);
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                respuesta = Convert.ToString(output.Value);
            }
            catch (Exception ex)
            {
                respuesta += ex.ToString();
            }
            finally
            {
                await conexion.CloseAsync();
            }
            return respuesta;
        }

        public async Task<string> ModificarActor(Actor actor)
        {
            string respuesta = null;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = new SqlConnection(_connectionString);
                cmd = new SqlCommand("I_U_D_Actor", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Trans", "U");

                cmd.Parameters.AddWithValue("@Id", actor.Id);
                cmd.Parameters.AddWithValue("@Nombre", actor.Nombre);
                cmd.Parameters.AddWithValue("@Biografia", actor.Biografia);
                cmd.Parameters.AddWithValue("@Foto", actor.Foto);
                cmd.Parameters.AddWithValue("@FechaNacimiento", actor.FechaNacimiento);


                SqlParameter output = new SqlParameter("@Result", SqlDbType.VarChar, 100);
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                respuesta = Convert.ToString(output.Value);
            }
            catch (Exception ex)
            {
                respuesta += ex.ToString();
            }
            finally
            {
                await conexion.CloseAsync();
            }
            return respuesta;
        }

        public async Task<string> EliminarActor(Actor actor)
        {
            string respuesta = null;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = new SqlConnection(_connectionString);
                cmd = new SqlCommand("I_U_D_Actor", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Trans", "D");

                cmd.Parameters.AddWithValue("@Id", actor.Id);


                SqlParameter output = new SqlParameter("@Result", SqlDbType.VarChar, 100);
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                await conexion.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                respuesta = Convert.ToString(output.Value);
            }
            catch (Exception ex)
            {
                respuesta += ex.ToString();
            }
            finally
            {
                await conexion.CloseAsync();
            }
            return respuesta;
        }

    }
}
