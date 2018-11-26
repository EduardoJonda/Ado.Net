using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using sem14.Models;

namespace sem14.Repositorio
{
    public class AlumnoRepo
    {

        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["tecsup"].ToString();
            con = new SqlConnection(constr);

        }

        // lista de datos de alumnos
        public List<AlumnoModel> GetEmpModels()
        {
            connection();
            List<AlumnoModel> AlumnoList = new List<AlumnoModel>();
            SqlCommand com = new SqlCommand("GetAlumnos", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            // recorrer los datos
            foreach (DataRow dr in dt.Rows)
            {
                AlumnoList.Add(new AlumnoModel
                {
                    codalu = Convert.ToString(dr["codalu"]),
                    nomalu = Convert.ToString(dr["nomalu"]),
                    email = Convert.ToString(dr["email"]),
                    telefono = Convert.ToString(dr["telefono"]),
                    codcar = Convert.ToInt32(dr["codcar"]),
                    fecha_ins = Convert.ToDateTime(dr["fecha_ins"]),
                    estado = Convert.ToInt32(dr["estado"]),
                    Fotoalu = Convert.ToString(dr["Fotoalu"])
                });

            }
            return AlumnoList;
        }

        // agregar alumno
        public bool AddAlumnos(AlumnoModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddAlumnos", con);
            // especifica el tipo de sentencia
            com.CommandType = CommandType.StoredProcedure;
            /// pasando los parametros
            com.Parameters.AddWithValue("@codigo", obj.codalu);
            com.Parameters.AddWithValue("@nombre", obj.nomalu);
            com.Parameters.AddWithValue("@email", obj.email);
            com.Parameters.AddWithValue("@telefono", obj.telefono);
            com.Parameters.AddWithValue("@codigo_car", obj.codcar);
            com.Parameters.AddWithValue("@fecha_ins", obj.fecha_ins);
            com.Parameters.AddWithValue("@estado", obj.estado);
            com.Parameters.AddWithValue("@foto", obj.Fotoalu);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // update de datos de alumnos
        public bool UpdateAlumnosModels(AlumnoModel obj)
        {
            connection();
            List<AlumnoModel> EmpList = new List<AlumnoModel>();
            SqlCommand com = new SqlCommand("UpdateAlumno", con);
            com.CommandType = CommandType.StoredProcedure;
            /// pasando los parametros
            com.Parameters.AddWithValue("@codigo", obj.codalu);
            com.Parameters.AddWithValue("@nombre", obj.nomalu);
            com.Parameters.AddWithValue("@email", obj.email);
            com.Parameters.AddWithValue("@telefono", obj.telefono);
            com.Parameters.AddWithValue("@codigo_car", obj.codcar);
            com.Parameters.AddWithValue("@fecha_ins", obj.fecha_ins);
            com.Parameters.AddWithValue("@estado", obj.estado);
            com.Parameters.AddWithValue("@foto", obj.Fotoalu);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete de datos de employee
        public bool DeleteAlumnodelete(string id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteAlumno3", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@codigo", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}