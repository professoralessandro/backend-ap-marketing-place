﻿using System;

namespace basecs.Enuns
{
    public class SystemDBObjEnum
    {
        public  Guid SystemUser { get; } = Guid.Parse("9a5f0c64-8103-4ee1-8acd-84b28090d898");
        public Guid SystemGroup { get; } = Guid.Parse("59647e61-db07-4b43-993d-3f7eda18fe7f");
        public Guid SysteProduct { get; } = Guid.Parse("6ef793f6-0d6c-4a1a-a09d-1205f9986e74");
        public Guid SystemLancament { get; } = Guid.Parse("f9c4a519-2a0a-456f-b78c-9429a1a90a4b");
        public Guid SystemDelivery { get; } = Guid.Parse("c773d32a-f982-4892-8799-ca980fabf64d");
        public Guid SystemAddress { get; } = Guid.Parse("f9c4a519-2a0a-456f-b78c-9429a1a90a4b");
        public Guid SystemGuarantee { get; } = Guid.Parse("400ff5d8-e05c-4fb8-b9b7-9bba83f2022d");
        public Guid SystemAssessments { get; } = Guid.Parse("a708df8e-8c6d-48da-b033-169eab8b8fda");
    }
}