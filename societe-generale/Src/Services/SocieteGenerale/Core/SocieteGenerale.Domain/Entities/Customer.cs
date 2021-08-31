using SocieteGenerale.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocieteGenerale.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        private DateTime birthDate { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth
        {
            get { return birthDate; }
            set { birthDate = value.Date; }
        }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }       
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
