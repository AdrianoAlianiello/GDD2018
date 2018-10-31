using Storage;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
	public abstract class RolBase : EditableEntity
	{
		private int _id;
		private bool _activo;
		private string _nombre;
		[DataMember]
		public virtual bool Activo
		{
			get { return _activo; }
			set { _activo = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		[DataMember]
		public virtual string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
