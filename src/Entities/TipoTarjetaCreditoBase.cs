using Storage;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
	public abstract class TipoTarjetaCreditoBase : EditableEntity
	{
		private int _id;
		private string _descripcion;
		[DataMember]
		public virtual string Descripcion
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
