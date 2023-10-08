using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("tb_m_employees")]
public class Employee
{

    [Key]
    [Column("guid")]
    public Guid Guid { get; set; }

    [Column("name", TypeName = "varchar(50)")]
    public string Name { get; set; }

    [Column("department", TypeName = "varchar(50)")]
    public string Department { get; set; }

    [Column("email", TypeName = "varchar(50)")]
    public string Email { get; set; }

    [Column("photoPath", TypeName = "varchar(255)")]
    public string PhotoPath { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }
}
