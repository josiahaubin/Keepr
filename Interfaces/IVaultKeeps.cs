namespace Keepr.Interfaces
{
  public interface IVaultKeeps
  {
    int Id { get; set; }
    int VaultId { get; set; }
    int KeepId { get; set; }
    string UserId { get; set; }
  }
}