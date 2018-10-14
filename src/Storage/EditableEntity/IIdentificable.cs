using System.Runtime.Serialization;

namespace Storage
{
    public interface IIdentificable
    {
        [DataMember]
        int Id { get; set; }
    }
}
