
using Repository.Infrastructure.Contract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Infrastructure
{
    public abstract class EntityObjectState : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}
