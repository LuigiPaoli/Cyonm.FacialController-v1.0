using Cyonm.FacialController.Data;
using Cyonm.FacialController.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyonm.FacialController
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetDados();
            Funcionalidades.Funcoes();
        }

        static void GetDados()
        {
            Connection.Connect(Query._querySvrPessoa, 1);
            Connection.Connect(Query._querySvrEquipamento, 2);
            Connection.Connect(Query._queryFotoUploadQueue, 3);
        }

        #region //EXECUÇÃO DO SISTEMA
        public static void EnvioFotos()
        {

            Console.Clear();
            Console.WriteLine(Rep.EnvioFotos.Strings._escolhaCadastro);
            string cadastro = Console.ReadLine().ToUpper();
            var verificaNomes = from nome in DataList.getPessoas
                                where nome.Nome.ToUpper().Contains(cadastro)
                                select nome;

            if (verificaNomes.Count() > 0)
            {
                Console.Clear();
                Console.WriteLine(Rep.EnvioFotos.Strings._escolhaCadastroIndex);
                int i = 0;

                foreach (var c in verificaNomes)
                {
                    Console.WriteLine($"{i} -> {c.Nome}"); i++;
                }
                Console.WriteLine("\n");
                int index = Convert.ToInt32(Console.ReadLine());
                var verificarEnviadas = from envio in DataList.getFotos
                                        where envio.SvrPessoaID == verificaNomes.ElementAt(index).SvrPessoaId &&
                                        envio.Status == 2
                                        select envio;
                var verificaEquipamento = from equipamento in DataList.getEquipamentos
                                          where equipamento.Modelo == 4
                                          orderby equipamento.NomeEquipamento
                                          select equipamento;
                Console.Clear();
                Console.WriteLine("             " + verificaNomes.ElementAt(index).Nome.ToUpper());
                Console.WriteLine("\n\nRELAÇÃO DE ENVIO:\n");

                if (verificarEnviadas.ToList().Count() == 0)
                {
                    foreach (var c in verificaEquipamento)
                    {
                        Console.WriteLine($"{c.NomeEquipamento} -> NÃO ENVIADO");
                    }
                }
                else
                {
                    List<int> enviados = new List<int>();

                    foreach (var c in verificarEnviadas.OrderBy(x=>x.NomeEquipamento))
                    {
                        Console.WriteLine($"{c.NomeEquipamento} -> ENVIADO");
                        enviados.Add(c.SvrEquipamentoID);
                    }
                    foreach (var c in verificaEquipamento.OrderBy(x => x.NomeEquipamento))
                    {
                        if (enviados.Contains(c.SvrEquipamentoID))
                        {
                        }
                        else
                        {
                            Console.WriteLine($"{c.NomeEquipamento} -> NÃO ENVIADO");
                        }
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nCadastro não encontrado...\n");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar:");
            var continuar = Console.ReadLine();
            Console.Clear();
            Funcionalidades.Funcoes();
        }
        public static void VerificarAcessos()
        {
            Console.Clear();
        }

        public static void SalvarFotos()
        {
            Console.Clear();
        }

        public static void VerificarConexao()
        {
            Console.Clear();
        }

        public static void EnviarConfigCatracas()
        {
            Console.Clear();
        }
        #endregion

    }
}
