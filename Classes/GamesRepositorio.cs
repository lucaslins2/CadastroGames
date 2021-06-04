using System;
using System.Collections.Generic;

namespace GAMESFLIX.Classes
{
    class GamesRepositorio : IRepositorio<Games>
    {

        private List<Games> listGames = new List<Games>();
        public void Atualiza(int id, Games entidade)
        {
            listGames[id] = entidade;
        }

        public void Exclui(int id)
        {
            listGames[id].Excluir();
        }

        public void Insere(Games objeto)
        {
            listGames.Add(objeto);
           }

        public List<Games> Lista()
        {
            return listGames;
        }

        public int ProximoId()
        {
            return listGames.Count;
        }

        public Games RetornaPorId(int id)
        {
            return listGames[id];
        }
    }
}
