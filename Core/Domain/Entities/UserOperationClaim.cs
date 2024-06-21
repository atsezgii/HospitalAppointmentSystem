﻿using Core.Persistence.Repositories;

namespace Core.Entities
{
    public class UserOperationClaim : Entity
    {
        public int BaseUserId { get; set; }
        public int OperationClaimId { get; set; }

        public virtual BaseUser BaseUser { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
//