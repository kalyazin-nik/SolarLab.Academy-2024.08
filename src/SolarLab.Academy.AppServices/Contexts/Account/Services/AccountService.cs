using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.AppServices.Contexts.User.Repository;
using SolarLab.Academy.AppServices.Helpers;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.AppServices.Validator;
using SolarLab.Academy.Contracts.Enums;
using SolarLab.Academy.Contracts.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SolarLab.Academy.AppServices.Contexts.Account.Services;

/// <summary>
/// Сервис по работе с аккаунтами пользователей.
/// </summary>
/// <param name="userRepository">Репозиторий по работе с пользователями.</param>
/// <param name="configuration">Конфигурация приложения.</param>
/// <param name="validationService">Сервис валидации объектов.</param>
/// <param name="httpContextAccessor">Доступ к контексту Http.</param>
/// <param name="logger">Логгер <see cref="AccountService"/></param>
/// <param name="structuralLoggingService">Служба структурного логгирования.</param>
public class AccountService(
    IUserRepository userRepository, 
    IConfiguration configuration,
    IValidationService validationService,
    IHttpContextAccessor httpContextAccessor,
    ILogger<AdvertService> logger,
    IStructuralLoggingService structuralLoggingService) : IAccountService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IConfiguration _configuration = configuration;
    private readonly IValidationService _validationService = validationService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly ILogger<AdvertService> _logger = logger;
    private readonly IStructuralLoggingService _structuralLoggingService = structuralLoggingService;

    /// <inheritdoc />
    public async Task<UserDto> RegisterAsync(UserRegisterRequestDto userRegister, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("UserRegister", userRegister!, true);
        _logger.LogInformation("Создание объявления: {@userRegister}", userRegister);

        return await _userRepository.RegisterAsync(userRegister, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<string> LoginAsync(UserLoginRequestDto dto, CancellationToken cancellationToken)
    {
        var existUser = await _userRepository.GetByLoginAsync(dto, cancellationToken) ?? throw new Exception("Пользлователь не найден!");
        if (existUser.Password != CryptoHelper.GetBase64Hash(dto.Password))
        {
            throw new Exception("Неверный пароль!");
        }

        var secretKey = _configuration["Jwt:Key"]!;
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, existUser.Id.ToString()),
            new(ClaimTypes.Name, existUser.Name)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256
            )
        );

        var result = new JwtSecurityTokenHandler().WriteToken(token);
        return result.ToString();
    }

    /// <inheritdoc />
    public async Task<UserDto> GetCurrentUserAsync(CancellationToken cancellationToken)
    {
        var claims = _httpContextAccessor.HttpContext.User.Claims;
        using var _ = _structuralLoggingService.PushProperty("Claims", claims, true);
        _logger.LogInformation("Получение текущего пользователя: {@claims}", claims);

        var claimId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        var id = await _validationService.BeforExecuteRequestValidate_ExistEntityAsync(
            RepositoriesTypes.UserRepository, claimId is not null ? Guid.Parse(claimId) : null, cancellationToken);

        return await _userRepository.GetByIdAsync(id, cancellationToken);
    }
}
