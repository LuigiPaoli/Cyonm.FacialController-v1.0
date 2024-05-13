using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyonm.FacialController.Data
{
    internal class Query
    {
        public static string _querySvrPessoa = "SELECT SvrPessoaID,Nome,Status,SvrPessoaGuid FROM SvrPessoa";
        public static string _querySvrEquipamento = "SELECT SvrEquipamentoID,NomeEquipamento,Modelo FROM SvrEquipamento";
        public static string _queryFotoUploadQueue = "SELECT f.SvrPessoaID,f.SvrEquipamentoID,f.Status,e.NomeEquipamento FROM FotoUploadQueue f INNER JOIN SvrEquipamento e ON f.SvrEquipamentoID = e.SvrEquipamentoID WHERE e.Modelo = 4";
    }
}
