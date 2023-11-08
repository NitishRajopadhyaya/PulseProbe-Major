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

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230721115518_Fkadded')
BEGIN
    EXEC sp_rename N'[TimeSchedule].[DId]', N'DoctorId', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230721115518_Fkadded')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TimeSchedule]') AND [c].[name] = N'StartingTime');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [TimeSchedule] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [TimeSchedule] ALTER COLUMN [StartingTime] nvarchar(30) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230721115518_Fkadded')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TimeSchedule]') AND [c].[name] = N'EndingTime');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [TimeSchedule] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [TimeSchedule] ALTER COLUMN [EndingTime] nvarchar(30) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230721115518_Fkadded')
BEGIN
    CREATE INDEX [IX_TimeSchedule_DoctorId] ON [TimeSchedule] ([DoctorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230721115518_Fkadded')
BEGIN
    ALTER TABLE [TimeSchedule] ADD CONSTRAINT [FK_TimeSchedule_Doctor_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctor] ([DoctorId]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230721115518_Fkadded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230721115518_Fkadded', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230723173405_UpdatedModels')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Patient]') AND [c].[name] = N'PatientImage');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Patient] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Patient] DROP COLUMN [PatientImage];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230723173405_UpdatedModels')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Lab]') AND [c].[name] = N'Image');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Lab] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Lab] DROP COLUMN [Image];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230723173405_UpdatedModels')
BEGIN
    EXEC sp_rename N'[Lab].[Province]', N'state', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230723173405_UpdatedModels')
BEGIN
    ALTER TABLE [Patient] ADD [District] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230723173405_UpdatedModels')
BEGIN
    ALTER TABLE [Patient] ADD [Municiplaity] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230723173405_UpdatedModels')
BEGIN
    ALTER TABLE [Patient] ADD [PatientMiddleName] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230723173405_UpdatedModels')
BEGIN
    ALTER TABLE [Patient] ADD [WardNo] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230723173405_UpdatedModels')
BEGIN
    ALTER TABLE [Patient] ADD [state] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230723173405_UpdatedModels')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230723173405_UpdatedModels', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230724154038_clinicLabservices')
BEGIN
    ALTER TABLE [Lab] ADD [Laltitude] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230724154038_clinicLabservices')
BEGIN
    ALTER TABLE [Lab] ADD [Longitude] decimal(18,2) NOT NULL DEFAULT 0.0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230724154038_clinicLabservices')
BEGIN
    CREATE TABLE [ServicesProvided] (
        [ServiceId] int NOT NULL IDENTITY,
        [ServiceName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ServicesProvided] PRIMARY KEY ([ServiceId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230724154038_clinicLabservices')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230724154038_clinicLabservices', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230725151114_LabtoHealthcareModel')
BEGIN
    DROP TABLE [Lab];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230725151114_LabtoHealthcareModel')
BEGIN
    CREATE TABLE [HealthcareCenter] (
        [HealthCareCenterId] int NOT NULL IDENTITY,
        [HealthCareCenterName] nvarchar(50) NOT NULL,
        [LicsenceNumber] int NOT NULL,
        [PanNumber] nvarchar(max) NOT NULL,
        [Address] nvarchar(20) NOT NULL,
        [state] nvarchar(20) NOT NULL,
        [District] nvarchar(20) NOT NULL,
        [PhoneNumber] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Email] nvarchar(50) NOT NULL,
        [Laltitude] decimal(18,2) NOT NULL,
        [Longitude] decimal(18,2) NOT NULL,
        [Type] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_HealthcareCenter] PRIMARY KEY ([HealthCareCenterId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230725151114_LabtoHealthcareModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230725151114_LabtoHealthcareModel', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230725173048_Booking')
BEGIN
    CREATE TABLE [Booking] (
        [BookingId] int NOT NULL IDENTITY,
        [PatientId] int NOT NULL,
        [DoctorId] int NOT NULL,
        [ClinicId] int NOT NULL,
        [Time] nvarchar(20) NOT NULL,
        [BookedDate] nvarchar(20) NOT NULL,
        CONSTRAINT [PK_Booking] PRIMARY KEY ([BookingId]),
        CONSTRAINT [FK_Booking_Doctor_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [Doctor] ([DoctorId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Booking_HealthcareCenter_ClinicId] FOREIGN KEY ([ClinicId]) REFERENCES [HealthcareCenter] ([HealthCareCenterId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Booking_Patient_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patient] ([PatientId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230725173048_Booking')
BEGIN
    CREATE INDEX [IX_Booking_ClinicId] ON [Booking] ([ClinicId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230725173048_Booking')
BEGIN
    CREATE INDEX [IX_Booking_DoctorId] ON [Booking] ([DoctorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230725173048_Booking')
BEGIN
    CREATE INDEX [IX_Booking_PatientId] ON [Booking] ([PatientId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230725173048_Booking')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230725173048_Booking', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230728183652_TransactionTable')
BEGIN
    CREATE TABLE [Transaction] (
        [TransactionId] int NOT NULL IDENTITY,
        [ClinicId] int NOT NULL,
        [DoctorId] int NOT NULL,
        [PatientId] int NOT NULL,
        [Token] nvarchar(max) NOT NULL,
        [Amount] int NOT NULL,
        [RequestJson] nvarchar(max) NOT NULL,
        [ResponseJson] nvarchar(max) NOT NULL,
        [Status] bit NOT NULL,
        CONSTRAINT [PK_Transaction] PRIMARY KEY ([TransactionId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230728183652_TransactionTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230728183652_TransactionTable', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230817171201_Pricesetupclinicservices')
BEGIN
    CREATE TABLE [ClinicLabServicesPrice] (
        [PriceId] int NOT NULL IDENTITY,
        [ClinicId] int NOT NULL,
        [ServiceId] int NOT NULL,
        [price] int NOT NULL,
        CONSTRAINT [PK_ClinicLabServicesPrice] PRIMARY KEY ([PriceId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230817171201_Pricesetupclinicservices')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230817171201_Pricesetupclinicservices', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818120706_account')
BEGIN
    CREATE TABLE [UserAccount] (
        [UserId] int NOT NULL IDENTITY,
        [Password] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Roles] nvarchar(max) NOT NULL,
        [RegisteredDate] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_UserAccount] PRIMARY KEY ([UserId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230818120706_account')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230818120706_account', N'7.0.8');
END;
GO

COMMIT;
GO

