CREATE TABLE [dbo].[Countries] (
    [CountryId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Countries] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

CREATE TABLE [dbo].[Ranks] (
    [RankId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Ranks] PRIMARY KEY CLUSTERED ([RankId] ASC)
);

CREATE TABLE [dbo].[Trainings] (
    [TrainingId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Trainings] PRIMARY KEY CLUSTERED ([TrainingId] ASC)
);

CREATE TABLE [dbo].[Soldiers] (
    [SoldierId]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [Latitude]   FLOAT (53)     NOT NULL,
    [Longitude]  FLOAT (53)     NOT NULL,
    [CountryId]  INT            NOT NULL,
    [RankId]     INT            NOT NULL,
    [TrainingId] INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.Soldiers] PRIMARY KEY CLUSTERED ([SoldierId] ASC),
    CONSTRAINT [FK_dbo.Soldiers_dbo.Trainings_TrainingId] FOREIGN KEY ([TrainingId]) REFERENCES [dbo].[Trainings] ([TrainingId]),
    CONSTRAINT [FK_dbo.Soldiers_dbo.Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([CountryId]),
    CONSTRAINT [FK_dbo.Soldiers_dbo.Ranks_RankId] FOREIGN KEY ([RankId]) REFERENCES [dbo].[Ranks] ([RankId])
);


GO
CREATE NONCLUSTERED INDEX [IX_CountryId]
    ON [dbo].[Soldiers]([CountryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RankId]
    ON [dbo].[Soldiers]([RankId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TrainingId]
    ON [dbo].[Soldiers]([TrainingId] ASC);

SET IDENTITY_INSERT [dbo].[Countries] ON
INSERT INTO [dbo].[Countries] ([CountryId], [Name]) VALUES (1, N'Germany')
INSERT INTO [dbo].[Countries] ([CountryId], [Name]) VALUES (2, N'France')
INSERT INTO [dbo].[Countries] ([CountryId], [Name]) VALUES (3, N'Romania')
INSERT INTO [dbo].[Countries] ([CountryId], [Name]) VALUES (4, N'Italy')
INSERT INTO [dbo].[Countries] ([CountryId], [Name]) VALUES (5, N'Spain')
INSERT INTO [dbo].[Countries] ([CountryId], [Name]) VALUES (6, N'United Kingdom')
INSERT INTO [dbo].[Countries] ([CountryId], [Name]) VALUES (7, N'Netherlands')
INSERT INTO [dbo].[Countries] ([CountryId], [Name]) VALUES (8, N'Sweden')
INSERT INTO [dbo].[Countries] ([CountryId], [Name]) VALUES (9, N'Poland')
INSERT INTO [dbo].[Countries] ([CountryId], [Name]) VALUES (10, N'Norway')
SET IDENTITY_INSERT [dbo].[Countries] OFF

SET IDENTITY_INSERT [dbo].[Ranks] ON
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (1, N'Private')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (2, N'Lance Corporal')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (3, N'Corporal')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (4, N'Sergeant')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (5, N'Staff Sergeant')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (6, N'Warrant Officer Class 2')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (7, N'Warrant Officer Class 1')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (8, N'Second Lieutenant')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (9, N'Lieutenant')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (10, N'Captain')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (11, N'Major')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (12, N'Lieutenant Colonel')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (13, N'Colonel')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (14, N'Brigadier')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (15, N'Major General')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (16, N'Lieutenant General')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (17, N'General')
INSERT INTO [dbo].[Ranks] ([RankId], [Name]) VALUES (18, N'Field Marshal (five-star)')
SET IDENTITY_INSERT [dbo].[Ranks] OFF

SET IDENTITY_INSERT [dbo].[Trainings] ON
INSERT INTO [dbo].[Trainings] ([TrainingId], [Name]) VALUES (1, N'Endurance Training')
INSERT INTO [dbo].[Trainings] ([TrainingId], [Name]) VALUES (2, N'Strength Training')
INSERT INTO [dbo].[Trainings] ([TrainingId], [Name]) VALUES (3, N'Agility and Speed Training')
INSERT INTO [dbo].[Trainings] ([TrainingId], [Name]) VALUES (4, N'Flexibility and Mobility Training')
INSERT INTO [dbo].[Trainings] ([TrainingId], [Name]) VALUES (5, N'Functional Training')
SET IDENTITY_INSERT [dbo].[Trainings] OFF

SET IDENTITY_INSERT [dbo].[Soldiers] ON
INSERT INTO [dbo].[Soldiers] ([SoldierId], [Name], [Latitude], [Longitude], [CountryId], [RankId], [TrainingId]) VALUES (7, N'Hans Müller', 52.52, 13.405, 1, 1, 1)
INSERT INTO [dbo].[Soldiers] ([SoldierId], [Name], [Latitude], [Longitude], [CountryId], [RankId], [TrainingId]) VALUES (8, N'Pierre Dubois', 48.8566, 2.3522, 2, 3, 2)
INSERT INTO [dbo].[Soldiers] ([SoldierId], [Name], [Latitude], [Longitude], [CountryId], [RankId], [TrainingId]) VALUES (9, N'Ion Popescu', 44.4268, 26.1025, 3, 4, 5)
INSERT INTO [dbo].[Soldiers] ([SoldierId], [Name], [Latitude], [Longitude], [CountryId], [RankId], [TrainingId]) VALUES (10, N'Luca Rossi', 41.9028, 12.4964, 4, 6, 3)
INSERT INTO [dbo].[Soldiers] ([SoldierId], [Name], [Latitude], [Longitude], [CountryId], [RankId], [TrainingId]) VALUES (11, N'Carlos Garcia', 40.4168, -3.7038, 5, 5, 4)
INSERT INTO [dbo].[Soldiers] ([SoldierId], [Name], [Latitude], [Longitude], [CountryId], [RankId], [TrainingId]) VALUES (12, N'John Smith', 51.5074, -0.1278, 6, 2, 1)
INSERT INTO [dbo].[Soldiers] ([SoldierId], [Name], [Latitude], [Longitude], [CountryId], [RankId], [TrainingId]) VALUES (13, N'Jan de Vries', 52.3676, 4.9041, 7, 3, 2)
INSERT INTO [dbo].[Soldiers] ([SoldierId], [Name], [Latitude], [Longitude], [CountryId], [RankId], [TrainingId]) VALUES (14, N'Erik Johansson', 59.3293, 18.0686, 8, 1, 3)
INSERT INTO [dbo].[Soldiers] ([SoldierId], [Name], [Latitude], [Longitude], [CountryId], [RankId], [TrainingId]) VALUES (15, N'Piotr Nowak', 52.2297, 21.0122, 9, 4, 4)
INSERT INTO [dbo].[Soldiers] ([SoldierId], [Name], [Latitude], [Longitude], [CountryId], [RankId], [TrainingId]) VALUES (16, N'Olav Hansen', 59.9139, 10.7522, 10, 2, 5)
SET IDENTITY_INSERT [dbo].[Soldiers] OFF
