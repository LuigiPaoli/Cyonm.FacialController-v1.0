using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyonm.FacialController.Data
{
    internal class DataProcess
    {
        #region //RELATORIO ENVIO DE FOTOS
        public static void BuscarPessoas_()
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Connection.queryString, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        DataList.getPessoas = new List<Entity.SvrPessoa>();

                        while (reader.Read())
                        {


                            int SvrPessoaID = Convert.ToInt32(reader["SvrPessoaID"]);
                            int Status = Convert.ToInt32(reader["Status"]);
                            string Nome = reader["Nome"].ToString();
                            string SvrPessoaGuid = reader["SvrPessoaGuid"].ToString();


                            DataList.getPessoas.Add(new Entity.SvrPessoa { SvrPessoaId = SvrPessoaID, Nome = Nome, Status = Status, SvrPessoaGuid = SvrPessoaGuid });

                        }
                    }
                }
            }
        }

        public static void BuscarEquipamento_()
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Connection.queryString, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        DataList.getEquipamentos = new List<Entity.SvrEquipamento>();

                        while (reader.Read())
                        {


                            int SvrEquipamentoID = Convert.ToInt32(reader["SvrEquipamentoID"]);
                            string NomeEquipamento = reader["NomeEquipamento"].ToString();
                            int Modelo = Convert.ToInt32(reader["Modelo"]);

                            DataList.getEquipamentos.Add(new Entity.SvrEquipamento { SvrEquipamentoID = SvrEquipamentoID, NomeEquipamento = NomeEquipamento, Modelo = Modelo }); ;

                        }
                    }
                }
            }
        }


        public static void BuscarFoto_()
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Connection.queryString, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        DataList.getFotos = new List<Entity.FotoUploadQueue>();

                        while (reader.Read())
                        {


                            int SvrPessoaID = Convert.ToInt32(reader["SvrPessoaID"]);
                            int Status = Convert.ToInt32(reader["Status"]);
                            int SvrEquipamentoID = Convert.ToInt32(reader["SvrEquipamentoID"]);
                            string NomeEquipamento = reader["NomeEquipamento"].ToString();


                            DataList.getFotos.Add(new Entity.FotoUploadQueue { SvrPessoaID = SvrPessoaID, Status = Status, SvrEquipamentoID = SvrEquipamentoID, NomeEquipamento = NomeEquipamento }); ;

                        }
                    }
                }
            }
        }
        #endregion

        #region //BACKUP DE FOTOS

        public static void BuscarBackup_()
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(Connection.queryString, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataList.getBackup = new List<Entity.FotosBackup>();

                        while (reader.Read())
                        {


                            int SvrPessoaID = Convert.ToInt32(reader["SvrPessoaID"]);
                            string Codigo = reader["Codigo"].ToString();
                            string Base64 = reader["Base64"].ToString();


                            DataList.getBackup.Add(new Entity.FotosBackup { SvrPessoaID = SvrPessoaID, Codigo = Codigo, Base64 = Base64});

                        }
                    }
                }
            }

        }

        #endregion
    }
}