using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Sistema_Informacion.Models
{
    public class MantenimientoUsuario
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }

        public int Alta(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into usuarios(documento, tipodoc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro) values (@documento, @tipodoc, @nombre, @celular, @email, @genero, @aprendiz, @egresado, @areaformacion, @fechaegresado, @direccion, @barrio, @ciudad, @departamento, @fecharegistro)",con);

            comando.Parameters.Add("@documento", SqlDbType.VarChar);
            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters.Add("@aprendiz", SqlDbType.Bit);
            comando.Parameters.Add("@egresado", SqlDbType.Bit);
            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaegresado", SqlDbType.Date);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters.Add("@fecharegistro", SqlDbType.Date);

            comando.Parameters["@documento"].Value = usu.Documento;
            comando.Parameters["@tipodoc"].Value = usu.TipoDocumento;
            comando.Parameters["@nombre"].Value = usu.Nombre;
            comando.Parameters["@celular"].Value = usu.Celular;
            comando.Parameters["@email"].Value = usu.Email;      
            comando.Parameters["@genero"].Value = usu.Genero;    
            comando.Parameters["@aprendiz"].Value = usu.Aprendiz;
            comando.Parameters["@egresado"].Value = usu.Egresado;
            comando.Parameters["@areaformacion"].Value = usu.AreaFormacion;
            comando.Parameters["@fechaegresado"].Value = usu.FechaEgresado;
            comando.Parameters["@direccion"].Value = usu.Direccion;
            comando.Parameters["@barrio"].Value = usu.Barrio;
            comando.Parameters["@ciudad"].Value = usu.Ciudad;
            comando.Parameters["@departamento"].Value = usu.Departamento;
            comando.Parameters["@fecharegistro"].Value = usu.FechaEgresado;       
            
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public List<Usuario> RecuperarTodos()
        {
            Conectar();
            List<Usuario> usuarios = new List<Usuario>();

            SqlCommand com = new SqlCommand("select id, documento, tipodoc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {
                Usuario usu = new Usuario
                {
                    ID=Convert.ToInt32(registros["id"]),
                    Documento = registros["documento"].ToString(),
                    TipoDocumento = registros["tipodoc"].ToString(),
                    Nombre = registros["nombre"].ToString(),
                    Celular = registros["celular"].ToString(),
                    Email = registros["email"].ToString(),
                    Genero = registros["genero"].ToString(),
                    Aprendiz = Convert.ToInt32(registros["aprendiz"]),
                    Egresado = Convert.ToInt32(registros["egresado"]),
                    AreaFormacion = registros["areaformacion"].ToString(),
                    FechaEgresado = DateTime.Parse(registros["fechaegresado"].ToString()),
                    Direccion = registros["direccion"].ToString(),
                    Barrio = registros["barrio"].ToString(),
                    Ciudad = registros["ciudad"].ToString(),
                    Departamento = registros["departamento"].ToString(),
                    FechaRegistro = DateTime.Parse(registros["fecharegistro"].ToString())
                };
                usuarios.Add(usu);
            }
            con.Close();
            return usuarios;
        }

        public Usuario Recuperar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select id, documento, tipodoc, nombre, celular, email, genero, aprendiz, egresado, areaformacion, fechaegresado, direccion, barrio, ciudad, departamento, fecharegistro from usuarios where id=@id", con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = id;
            con.Open();

            SqlDataReader registros = comando.ExecuteReader();
            Usuario usuarios = new Usuario();

            if (registros.Read())
            {
                usuarios.ID = Convert.ToInt32(registros["id"]);
                usuarios.Documento =registros["documento"].ToString();
                usuarios.TipoDocumento = registros["tipodoc"].ToString();
                usuarios.Nombre = registros["nombre"].ToString();
                usuarios.Celular =registros["celular"].ToString();
                usuarios.Email = registros["email"].ToString();
                usuarios.Genero = registros["genero"].ToString();
                usuarios.Aprendiz = Convert.ToInt32(registros["aprendiz"]);
                usuarios.Egresado = Convert.ToInt32(registros["egresado"]);
                usuarios.AreaFormacion = registros["areaformacion"].ToString();
                usuarios.FechaEgresado = DateTime.Parse(registros["fechaegresado"].ToString());
                usuarios.Direccion = registros["direccion"].ToString();
                usuarios.Barrio = registros["barrio"].ToString();
                usuarios.Ciudad = registros["ciudad"].ToString();
                usuarios.Departamento = registros["departamento"].ToString();
                usuarios.FechaRegistro = DateTime.Parse(registros["fechaegresado"].ToString());
            }
            con.Close();
            return usuarios;           
        }

        public int Modificar(Usuario usu)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update usuarios set tipodoc=@tipodoc, nombre=@nombre, celular=@celular, email=@email, genero=@genero, aprendiz=@aprendiz, egresado=@egresado, areaformacion=@areaformacion, fechaegresado=@fechaegresado, direccion=@direccion, barrio=@barrio, ciudad=@ciudad, departamento=@departamento, fecharegistro=@fecharegistro from usuarios where id=@id",con);

            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value = usu.ID;

            comando.Parameters.Add("@tipodoc", SqlDbType.VarChar);
            comando.Parameters["@tipodoc"].Value = usu.TipoDocumento;

            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = usu.Nombre;

            comando.Parameters.Add("@celular", SqlDbType.VarChar);
            comando.Parameters["@celular"].Value = usu.Celular;

            comando.Parameters.Add("@email", SqlDbType.VarChar);
            comando.Parameters["@email"].Value = usu.Email;

            comando.Parameters.Add("@genero", SqlDbType.VarChar);
            comando.Parameters["@genero"].Value = usu.Genero;

            comando.Parameters.Add("@aprendiz", SqlDbType.Bit);
            comando.Parameters["@aprendiz"].Value = usu.Aprendiz;

            comando.Parameters.Add("@egresado", SqlDbType.Bit);
            comando.Parameters["@egresado"].Value = usu.Egresado;

            comando.Parameters.Add("@areaformacion", SqlDbType.VarChar);
            comando.Parameters["@areaformacion"].Value = usu.AreaFormacion;

            comando.Parameters.Add("@fechaegresado", SqlDbType.Date);
            comando.Parameters["@fechaegresado"].Value = usu.FechaEgresado;

            comando.Parameters.Add("@direccion", SqlDbType.VarChar);
            comando.Parameters["@direccion"].Value = usu.Direccion;

            comando.Parameters.Add("@barrio", SqlDbType.VarChar);
            comando.Parameters["@barrio"].Value = usu.Barrio;

            comando.Parameters.Add("@ciudad", SqlDbType.VarChar);
            comando.Parameters["@ciudad"].Value = usu.Ciudad;

            comando.Parameters.Add("@departamento", SqlDbType.VarChar);
            comando.Parameters["@departamento"].Value = usu.Departamento;

            comando.Parameters.Add("@fecharegistro", SqlDbType.Date);
            comando.Parameters["@fecharegistro"].Value = usu.FechaRegistro;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Borrar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from usuarios where id=@id",con);
            comando.Parameters.Add("@id", SqlDbType.Int);
            comando.Parameters["@id"].Value =id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}