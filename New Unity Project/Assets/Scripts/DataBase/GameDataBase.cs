using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace GamePruebas
{
    public static class GameDataBase
    {
        //CONEXION A LA BASE DE DATOS--->
        private static SqlConnection conexion = new SqlConnection("Data Source =sqlserver\\sqlexpress;"
                                                    + "initial Catalog=GDProy;"
                                                    + "Persist Security info=True;"
                                                    + "User ID = sa;" + "Password=cep");
        //CONTROL DE ERRORES--->
        #region Control_De_Errores
        public static string controlDeErrores(SqlException ex)
        {
            string mensaje = "";
            switch (ex.Number)
            {

                case -1: mensaje = "No se encuentra el servidor"; break;
                case 547: mensaje = "Tiene registros relacionados"; break;
                default: mensaje = ex.Number + "-" + ex.Message; break;
            }
            return mensaje;

        }
        #endregion

        //QUERYS PARA LOS MONSTRUOS--->
        #region Mostruos
        public static DataTable getMonsterInfo(int id, string idioma, ref string mensaje)
        {
            StringBuilder sb = new StringBuilder();
            SqlDataReader datos;
            DataTable data = new DataTable();
            try
            {
                SqlCommand query = new SqlCommand();
                /*******************************[ Constructor de la query ]******************************/
                sb.Append("SELECT m.id_mon as id, m.nombre_mon as nombre,");
                sb.Append(" d.descripcion as desc, m.cod_tipo_mon as tipo, m.info_unlocked as locked");
                sb.Append(" FROM GDP_Monstruos m");
                sb.Append(" INNER JOIN GDP_Descripciones d");
                sb.Append(" ON m.ID_DESC_MON = d.ID_DESC");
                sb.Append(" WHERE a.ID_Arma = ").Append(id);
                sb.Append(" AND d.cod_idioma = ").Append(idioma);

                query.Connection = conexion;
                query.CommandText = sb.ToString();
                //Abrimos Conexion
                conexion.Open();
                //Ejecutamos la query
                datos = query.ExecuteReader();
                data.Load(datos);
                //Cerramos Conexion
                conexion.Close();

            }
            catch (SqlException ex)
            {
                mensaje = ex.Number + " - " + ex.Message;
            }
            return data;
        }

        public static List<string> getMonsterType(ref string mensaje)
        {
            StringBuilder sb = new StringBuilder();
            SqlDataReader datos;
            DataTable data = new DataTable();
            try
            {
                SqlCommand query = new SqlCommand();
                /*******************************[ Constructor de la query ]******************************/
                sb.Append("SELECT cod_tipo as cod");
                sb.Append(" FROM GDP_TipoMon");

                query.Connection = conexion;
                query.CommandText = sb.ToString();
                //Abrimos Conexion
                conexion.Open();
                //Ejecutamos la query
                datos = query.ExecuteReader();
                data.Load(datos);
                //Cerramos Conexion
                conexion.Close();

            }
            catch (SqlException ex)
            {
                mensaje = ex.Number + " - " + ex.Message;
            }
            List<string> listaStrings = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                DataRow cods = data.Rows[i];
                listaStrings.Add(cods["cod"].ToString());
            }
            return listaStrings;
        }

        #endregion

        //QUERYS PARA LAS ARMAS--->
        #region Armas
        public static DataTable getArmasInfo(int id, string idioma, ref string mensaje)
        {
            StringBuilder sb = new StringBuilder();
            SqlDataReader datos;
            DataTable data = new DataTable();

            try
            {
                SqlCommand query = new SqlCommand();
                /******************************* Constructor de la query ******************************/
                sb.Append("Select a.ID_Arma, a.Nombre_Arma,");
                sb.Append(" d.descripcion, a.cod_calidad, a.info_unlocked");
                sb.Append(" FROM GDP_Armas a");
                sb.Append(" INNER JOIN GDP_Descripciones d");
                sb.Append(" ON a.ID_des_Arma = d.ID_Desc");
                sb.Append(" WHERE a.ID_Arma = ").Append(id);
                sb.Append(" AND d.cod_idioma = ").Append(idioma);

                query.Connection = conexion;
                query.CommandText = sb.ToString();
                //ABRIMOS CONEXION
                conexion.Open();
                //EJECUTAMOS LA QUERY
                datos = query.ExecuteReader();
                data.Load(datos);
                //CERRAMOS LA CONEXION
                conexion.Close();

            }
            catch (SqlException ex)
            {
                mensaje = controlDeErrores(ex);
            }
            finally
            {
                conexion.Close();
            }

            return data;

        }


        #endregion

        //QUERYS PARA LA INTERFAZ--->
        #region LITERALES

        public static DataTable getLiteral(int id, string idioma, ref string mensaje)
        {
            StringBuilder sb = new StringBuilder();
            SqlDataReader datos;
            DataTable data = new DataTable();

            try
            {
                SqlCommand query = new SqlCommand();
                /******************************* Constructor de la query ******************************/
                sb.Append("Select * FROM GDP_Descripciones ");
                sb.Append(" WHERE id_desc = ").Append(id);
                sb.Append(" AND cod_idioma = '").Append(idioma).Append("'");

                /*******************************[ Seteo de la query ]******************************/
                query.Connection = conexion;
                query.CommandText = sb.ToString();
                //ABRIMOS CONEXION
                conexion.Open();
                //EJECUTAMOS LA QUERY
                datos = query.ExecuteReader();
                data.Load(datos);
                //CERRAMOS LA CONEXION
                

            }
            catch (SqlException ex)
            {
                mensaje = controlDeErrores(ex);
            }
            finally
            {
                conexion.Close();
            }

            return data;

        }
        public static DataTable getIdiomas(ref string mensaje)
        {
            StringBuilder sb = new StringBuilder();
            SqlDataReader datos;
            DataTable data = new DataTable();

            try
            {
                SqlCommand query = new SqlCommand();
                /******************************* Constructor de la query ******************************/
                sb.Append("Select * FROM IDIOMAS");

                query.Connection = conexion;
                query.CommandText = sb.ToString();
                //ABRIMOS CONEXION
                conexion.Open();
                //EJECUTAMOS LA QUERY
                datos = query.ExecuteReader();
                data.Load(datos);
                //CERRAMOS LA CONEXION
                

            }
            catch (SqlException ex)
            {
                mensaje = controlDeErrores(ex);
            }
            finally
            {
                conexion.Close();
            }
            return data;

        }

        public static string getCodIdiomas(string denomIdioma, ref string mensaje)
        {
            StringBuilder sb = new StringBuilder();
            SqlDataReader datos;
            DataTable data = new DataTable();
            if (denomIdioma.Equals(""))
            {
                denomIdioma = "ESPAÑOL";
            }
            try
            {
                SqlCommand query = new SqlCommand();
                /******************************* Constructor de la query ******************************/
                sb.Append("Select * FROM IDIOMAS where Denominacion =").Append(denomIdioma);

                query.Connection = conexion;
                query.CommandText = sb.ToString();
                //ABRIMOS CONEXION
                conexion.Open();
                //EJECUTAMOS LA QUERY
                datos = query.ExecuteReader();
                data.Load(datos);
                //CERRAMOS LA CONEXION
                conexion.Close();

            }
            catch (SqlException ex)
            {
                mensaje = controlDeErrores(ex);
            }

            DataRow codID = data.Rows[0];
            return codID["cod_idioma"].ToString();

        }

        #endregion
    }
}
