using Cyonm.FacialController.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyonm.FacialController.Func
{
    public static class BackupFotos
    {
        public static void SalvarFotos()
        {
            Console.Clear();
            string diretorioFotos = @"C:\Users\Admin\Desktop\FacialDb";
            string query = Data.Query._insertFotos;
            string[] arquivos = Directory.GetFiles(diretorioFotos);

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                connection.Open();
                int i = 0;
                foreach (string arquivo in arquivos)
                {

                    var idPessoa = (from a in DataList.getPessoas
                                    where a.SvrPessoaGuid == arquivo.Substring(arquivo.IndexOf("_") + 1, 36)
                                    select a.SvrPessoaId).FirstOrDefault();
                    var nomePessoa = (from a in DataList.getPessoas
                                      where a.SvrPessoaId == idPessoa
                                      select a.Nome).FirstOrDefault();
                    var fotoTabela = from a in DataList.getBackup
                                     select a.SvrPessoaID;


                    if (idPessoa != 0 | fotoTabela.ToList().Contains(idPessoa))
                    {

                        Console.WriteLine($"Foram inseridas {i} fotos no banco de dados");

                        byte[] bytesImagem = File.ReadAllBytes(arquivo);
                        var Base64 = Convert.ToBase64String(bytesImagem);

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {

                            command.Parameters.AddWithValue("@SvrPessoaID", idPessoa);
                            command.Parameters.Add("@Codigo", System.Data.SqlDbType.Image, bytesImagem.Length).Value = bytesImagem;
                            command.Parameters.AddWithValue("Base64", Base64);
                            command.ExecuteNonQuery();

                            i++;
                            Console.Clear();
                        }
                    }
                }
                Console.WriteLine("Deseja baixar as fotos? \n1 -> SIM\n2 -> NÃO");
                int x = Convert.ToInt32(Console.ReadLine());
                try {if (x == 1) {RetornarImagem();}}catch{}
                Console.Clear();
                Funcionalidades.Funcoes();
            }

        }

        public static void RetornarImagem()
        {
            string queryRecuperarImagem = "SELECT Codigo,SvrPessoaID FROM FotosBackup";

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryRecuperarImagem, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Recupera os dados binários da imagem do banco de dados
                            byte[] bytesImagem = (byte[])reader["Codigo"];
                            int SvrPessoaID = Convert.ToInt32(reader["SvrPessoaID"]);

                            // Salva os dados binários da imagem em um arquivo
                            File.WriteAllBytes("C:\\Users\\Admin\\Desktop\\teste\\PP_" + SvrPessoaID + ".jpg", bytesImagem);
                        }
                    }
                }
            }
        }
    }
}
