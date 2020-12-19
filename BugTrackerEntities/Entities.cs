using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTrackerEntities
{
    public class BugTrackerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int ZipCode { get; set; }
    }

    public class User
    {
        [Key]   //superfluo perchè UserId segue già la convenzione
        public int UserId { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        [Index(IsUnique = true)]
        public string Login { get; set; }
        [Required]
        [MinLength(16)]
        //Cryptare la password
        public string Password { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [MinLength(16)]
        [MaxLength(16)]
        [Index(IsUnique = true)]
        public string FiscalCode { get; set; }
        public DateTime BirthDate { get; set; }
        [NotMapped]
        public int Age { get { return System.DateTime.Now.Year - BirthDate.Year; } }
        public Address Address { get; set; }
    }

    public class Product
    {
        [Key] //Serve [Key] perchè code non segue la convenzione
        public int Code { get; set; }
        [Required]
        public string CommercialName { get; set; }
        [Required]
        public string InternalName { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        [InverseProperty(nameof(Depended))]
        public virtual  ICollection<Product> DependsOn { get; set; }
        [InverseProperty(nameof(DependsOn))]
        public virtual ICollection<Product> Depended { get; set; }
        [InverseProperty(nameof(IncompatibleWith1))]
        public virtual ICollection<Product> IncopatibleWith { get; set; }
        [InverseProperty(nameof(IncopatibleWith))]
        public virtual ICollection<Product> IncompatibleWith1 { get; set; }
    }
}
