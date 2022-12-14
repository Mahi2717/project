IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Admin] (
    [AdminId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    CONSTRAINT [PK_Admin] PRIMARY KEY ([AdminId])
);

GO

CREATE TABLE [Contactus] (
    [Cid] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Type] nvarchar(max) NULL,
    [Message] nvarchar(max) NULL,
    CONSTRAINT [PK_Contactus] PRIMARY KEY ([Cid])
);

GO

CREATE TABLE [Flight] (
    [Id] int NOT NULL IDENTITY,
    [Fname] nvarchar(max) NULL,
    [Fsource] nvarchar(max) NULL,
    [Fdestination] nvarchar(max) NULL,
    [Fdepttime] datetime2 NOT NULL,
    [Farrtime] datetime2 NOT NULL,
    [Totpass] nvarchar(max) NULL,
    [BusinessFare] nvarchar(max) NULL,
    [FirstclassFare] nvarchar(max) NULL,
    [EconomyFare] nvarchar(max) NULL,
    CONSTRAINT [PK_Flight] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [Fname] nvarchar(max) NULL,
    [Lname] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [Mobile] nvarchar(max) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Booking] (
    [BookingId] int NOT NULL IDENTITY,
    [FlightId] int NOT NULL,
    [UserId] int NOT NULL,
    [BookingDate] datetime2 NOT NULL,
    [PName] nvarchar(max) NULL,
    [PAge] nvarchar(max) NULL,
    [PGender] nvarchar(max) NULL,
    [Source] nvarchar(max) NULL,
    [Destination] nvarchar(max) NULL,
    [Class] nvarchar(max) NULL,
    [Fare] nvarchar(max) NULL,
    CONSTRAINT [PK_Booking] PRIMARY KEY ([BookingId]),
    CONSTRAINT [FK_Booking_Flight_FlightId] FOREIGN KEY ([FlightId]) REFERENCES [Flight] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Booking_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Booking_FlightId] ON [Booking] ([FlightId]);

GO

CREATE INDEX [IX_Booking_UserId] ON [Booking] ([UserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221208182307_FirstMig', N'3.1.30');

GO

