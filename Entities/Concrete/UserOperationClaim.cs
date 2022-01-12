using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class UserOperationClaim:IEntity
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public int OperationClaimId { get; set; }

    }
}
