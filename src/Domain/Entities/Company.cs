using System;
using Domain.Enums;

namespace Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Province Province { get; set; }

        public DateTime Created { get; set; }
    }
}
