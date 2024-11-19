INSERT INTO "IdentityRoles" ("Id", "Name", "CreatedAt", "ModifiedAt")
VALUES
(0, 'Admin', NOW(), NOW()),
(1, 'Public User', NOW(), NOW());

INSERT INTO "IdentityUsers" ("Login", "Password", "CreatedAt", "ModifiedAt", "RoleId")
VALUES
('admin', 'minerale', NOW(), NOW(), 0),
('public', 'pub', NOW(), NOW(), 1);