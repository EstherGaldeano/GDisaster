using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Assets.Scripts.DataBase
{
    static class GameDataBase
    {
        //Conexion a la base de datos
        private static SqlConnection conexion = new SqlConnection("Data Source =172.16.110.128\\sqlexpress;"
                                                    + "initial Catalog=GDProy;"
                                                    + "Persist Security info=True;"
                                                    + "User ID = sa;" + "Password=cep");

        //QUERYS PARA LOS MONSTRUOS--->
        #region Mostruos
        public static DataTable sqlMonsterInfo(int id,string idioma)
        {
            string monsterCreator="";
            string mensaje = "";
            StringBuilder sb = new StringBuilder();
            SqlDataReader datos;
            DataTable data = new DataTable();
            try
            {
                SqlCommand query = new SqlCommand();
/******************************* Constructor de la query******************************/
                sb.Append("SELECT m.id_mon, m.nombre_mon,");
                sb.Append(" d.descripcion, m.tipo");
                sb.Append(" FROM GDP_Monstruos m");
                sb.Append(" INNER JOIN GDP_Descripciones d");
                sb.Append(" ON m.ID_DESC_MON = d.ID_DESC");
                sb.Append(" WHERE m.id_mon = @id AND");
                sb.Append(" d.cod_idioma = @idioma");
/******************************* Constructor de la query******************************/
                monsterCreator = sb.ToString();
                query.Connection = conexion;
                query.CommandText = monsterCreator;
                //SETEAMOS PARAMETROS
                query.Parameters.AddWithValue("@id", id);
                query.Parameters.AddWithValue("@idioma", idioma);
                //Abrimos Conexion
                conexion.Open();
                //Ejecutamos la query
                datos = query.ExecuteReader();
                data.Load(datos);
                //Cerramos Conexion
                conexion.Close();
                
            }
            catch(SqlException ex)
            {
                mensaje = ex.Number + " - " + ex.Message;
            }
           return data;
        }

        #endregion
    }

}

