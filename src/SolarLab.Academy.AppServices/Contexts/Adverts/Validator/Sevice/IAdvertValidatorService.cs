namespace SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Sevice;

public interface IAdvertValidatorService
{
    Task ValidateCategoryIdForAdvertAsync(Guid? categoryId, CancellationToken cancellationToken);
    Task ValidateIdForAdvertAsync(Guid? categoryId, CancellationToken cancellationToken);
}
