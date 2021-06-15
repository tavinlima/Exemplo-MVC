using System;
using System.Collections.Generic;
using System.IO;
using ExemploEplayersMVC.Interfaces;

namespace ExemploEplayersMVC.Models
{
    public class EquipeModel : EplayersBase, IEquipe
    {
        public int idEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string CAMINHO = "Database/equipe.csv";
        public EquipeModel(){
            CriarPastaEArquivo(CAMINHO);
        }
        public string Preparar(EquipeModel e){
            return $"{e.idEquipe}{e.Nome}{e.Imagem}";
        }

        public void Atualizar(EquipeModel e)
        {
            List<string> linhas = LeiaTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == e.idEquipe.ToString());
            linhas.Add(Preparar(e));
            ReescrevaCSV(CAMINHO, linhas);
        }

        public void Criar(EquipeModel e)
        {
            string[] linha = {Preparar(e)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LeiaTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescrevaCSV(CAMINHO, linhas);
        }

        public List<EquipeModel> ReadAll()
        {
            List<EquipeModel> equipes = new List<EquipeModel>();
            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                EquipeModel equipe = new EquipeModel();
                equipe.idEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];
                
                equipes.Add(equipe);
            }
            return equipes;
        }
    }
}