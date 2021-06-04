
using System;
using System.Collections.Generic;
using System.Text;

namespace GAMESFLIX.Classes
{
    public class Games : EntidadeBase
    {

        private string GameName{ get; set;}
        private string Description { get; set; }
        private string ReleaseDate { get; set; }
        private Genero Genero { get; set; }
        private bool multiplayer { get; set; }
     
        private Plataforma plataforma { get; set; }
        private string speech { get; set; }
        private bool Delete { get; set; }
        //contrutor que recebe os parametro para cadastramento do game
        public Games(int id,Genero Genero, Plataforma platform, string gameName, string descricao, string datalanc,bool multiplayer)
        {
            this.Id = id;
            this.Genero = Genero;
            this.plataforma = platform; 
            this.GameName = gameName;
            this.Description = descricao;
            this.ReleaseDate = datalanc;
            this.Delete = false;
            this.multiplayer = multiplayer;

        }

        public override string ToString()
        {
            // Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo do jogo: " + this.GameName + Environment.NewLine;
            retorno += "Descrição: " + this.Description + Environment.NewLine;
            retorno += "data do jogo: " + ReleaseDate + Environment.NewLine;
            retorno += "Plataforma do jogo: " + plataforma + Environment.NewLine;
            retorno += "multiplayer: " + this.multiplayer + Environment.NewLine;
            retorno += "Excluido: " + this.Delete;
            return retorno;
        }
        public string returnTitleGame()
        {
            return this.GameName;
        }

        public int returnId()
        {
            return this.Id;
        }
        public bool returnExcluido()
        {
            return this.Delete;
        }
        public void Excluir()
        {
            this.Delete = true;
        }


    }
}
