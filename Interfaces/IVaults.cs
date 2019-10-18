namespace Keepr.Interfaces
{
  public interface IVaults
  {
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string UserId { get; set; }
  }
}