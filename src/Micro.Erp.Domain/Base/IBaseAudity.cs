namespace Micro.Erp.Domain.Base;

public interface IBaseAudity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? RemovedAt { get; set; }
    public bool RegisterActive { get; set; }
    public Guid CreateBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public Guid? RemovedBy { get; set; }
}