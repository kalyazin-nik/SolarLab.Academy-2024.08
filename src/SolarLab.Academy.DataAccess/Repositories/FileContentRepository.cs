﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Contexts.FileContent.Repositories;
using SolarLab.Academy.Contracts.FileContents;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories;

/// <summary>
/// Репозиторий по работе с файлами.
/// </summary>
/// <param name="repository">Основной репозиторий.</param>
/// <param name="mapper">Маппер.</param>
public class FileContentRepository(IRepository<FileContent, AcademyDbContext> repository, IMapper mapper) : IFileContentRepository
{
    private readonly IRepository<FileContent, AcademyDbContext> _repository = repository;
    private readonly IMapper _mapper = mapper;

    /// <inheritdoc />
    public async Task<Guid> UploadAsync(FileContentDto fileContentDto, CancellationToken cancellationToken)
    {
        var fileContent = _mapper.Map<FileContentDto, FileContent>(fileContentDto);
        await _repository.AddAsync(fileContent, cancellationToken);

        return fileContent.Id;
    }

    /// <inheritdoc />
    public async Task<FileContentDto?> GetFileAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetAll()
            .Where(x => x.Id == id)
            .ProjectTo<FileContentDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);    
    }

    /// <inheritdoc />
    public async Task<FileContentInfoDto?> GetFileInfoByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetAll()
            .Where(x => x.Id == id)
            .ProjectTo<FileContentInfoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
