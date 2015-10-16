using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Infrastructure.Contract
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}
