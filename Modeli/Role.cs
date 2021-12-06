using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amy_WebApplication.Modeli
{
    [Table("roles")]
    public class Role : IEntity<string>
    {
        [Key]

        [Column("id")]
        public string Id { get; set; }
        [Column("description")]
        public string Description { get; set; }

        public bool IsTransient()
        {
            return this.Id == default(string);
        }
    }
}
