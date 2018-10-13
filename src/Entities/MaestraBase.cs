using System;
using System.Runtime.Serialization;

namespace Entities
{
    [DataContract]
	public abstract class MaestraBase
	{
		private string _apeliido;
		private string _codPostal;
		[DataMember]
		public virtual string Apeliido
		{
			get { return _apeliido; }
			set { _apeliido = value; }
		}
		[DataMember]
		public virtual string CodPostal
		{
			get { return _codPostal; }
			set { _codPostal = value; }
		}
		public override int GetHashCode()
		{
            return this.Apeliido.GetHashCode() ^ this.CodPostal.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
