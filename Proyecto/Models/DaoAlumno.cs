using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Proyecto.Models
{
    public class DaoAlumno
    {
        static string cadena = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        private SqlConnection cn = new SqlConnection(cadena);
        SqlTransaction tran;
        public List<Alumno> listado()
        {
            List<Alumno> lista = new List<Alumno>();
            SqlCommand cmd = new SqlCommand("select * from alumno", cn);
            cmd.CommandType = CommandType.Text;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Alumno()
                {
                    idAlumno = dr.GetInt32(0),
                    nombre = dr.GetString(1),
                    apellido= dr.GetString(2),
                    dni = dr.GetString(3),
                    correo = dr.GetString(4),
                    direccion = dr.GetString(5),
                    curso = dr.GetInt32(6),
                    sede = dr.GetInt32(7)
                });
            }
            dr.Close();
            cn.Close();
            cmd.Dispose();
            return lista;
        }
        public string guardar (Alumno Al)
        {
            string msj = null;
            try
            {
                SqlCommand cmd = new SqlCommand("RegistrarAlumno", cn);
                cmd.Parameters.AddWithValue("@nom", Al.nombre);
                cmd.Parameters.AddWithValue("@ape", Al.apellido);
                cmd.Parameters.AddWithValue("@dni", Al.dni);
                cmd.Parameters.AddWithValue("@correo", Al.correo);
                cmd.Parameters.AddWithValue("@direc", Al.direccion);
                cmd.Parameters.AddWithValue("@idc", Al.curso);
                cmd.Parameters.AddWithValue("@ids", Al.sede);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                tran = cn.BeginTransaction(); //iniciar la transacción
                cmd.Transaction = tran; //asignar la transacción al comando
                cmd.ExecuteNonQuery();
                tran.Commit();  //confirmar la transacción
                cn.Close();
                cmd.Dispose();
                msj = "listo";
            }
            catch (SqlException ex)
            {
                tran.Rollback(); //cancelar la transacción
                msj = ex.Message;
            }
            return msj;
        }

    }
}