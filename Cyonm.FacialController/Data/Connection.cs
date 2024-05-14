using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyonm.FacialController.Data
{
    internal class Connection
    {

        public static readonly string connectionString = "data source=localhost\\sqlexpress;Initial Catalog=TESTE;Integrated Security=True";
        public static string queryString;
        public static void Connect(string query, int escolha)
        {
            
            queryString = query;

            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    switch (escolha)
                    {
                        case 1:
                            try { connection.Open(); DataProcess.BuscarPessoas_(); } catch (Exception ex) { Console.WriteLine("1 - Erro ao conectar: " + ex.Message); }
                            break;
                        case 2:
                            try { connection.Open(); DataProcess.BuscarEquipamento_(); } catch (Exception ex) { Console.WriteLine("2 - Erro ao conectar: " + ex.Message); }
                            break;
                        case 3:
                            try { connection.Open(); DataProcess.BuscarFoto_(); } catch (Exception ex) { Console.WriteLine("3 - Erro ao conectar: " + ex.Message); }
                            break;
                        case 4:
                            try { connection.Open(); DataProcess.BuscarBackup_(); } catch (Exception ex) { Console.WriteLine("3 - Erro ao conectar: " + ex.Message); }
                            break;
                    }
                }
            }
        }
    }
}

