using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyonm.FacialController
{
    internal class Funcionalidades
    {
        public static void Funcoes()
        {

            Console.WriteLine("Escolha a funcionalidade:\n\n");
            Console.WriteLine("1 - Verificar envio de fotos dos cadastros");
            Console.WriteLine("2 - Acompanhar acessos em tempo real\n");
            int escolha = Convert.ToInt32(Console.ReadLine());
            if (escolha > 2)
            {
                Console.WriteLine("Função não encontrada. Deseja tentar novamente?\n1 -> SIM\n2 -> NÃO\n");
                int prossiga = Convert.ToInt32(Console.ReadLine());

                if (prossiga == 1 ) { Funcoes(); }
                else { Console.WriteLine("Fim do programa"); }
            }

            switch (escolha)
            {
                case 1: Program.EnvioFotos(); break;
                case 2: Program.VerificarAcessos(); break;
            }
        }
    }
}
