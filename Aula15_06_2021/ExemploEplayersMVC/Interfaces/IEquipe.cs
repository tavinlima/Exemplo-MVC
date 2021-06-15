using System.Collections.Generic;
using ExemploEplayersMVC.Models;

namespace ExemploEplayersMVC.Interfaces
{
    public interface IEquipe
    {
        void Criar(EquipeModel e);
        List<EquipeModel> ReadAll();
        void Atualizar(EquipeModel e);
        void Deletar(int id);
    }
}