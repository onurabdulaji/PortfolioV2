namespace PortfolioV2.Domain.Entities.IBase;

public interface IBaseEntity
{
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool Status { get; set; }
}
