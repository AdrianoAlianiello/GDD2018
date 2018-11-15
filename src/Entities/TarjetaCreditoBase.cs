using Storage;
using System;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
	public abstract class TarjetaCreditoBase : EditableEntity
	{
		private int _id;
		private bool _activa;
		private DateTime _fechaVencimiento;
		private string _nombreTitular;
		private long _numero;
		private int _tipoId;
		[DataMember]
		public virtual bool Activa
		{
			get { return _activa; }
			set { _activa = value; }
		}
		[DataMember]
		public virtual DateTime FechaVencimiento
		{
			get { return _fechaVencimiento; }
			set { _fechaVencimiento = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		[DataMember]
		public virtual string NombreTitular
		{
			get { return _nombreTitular; }
			set { _nombreTitular = value; }
		}
		[DataMember]
		public virtual long Numero
		{
			get { return _numero; }
			set { _numero = value; }
		}
		[DataMember]
		public virtual int TipoId
		{
			get { return _tipoId; }
			set { _tipoId = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
