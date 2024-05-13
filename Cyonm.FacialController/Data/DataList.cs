using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Cyonm.FacialController.Data
{
    internal class DataList
    {
        public static List<Entity.FotoUploadQueue> getFotos;
        public static List<Entity.SvrPessoa> getPessoas;
        public static List<Entity.SvrEquipamento> getEquipamentos;
    }
}
