USE MicroErp;

-- Create table for rules for user
CREATE TABLE System.UserRoles
(
    Id             UNIQUEIDENTIFIER PRIMARY KEY,
    CreatedAt      DATETIME         NOT NULL DEFAULT GETDATE(),
    UpdatedAt      DATETIME         NOT NULL DEFAULT GETDATE(),
    RemovedAt      DATETIME         NULL,
    RegisterActive BIT              NOT NULL DEFAULT 1,
    CreateBy       UNIQUEIDENTIFIER NOT NULL,
    UpdatedBy      UNIQUEIDENTIFIER NOT NULL,
    RemovedBy      UNIQUEIDENTIFIER NULL,

    -- Role fields
    UserId UNIQUEIDENTIFIER NOT NULL,
    RoleId UNIQUEIDENTIFIER NOT NULL,
    
    -- Fks
    CONSTRAINT FK_UserRoles_User FOREIGN KEY (UserId) REFERENCES System.Users (Id),
    CONSTRAINT FK_UserRoles_Role FOREIGN KEY (RoleId) REFERENCES System.Roles (Id)
)