USE MicroErp;

-- Create table for users
CREATE TABLE System.Users
(
    -- Base fields Audity
    Id             UNIQUEIDENTIFIER PRIMARY KEY,
    CreatedAt      DATETIME         NOT NULL DEFAULT GETDATE(),
    UpdatedAt      DATETIME         NOT NULL DEFAULT GETDATE(),
    RemovedAt      DATETIME         NULL,
    RegisterActive BIT              NOT NULL DEFAULT 1,
    CreateBy       UNIQUEIDENTIFIER NOT NULL,
    UpdatedBy      UNIQUEIDENTIFIER NOT NULL,
    RemovedBy      UNIQUEIDENTIFIER NULL,

    -- User Data
    Name           VARCHAR(250)     NOT NULL,
    Email          VARCHAR(250)     NOT NULL,
    Password       NVARCHAR(MAX)    NOT NULL,
    
    -- Fks
    UserTypeId    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_User_UserType FOREIGN KEY (UserTypeId) REFERENCES System.UserType(Id)
)