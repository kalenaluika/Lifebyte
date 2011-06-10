
    if exists (select * from dbo.sysobjects where id = object_id(N'[Volunteer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Volunteer]

    create table [Volunteer] (
        Id UNIQUEIDENTIFIER not null,
       FirstName NVARCHAR(50) null,
       LastName NVARCHAR(50) null,
       Address NVARCHAR(50) null,
       City NVARCHAR(50) null,
       State NVARCHAR(50) null,
       Zip NVARCHAR(50) null,
       PrimaryPhone NVARCHAR(50) null,
       SecondaryPhone NVARCHAR(50) null,
       Email NVARCHAR(50) null,
       Username NVARCHAR(50) null,
       Password NVARCHAR(50) null,
       LastSignInDate DATETIME null,
       Active BIT null,
       primary key (Id)
    )
