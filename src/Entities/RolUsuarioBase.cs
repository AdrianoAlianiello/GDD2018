using Storage;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
	public abstract class RolUsuarioBase : EditableEntity
	{
		private int _id;
		private int _rolId;
		private int _usuarioId;
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		[DataMember]
		public virtual int RolId
		{
			get { return _rolId; }
			set { _rolId = value; }
		}
		[DataMember]
		public virtual int UsuarioId
		{
			get { return _usuarioId; }
			set { _usuarioId = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
