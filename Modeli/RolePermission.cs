using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amy_WebApplication.Modeli
{
    [Table("rolepermissions")]
    public class RolePermission
    {
        [Key]

        [Column("role_id")]
        public string RoleId { get; set; }
        [Column("permission_id")]
        public string PermissionId { get; set; }
    }
}
