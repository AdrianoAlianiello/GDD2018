using Storage;
using System;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
	public abstract class EmpresaBase : EditableEntity
	{
		private int _id;
		private bool _activa;
		private string _ciudad;
		private string _cuit;
		private string _domicilioCalle;
		private string _domicilioCodPostal;
		private string _domicilioDepto;
		private decimal _domicilioNro;
		private decimal? _domicilioPiso;
		private DateTime _fechaCreacion;
		private string _mail;
		private string _razonSocial;
		private decimal _telefono;
		private int _usuarioId;
		[DataMember]
		public virtual bool Activa
		{
			get { return _activa; }
			set { _activa = value; }
		}
		[DataMember]
		public virtual string Ciudad
		{
			get { return _ciudad; }
			set { _ciudad = value; }
		}
		[DataMember]
		public virtual string Cuit
		{
			get { return _cuit; }
			set { _cuit = value; }
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
		public virtual decimal DomicilioNro
		{
			get { return _domicilioNro; }
			set { _domicilioNro = value; }
		}
		[DataMember]
		public virtual decimal? DomicilioPiso
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
		public virtual string RazonSocial
		{
			get { return _razonSocial; }
			set { _razonSocial = value; }
		}
		[DataMember]
		public virtual decimal Telefono
		{
			get { return _telefono; }
			set { _telefono = value; }
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
