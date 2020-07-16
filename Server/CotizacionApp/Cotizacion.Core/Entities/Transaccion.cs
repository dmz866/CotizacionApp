using System;
using System.Collections.Generic;
using System.Text;

namespace CotizacionApp.Core.Entities
{
	public class Transaccion
	{
		public int Id { get; set; }
		public decimal Monto { get; set; }
		public string Moneda { get; set; }
		public int UsuarioId { get; set; }
		public DateTime CreatedOn { get; set; } = new DateTime();
		public int CreatedBy { get; set; }
		public DateTime UpdatedOn { get; set; } = new DateTime();
		public int UpdatedBy { get; set; }

		public Transaccion(int Id, decimal Monto, string Moneda, int UsuarioId, DateTime CreatedOn, int CreatedBy, DateTime UpdatedOn, int UpdatedBy)
		{
			this.Id = Id;
			this.Monto = Monto;
			this.Moneda = Moneda;
			this.UsuarioId = UsuarioId;
			this.CreatedOn = CreatedOn;
			this.CreatedBy = CreatedBy;
			this.UpdatedOn = UpdatedOn;
			this.UpdatedBy = UpdatedBy;
		}
	}
}
