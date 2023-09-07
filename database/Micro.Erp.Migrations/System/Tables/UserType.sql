USE MicroErp;

-- Create table for user type
CREATE TABLE System.UserType
(
    -- Base fields Audit
    Id             UNIQUEIDENTIFIER PRIMARY KEY,
    CreatedAt      DATETIME         NOT NULL DEFAULT GETDATE(),
    UpdatedAt      DATETIME         NOT NULL DEFAULT GETDATE(),
    RemovedAt      DATETIME         NULL,
    RegisterActive BIT              NOT NULL DEFAULT 1,
    CreateBy       UNIQUEIDENTIFIER NOT NULL,
    UpdatedBy      UNIQUEIDENTIFIER NOT NULL,
    RemovedBy      UNIQUEIDENTIFIER NULL,

    -- Role fields
    Name           NVARCHAR(50)     NOT NULL,
    ValueKey       NVARCHAR(50)     NOT NULL,
    Description    NVARCHAR(250)    NULL,
    Active         BIT              NOT NULL DEFAULT 1
)