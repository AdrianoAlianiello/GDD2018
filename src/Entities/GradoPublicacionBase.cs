using System;
using Storage;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
    public abstract class GradoPublicacionBase : EditableEntity
    {
        private int _id;
        private string _descripcion;
        private decimal _porcenajeComision;
        [DataMember]
        public override int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember]
        public virtual decimal PorcenajeComision
        {
            get { return _porcenajeComision; }
            set { _porcenajeComision = value; }
        }
        [DataMember]
        public virtual string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
