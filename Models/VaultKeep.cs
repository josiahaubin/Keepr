using Keepr.Interfaces;

namespace Keepr.Models
{
  public class VaultKeep : IVaultKeeps
  {
    public int Id { get; set; }
    public int vaultId { get; set; }
    public int keepId { get; set; }
    public string userId { get; set; }
  }
}