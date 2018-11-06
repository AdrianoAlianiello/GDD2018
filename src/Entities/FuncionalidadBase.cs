using Storage;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
	public abstract class FuncionalidadBase : EditableEntity
	{
		private int _id;
		private string _detalle;
		[DataMember]
		public virtual string Detalle
		{
			get { return _detalle; }
			set { _detalle = value; }
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
