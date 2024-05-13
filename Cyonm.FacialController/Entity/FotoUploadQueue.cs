using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyonm.FacialController.Entity
{
    internal class FotoUploadQueue
    {
        public int SvrPessoaID { get; set; }
        public int Status {  get; set; }

        public int SvrEquipamentoID { get; set; }
        public string NomeEquipamento {  get; set; }
    }
}
