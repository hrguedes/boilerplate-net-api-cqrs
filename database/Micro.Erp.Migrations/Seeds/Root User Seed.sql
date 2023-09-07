USE MicroErp;

-- Insert data in table System.Roles
INSERT INTO System.Roles (Id, Name, Description, CreatedAt, UpdatedAt, RegisterActive, CreateBy, UpdatedBy, ValueKey)
VALUES 
    (NEWID(), 'Administrator', 'Administrator', GETDATE(), GETDATE(), 1, NEWID(), NEWID(), 'ADMIN'),
    (NEWID(), 'Support', 'Support', GETDATE(), GETDATE(), 1, NEWID(), NEWID(), 'SUPPORT');


-- Insert data in table System.UserTypes
INSERT INTO System.UserType (Id, Name, Description, CreatedAt, UpdatedAt, RegisterActive, CreateBy, UpdatedBy, ValueKey)
VALUES
    (NEWID(), 'Administrator', 'Administrator', GETDATE(), GETDATE(), 1, NEWID(), NEWID(), 'ADMIN'),
    (NEWID(), 'Support', 'Support', GETDATE(), GETDATE(), 1, NEWID(), NEWID(), 'SUPPORT'),
    (NEWID(), 'Client', 'Client', GETDATE(), GETDATE(), 1, NEWID(), NEWID(), 'CLIENT');

-- Insert data in table System.Users (Field Password is encrypted)
INSERT INTO System.Users (Id, Name, Email, Password, CreatedAt, UpdatedAt, RegisterActive, CreateBy, UpdatedBy, UserTypeId)
VALUES
    (NEWID(),  'Hugo Guedes', 'hugo.guedes@hrguedes.dev', '123123' , GETDATE(), GETDATE(), 1, NEWID(), NEWID(), (SELECT Id FROM System.UserType WHERE ValueKey = 'ADMIN'));

-- Insert data in table System.UserRoles
INSERT INTO System.UserRoles (Id, UserId, RoleId, CreatedAt, UpdatedAt, RegisterActive, CreateBy, UpdatedBy)
VALUES
    (NEWID(), (SELECT Id FROM System.Users WHERE Email = 'hugo.guedes@hrguedes.dev'), (SELECT Id FROM System.Roles WHERE ValueKey = 'ADMIN'), GETDATE(), GETDATE(), 1, NEWID(), NEWID()),
    (NEWID(), (SELECT Id FROM System.Users WHERE Email = 'hugo.guedes@hrguedes.dev'), (SELECT Id FROM System.Roles WHERE ValueKey = 'SUPPORT'), GETDATE(), GETDATE(), 1, NEWID(), NEWID());

