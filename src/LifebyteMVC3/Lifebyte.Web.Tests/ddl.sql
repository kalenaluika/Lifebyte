
    if exists (select * from dbo.sysobjects where id = object_id(N'[Volunteer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [Volunteer]

    create table [Volunteer] (
        Id UNIQUEIDENTIFIER not null,
       Company NVARCHAR(100) null,
       Address NVARCHAR(200) null,
       State NVARCHAR(2) null,
       Zip NVARCHAR(10) null,
       PrimaryPhone NVARCHAR(10) null,
       SecondaryPhone NVARCHAR(10) null,
       Email NVARCHAR(200) null,
       FirstName NVARCHAR(50) null,
       LastName NVARCHAR(50) null,
       City NVARCHAR(50) null,
       Username NVARCHAR(50) null,
       Password NVARCHAR(50) null,
       LastSignInDate DATETIME null,
       CreateByVolunteerId UNIQUEIDENTIFIER null,
       CreateDate DATETIME null,
       LastModByVolunteerId UNIQUEIDENTIFIER null,
       LastModDate DATETIME null,
       Active BIT null,
       primary key (Id)
    )
