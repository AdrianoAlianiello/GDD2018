using Storage;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
	public abstract class UsuarioBase : EditableEntity
	{
		private int _id;
		private bool _activo;
		private int _cantIntentos;
		private string _password;
		private bool _temporal;
		private string _username;
		[DataMember]
		public virtual bool Activo
		{
			get { return _activo; }
			set { _activo = value; }
		}
		[DataMember]
		public virtual int CantIntentos
		{
			get { return _cantIntentos; }
			set { _cantIntentos = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		[DataMember]
		public virtual string Password
		{
			get { return _password; }
			set { _password = value; }
		}
		[DataMember]
		public virtual bool Temporal
		{
			get { return _temporal; }
			set { _temporal = value; }
		}
		[DataMember]
		public virtual string Username
		{
			get { return _username; }
			set { _username = value; }
		}
		public override int GetHashCode()
		{
			return this.Id;
		}
	}
}
