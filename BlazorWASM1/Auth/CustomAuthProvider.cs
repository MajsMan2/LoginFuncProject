﻿using System.Security.Claims;
using BlazorWasm1.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWasm1.Auth;

public class CustomAuthProvider : AuthenticationStateProvider
{
    private readonly IAuthService _authService;

    public CustomAuthProvider(IAuthService authService)
    {
        this ._authService = authService;
        authService.OnAuthStateChanged += AuthStateChanged;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await _authService.GetAuthAsync();

        return new AuthenticationState(principal);
    }

    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}