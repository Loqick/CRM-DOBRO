﻿using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

    public class Lead : Entity
    {
        public required int ContactId { get; set; }
        public int? SalerId { get; set; }
        public LeadStatus Status { get; set; }

        // Навигационные свойства
        public Contact? Contact { get; set; }
        public User? Saler { get; set; }
        public List<Sale> Sales { get; set; } = [];
    }

