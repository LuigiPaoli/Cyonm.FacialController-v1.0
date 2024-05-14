using Cyonm.FacialController.Data;
using Cyonm.FacialController.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
            Connection.Connect(Query._queryFotosBackup, 4);
        }
    }
}
