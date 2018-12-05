using Storage;
using System;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
    public abstract class PublicacionBase : EditableEntity
    {
        private int _id;
        private long _codigo;
        private string _descripcion;
        private DateTime _fechaInicio;
        private int _estadoId;
        private int? _gradoId;
        private int? _usuadioId;
        private int _espectaculoHorarioId;
        private int _empresaId;
        [DataMember]
        public virtual long Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        [DataMember]
        public override int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember]
        public virtual string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        [DataMember]
        public virtual DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }
        [DataMember]
        public virtual int EstadoId
        {
            get { return _estadoId; }
            set { _estadoId = value; }
        }
        [DataMember]
        public virtual int? GradoId
        {
            get { return _gradoId; }
            set { _gradoId = value; }
        }
        [DataMember]
        public virtual int? UsuadioId
        {
            get { return _usuadioId; }
            set { _usuadioId = value; }
        }
        [DataMember]
        public virtual int EspectaculoHorarioId
        {
            get { return _espectaculoHorarioId; }
            set { _espectaculoHorarioId = value; }
        }
        [DataMember]
        public virtual int EmpresaId
        {
            get { return _empresaId; }
            set { _empresaId = value; }
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
