using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Contexts.User.Repository;
using SolarLab.Academy.AppServices.Helpers;
using SolarLab.Academy.Contracts.User;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories;

/// <summary>
/// Репозиторий по работе с пользователями.
/// </summary>
/// <param name="repository">Репозиторий.</param>
/// <param name="mapper">Маппер.</param>
public class UserRepository(IRepository<User, AcademyDbContext> repository, IMapper mapper) : IUserRepository
{
    private readonly IRepository<User, AcademyDbContext> _repository = repository;
    private readonly IMapper _mapper = mapper;

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAll()
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var userDto = await _repository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<UserDto>(userDto);
    }

    /// <inheritdoc />
    public async Task<UserLoginResponseDto?> GetByLoginAsync(UserLoginRequestDto dto, CancellationToken cancellationToken)
    {
        return await _repository.GetAll()
            .Where(x => x.Login == dto.Login)
            .ProjectTo<UserLoginResponseDto>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<UserDto> RegisterAsync(UserRegisterRequestDto userRegister, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<UserRegisterRequestDto, User>(userRegister);
        await _repository.AddAsync(user, cancellationToken);

        return _mapper.Map<User,  UserDto>(user);
    }
}
