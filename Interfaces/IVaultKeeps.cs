namespace Keepr.Interfaces
{
  public interface IVaultKeeps
  {
    int Id { get; set; }
    int vaultId { get; set; }
    int keepId { get; set; }
    string userId { get; set; }
  }
}