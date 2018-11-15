using Storage;
using System;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
	public abstract class ClienteBase : EditableEntity
	{
		private int _id;
		private bool _activo;
		private string _apellido;
		private long? _cuil;
		private string _domicilioCalle;
		private string _domicilioCodPostal;
		private string _domicilioDepto;
		private string _domicilioLocalidad;
		private long _domicilioNro;
		private long _domicilioPiso;
		private DateTime _fechaCreacion;
		private DateTime _fechaNacimiento;
		private string _mail;
		private string _nombre;
		private long _nroDocumento;
		private long _telefono;
		private string _tipoDocumento;
		private int _usuarioId;
		[DataMember]
		public virtual bool Activo
		{
			get { return _activo; }
			set { _activo = value; }
		}
		[DataMember]
		public virtual string Apellido
		{
			get { return _apellido; }
			set { _apellido = value; }
		}
		[DataMember]
		public virtual long? Cuil
		{
			get { return _cuil; }
			set { _cuil = value; }
		}
		[DataMember]
		public virtual string DomicilioCalle
		{
			get { return _domicilioCalle; }
			set { _domicilioCalle = value; }
		}
		[DataMember]
		public virtual string DomicilioCodPostal
		{
			get { return _domicilioCodPostal; }
			set { _domicilioCodPostal = value; }
		}
		[DataMember]
		public virtual string DomicilioDepto
		{
			get { return _domicilioDepto; }
			set { _domicilioDepto = value; }
		}
		[DataMember]
		public virtual string DomicilioLocalidad
		{
			get { return _domicilioLocalidad; }
			set { _domicilioLocalidad = value; }
		}
		[DataMember]
		public virtual long DomicilioNro
		{
			get { return _domicilioNro; }
			set { _domicilioNro = value; }
		}
		[DataMember]
		public virtual long DomicilioPiso
		{
			get { return _domicilioPiso; }
			set { _domicilioPiso = value; }
		}
		[DataMember]
		public virtual DateTime FechaCreacion
		{
			get { return _fechaCreacion; }
			set { _fechaCreacion = value; }
		}
		[DataMember]
		public virtual DateTime FechaNacimiento
		{
			get { return _fechaNacimiento; }
			set { _fechaNacimiento = value; }
		}
		[DataMember]
		public override int Id
		{
			get { return _id; }
			set { _id = value; }
		}
		[DataMember]
		public virtual string Mail
		{
			get { return _mail; }
			set { _mail = value; }
		}
		[DataMember]
		public virtual string Nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		[DataMember]
		public virtual long NroDocumento
		{
			get { return _nroDocumento; }
			set { _nroDocumento = value; }
		}
		[DataMember]
		public virtual long Telefono
		{
			get { return _telefono; }
			set { _telefono = value; }
		}
		[DataMember]
		public virtual string TipoDocumento
		{
			get { return _tipoDocumento; }
			set { _tipoDocumento = value; }
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
