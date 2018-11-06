using Storage;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
	public abstract class FuncionalidadRolBase : EditableEntity
	{
		private int _id;
		private int _funcionalidadId;
		private int _rolId;
		[DataMember]
		public virtual int FuncionalidadId
		{
			get { return _funcionalidadId; }
			set { _funcionalidadId = value; }
		}
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
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
