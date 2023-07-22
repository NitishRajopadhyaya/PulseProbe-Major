IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626161258_InitalMigration')
BEGIN
    CREATE TABLE [Patient] (
        [PatientId] int NOT NULL IDENTITY,
        [PatientFirstName] nvarchar(max) NOT NULL,
        [PatientLastName] nvarchar(max) NOT NULL,
        [Age] int NOT NULL,
        [Gender] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [PhoneNumber] int NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [BirthDate] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Patient] PRIMARY KEY ([PatientId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626161258_InitalMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230626161258_InitalMigration', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230627153128_SpecifyLength')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Patient]') AND [c].[name] = N'PatientLastName');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Patient] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Patient] ALTER COLUMN [PatientLastName] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230627153128_SpecifyLength')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Patient]') AND [c].[name] = N'PatientFirstName');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Patient] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Patient] ALTER COLUMN [PatientFirstName] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230627153128_SpecifyLength')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Patient]') AND [c].[name] = N'Gender');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Patient] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Patient] ALTER COLUMN [Gender] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230627153128_SpecifyLength')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Patient]') AND [c].[name] = N'Email');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Patient] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Patient] ALTER COLUMN [Email] nvarchar(100) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230627153128_SpecifyLength')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Patient]') AND [c].[name] = N'BirthDate');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Patient] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Patient] ALTER COLUMN [BirthDate] nvarchar(20) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230627153128_SpecifyLength')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Patient]') AND [c].[name] = N'Address');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Patient] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Patient] ALTER COLUMN [Address] nvarchar(50) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230627153128_SpecifyLength')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230627153128_SpecifyLength', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230701160546_ImagePropertAdded')
BEGIN
    ALTER TABLE [Patient] ADD [PatientImage] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230701160546_ImagePropertAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230701160546_ImagePropertAdded', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230701163314_DoctorModel')
BEGIN
    CREATE TABLE [Doctor] (
        [DoctorId] int NOT NULL IDENTITY,
        [FirstName] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Doctor] PRIMARY KEY ([DoctorId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230701163314_DoctorModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230701163314_DoctorModel', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702120127_AddedDoctorModel')
BEGIN
    ALTER TABLE [Doctor] ADD [Address] nvarchar(20) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702120127_AddedDoctorModel')
BEGIN
    ALTER TABLE [Doctor] ADD [Certificate] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702120127_AddedDoctorModel')
BEGIN
    ALTER TABLE [Doctor] ADD [ClinicJoinedDate] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702120127_AddedDoctorModel')
BEGIN
    ALTER TABLE [Doctor] ADD [Degree] nvarchar(20) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702120127_AddedDoctorModel')
BEGIN
    ALTER TABLE [Doctor] ADD [Email] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702120127_AddedDoctorModel')
BEGIN
    ALTER TABLE [Doctor] ADD [LicenseNumber] nvarchar(20) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702120127_AddedDoctorModel')
BEGIN
    ALTER TABLE [Doctor] ADD [PhoneNumber] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702120127_AddedDoctorModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702120127_AddedDoctorModel', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230710124804_Labproperty')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Doctor]') AND [c].[name] = N'ClinicJoinedDate');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Doctor] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Doctor] DROP COLUMN [ClinicJoinedDate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230710124804_Labproperty')
BEGIN
    EXEC sp_rename N'[Doctor].[LicenseNumber]', N'NMCNumber', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230710124804_Labproperty')
BEGIN
    CREATE TABLE [Lab] (
        [LabId] int NOT NULL IDENTITY,
        [LabName] nvarchar(50) NOT NULL,
        [LicsenceNumber] int NOT NULL,
        [Address] nvarchar(20) NOT NULL,
        [PhoneNumber] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Email] nvarchar(50) NOT NULL,
        [Image] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Lab] PRIMARY KEY ([LabId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230710124804_Labproperty')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230710124804_Labproperty', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230711131029_DoctorModelModified')
BEGIN
    EXEC sp_rename N'[Doctor].[Certificate]', N'Description', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230711131029_DoctorModelModified')
BEGIN
    ALTER TABLE [Doctor] ADD [Gender] nvarchar(10) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230711131029_DoctorModelModified')
BEGIN
    ALTER TABLE [Doctor] ADD [Qualification] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230711131029_DoctorModelModified')
BEGIN
    ALTER TABLE [Doctor] ADD [Speciality] nvarchar(100) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230711131029_DoctorModelModified')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230711131029_DoctorModelModified', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230711131809_labmodified')
BEGIN
    ALTER TABLE [Lab] ADD [District] nvarchar(20) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230711131809_labmodified')
BEGIN
    ALTER TABLE [Lab] ADD [Province] nvarchar(20) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230711131809_labmodified')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230711131809_labmodified', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717114527_Schedule')
BEGIN
    CREATE TABLE [TimeSchedule] (
        [ScheduleId] int NOT NULL IDENTITY,
        [DoctorId] int NOT NULL,
        [ClinicId] int NOT NULL,
        [StartingTime] nvarchar(30) NOT NULL,
        [EndingTime] nvarchar(30) NOT NULL,
        CONSTRAINT [PK_TimeSchedule] PRIMARY KEY ([ScheduleId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717114527_Schedule')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230717114527_Schedule', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717165756_schedulechanges')
BEGIN
    EXEC sp_rename N'[TimeSchedule].[DoctorId]', N'DId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230717165756_schedulechanges')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230717165756_schedulechanges', N'7.0.8');
END;
GO

COMMIT;
GO

