﻿using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.User.Repository;

/// <summary>
/// Интерфейс репоозитория по работе с пользователями.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="dto">Объект передачи данных регистрации пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных пользователя.</returns>
    Task<UserDto> RegisterAsync(UserRegisterRequestDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получение пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных пользователя.</returns>
    Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение пользователя по логину.
    /// </summary>
    /// <param name="dto">Объект передачи данных входа пользователя в систему.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Токен авторизации.</returns>
    Task<UserLoginResponseDto?> GetByLoginAsync(UserLoginRequestDto dto, CancellationToken cancellationToken);
}
