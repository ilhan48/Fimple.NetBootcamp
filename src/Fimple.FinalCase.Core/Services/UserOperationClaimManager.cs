﻿using Fimple.FinalCase.Core.Entities.Identity;
using Fimple.FinalCase.Core.Features.UserOperationClaims.Rules;
using Fimple.FinalCase.Core.Ports.Driven;
using Fimple.FinalCase.Core.Ports.Driving;
using Fimple.FinalCase.Core.Utilities.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Fimple.FinalCase.Core.Services;

public class UserUserOperationClaimManager : IUserOperationClaimService
{
    private readonly IUserOperationClaimRepository _userUserOperationClaimRepository;
    private readonly UserOperationClaimBusinessRules _userUserOperationClaimBusinessRules;

    public UserUserOperationClaimManager(
        IUserOperationClaimRepository userUserOperationClaimRepository,
        UserOperationClaimBusinessRules userUserOperationClaimBusinessRules
    )
    {
        _userUserOperationClaimRepository = userUserOperationClaimRepository;
        _userUserOperationClaimBusinessRules = userUserOperationClaimBusinessRules;
    }

    public async Task<UserOperationClaim?> GetAsync(
        Expression<Func<UserOperationClaim, bool>> predicate,
        Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserOperationClaim? userUserOperationClaim = await _userUserOperationClaimRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUserOperationClaim;
    }

    public async Task<IPaginate<UserOperationClaim>?> GetListAsync(
        Expression<Func<UserOperationClaim, bool>>? predicate = null,
        Func<IQueryable<UserOperationClaim>, IOrderedQueryable<UserOperationClaim>>? orderBy = null,
        Func<IQueryable<UserOperationClaim>, IIncludableQueryable<UserOperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserOperationClaim> userUserOperationClaimList = await _userUserOperationClaimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUserOperationClaimList;
    }

    public async Task<UserOperationClaim> AddAsync(UserOperationClaim userUserOperationClaim)
    {
        await _userUserOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenInsert(
            userUserOperationClaim.UserId,
            userUserOperationClaim.OperationClaimId
        );

        UserOperationClaim addedUserOperationClaim = await _userUserOperationClaimRepository.AddAsync(userUserOperationClaim);

        return addedUserOperationClaim;
    }

    public async Task<UserOperationClaim> UpdateAsync(UserOperationClaim userUserOperationClaim)
    {
        await _userUserOperationClaimBusinessRules.UserShouldNotHasOperationClaimAlreadyWhenUpdated(
            userUserOperationClaim.Id,
            userUserOperationClaim.UserId,
            userUserOperationClaim.OperationClaimId
        );

        UserOperationClaim updatedUserOperationClaim = await _userUserOperationClaimRepository.UpdateAsync(userUserOperationClaim);

        return updatedUserOperationClaim;
    }

    public async Task<UserOperationClaim> DeleteAsync(UserOperationClaim userUserOperationClaim, bool permanent = false)
    {
        UserOperationClaim deletedUserOperationClaim = await _userUserOperationClaimRepository.DeleteAsync(userUserOperationClaim);

        return deletedUserOperationClaim;
    }
}
