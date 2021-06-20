using System;
using System.Collections.Generic;
using GrupoDeCarros.Interfaces;

namespace GrupoDeCarros
{
	public class FrotaRepositorio : IRepositorio<Frota>
	{
        private List<Frota> listaFrota = new List<Frota>();
		public void Atualiza(int id, Frota objeto)
		{
			listaFrota[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaFrota[id].Excluir();
		}

		public void Insere(Frota objeto)
		{
			listaFrota.Add(objeto);
		}

		public List<Frota> Lista()
		{
			return listaFrota;
		}

		public int ProximoId()
		{
			return listaFrota.Count;
		}

		public Frota RetornaPorId(int id)
		{
			return listaFrota[id];
		}
	}
}