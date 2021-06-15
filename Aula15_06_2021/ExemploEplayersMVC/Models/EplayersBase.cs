using System.Collections.Generic;
using System.IO;

namespace ExemploEplayersMVC.Models
{
    public class EplayersBase
    {
        public void CriarPastaEArquivo(string _caminho)
        {
            string pasta = _caminho.Split("/")[0];
            string arquivo = _caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Close();
            }

        }
        public List<string> LeiaTodasLinhasCSV(string CAMINHO){
            List<string> linhas = new List<string>();
            using (StreamReader file = new StreamReader(CAMINHO))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
        public void ReescrevaCSV(string CAMINHO, List<string> linhas){
            using (StreamWriter output = new StreamWriter(CAMINHO))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}