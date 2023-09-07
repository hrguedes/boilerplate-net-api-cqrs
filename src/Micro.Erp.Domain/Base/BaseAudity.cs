using FluentValidation;
using FluentValidation.Results;

namespace Micro.Erp.Domain.Base;

public class BaseAudity : IBaseAudity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? RemovedAt { get; set; }
    public bool RegisterActive { get; set; }
    public Guid CreateBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public Guid? RemovedBy { get; set; }
    
    #region Validations and Notifications
    private bool Valid { get; set; }
    public bool Invalid => !Valid;
    private ValidationResult ValidationResult { get; set; }
    #endregion
    
    #region Methods
    public void Delete(Guid deletedBy)
    {
        RemovedAt = DateTime.Now;
        RegisterActive = false;
        RemovedBy = deletedBy;
    }
    
    public void Update(Guid updatedBy, bool active = true)
    {
        UpdatedAt = DateTime.Now;
        RegisterActive = active;
        UpdatedBy = updatedBy;
    }
    
    protected bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
    {
        ValidationResult = validator.Validate(model);
        return Valid = ValidationResult.IsValid;
    }
    #endregion
    
    protected BaseAudity()
    {
        if (Id == Guid.Empty)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            RegisterActive = true;
        } else {
            UpdatedAt = DateTime.Now;
        }
    }
}