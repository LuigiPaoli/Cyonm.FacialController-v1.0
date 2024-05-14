using Cyonm.FacialController.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyonm.FacialController.Func
{
    internal class RelatorioFotos
    {
        public static void EnvioFotos()
        {

            Console.Clear();
            Console.WriteLine(Rep.EnvioFotos.Strings._escolhaCadastro);
            string cadastro = Console.ReadLine().ToUpper();
            var verificaNomes = from nome in DataList.getPessoas
                                where nome.Nome.ToUpper().Contains(cadastro)
                                orderby nome.Nome
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

                    foreach (var c in verificarEnviadas.OrderBy(x => x.NomeEquipamento))
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
    }
}
