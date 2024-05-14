using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyonm.FacialController.Data
{
    internal class Query
    {
        //RELATORIO ENVIO DE FOTOS
        public static string _querySvrPessoa = "SELECT SvrPessoaID,Nome,Status,SvrPessoaGuid FROM SvrPessoa";
        public static string _querySvrEquipamento = "SELECT SvrEquipamentoID,NomeEquipamento,Modelo FROM SvrEquipamento";
        public static string _queryFotoUploadQueue = "SELECT f.SvrPessoaID,f.SvrEquipamentoID,f.Status,e.NomeEquipamento FROM FotoUploadQueue f INNER JOIN SvrEquipamento e ON f.SvrEquipamentoID = e.SvrEquipamentoID WHERE e.Modelo = 4";

        //BACKUP FOTOS SQL
        public static string _insertFotos = "INSERT INTO FotosBackup (SvrPessoaID, Codigo, Base64) VALUES (@SvrPessoaID, @Codigo, @Base64)";
        public static string _createTabelaFotos = "CREATE TABLE FotosBackup(FotoID INT PRIMARY KEY IDENTITY,SvrPessoaID INT,Codigo VARBINARY(MAX), Base64 VARCHAR(MAX))";
        public static string _queryFotosBackup = "SELECT SvrPessoaID,Codigo FROM FotosBackup";
    }
}
