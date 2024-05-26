﻿using System.Runtime.Serialization;

namespace CRM_DOBRO.Enums
{
    /// <summary>
    /// Enum for user roles
    /// </summary>
    public enum UserRole
    {
        [EnumMember(Value = "Admin")]
        Admin = 1,

        [EnumMember(Value = "Marketing")]
        Marketing,

        [EnumMember(Value = "Saler")]
        Saler
    }
}