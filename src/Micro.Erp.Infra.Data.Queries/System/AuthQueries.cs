namespace Micro.Erp.Infra.Data.Queries.System;

public static class AuthQueries
{
    public static string GetUserByEmail => @"SELECT * FROM [System].[Users] WHERE [Email] = @Email AND [RegisterActive] = 1";
    public static string GetUserById => @"SELECT * FROM [System].[Users] WHERE [Id] = @Id";
    public static string GetRolesById => @"SELECT * FROM [System].[Roles] WHERE [Id] = @Id";
    public static string GetUserTypeById => @"SELECT * FROM [System].[UserType] WHERE [Id] = @Id";
    public static string GetRolesByIds => @"SELECT * FROM [System].[Roles] WHERE [Id] IN @Ids AND [RegisterActive] = 1";
    public static string GetUserRolesByUserId => @"SELECT * FROM [System].[UserRoles] WHERE [UserId] = @UserId AND [RegisterActive] = 1";
}