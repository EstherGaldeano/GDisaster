using Assets.Scripts.DataBase;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnityEngine;

public class GameObjLoader : MonoBehaviour {
    public static string IDIOMA = SettingsMenu.languageAPP;
    static string mensaje;
    // Use this for initialization
    void Start () {

            DataTable data = null;
            int numeroID= 0;
            List<Monstruo> monsterLists = new List<Monstruo>();
            string idiomaActual = GamePruebas.GameDataBase.getCodIdiomas(IDIOMA, ref mensaje);
            do
            {
                data = GamePruebas.GameDataBase.getMonsterInfo(numeroID,idiomaActual,ref mensaje);
                DataRow monRow = data.Rows[0];

               
                Monstruo monster = new Monstruo();
                monster.setDesc(monRow["desc"].ToString());
                monster.setID(int.Parse(monRow["id"].ToString()));
                monster.setName(monRow["nombre"].ToString());
                monster.setType(monRow["tipo"].ToString());
                monster.setLocked(monRow["locked"].ToString().ToCharArray()[0]);
                monsterLists.Add(monster);
                numeroID++;

        } while (data != null);
        
       

	}
}
