using System;

namespace GrupoDeCarros
{
    public class Frota : EntidadeBase
    {
		private Grupo Grupo { get; set; }
		private string Titulo { get; set; }
		private string VeiculoSimilar { get; set; }
		private string SippCode { get; set; }
		private double Motor { get; set; }
		private int Lugares { get; set; }		
		private int Portas { get; set; }
        private bool Excluido {get; set;}
		public Frota(int id, Grupo grupo, string titulo, string VeiculoSimilar, string SippCode, double Motor, int Lugares, int Portas)
		{
			this.Id = id;
			this.Grupo = grupo;
			this.Titulo = titulo;
			this.VeiculoSimilar = VeiculoSimilar;
			this.SippCode = SippCode;
			this.Motor = Motor;
			this.Lugares = Lugares;
			this.Portas = Portas;
            this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Grupo: " + this.Grupo + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Veículo Similar: " + this.VeiculoSimilar + Environment.NewLine;
            retorno += "Sipp Code: " + this.SippCode + Environment.NewLine;
            retorno += "Motor: " + this.Motor + Environment.NewLine;
            retorno += "Lugares: " + this.Lugares + Environment.NewLine;
            retorno += "Portas: " + this.Portas + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}