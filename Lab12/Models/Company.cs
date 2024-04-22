using System.ComponentModel.DataAnnotations.Schema;

[Table("Companies")]
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
}