drop database SiyayaTravelAssist
go

create database SiyayaTravelAssist
go


use SiyayaTravelAssist
go

create table EmployeeType(
	EmployeeTypeID int identity (1,1) primary key not null,
	EmployeeTypeDescription varchar(50)
);


create table AuditTrail(
	AuditTrailID int identity (1,1) primary key not null,
	AuditTrailDate DateTime,
	AuditTrailTime DateTime
);

create table Gender(
	GenderID int identity (1,1) primary key not null,
	GenderDescription varchar(50)
);



create table Nationality(
	NationalityID int identity (1,1) primary key not null,
	NationalityDescription varchar(50)
);

create table Title(
	TitleID int identity (1,1) primary key not null,
	TitleDescription varchar(50)
);

create table Country(
	CountryID int identity (1,1) primary key not null,
	CountryDescription varchar(50)
);

create table Province(
	ProvinceID int identity (1,1) primary key not null,
	ProvinceDescription varchar(50)
);

create table City(
	CityID int identity (1,1) primary key not null,
	CityDescription varchar(50)
);

create table Suburb(
	SuburbID int identity (1,1) primary key not null,
	SuburbDescription varchar(50)
);

create table AccessLevel(
	AccessLevelID int identity (1,1) primary key not null,
	AccessLevelDescription varchar(50)
);

create table Employee(
	EmployeeID int identity (1,1) primary key not null,
	FirstName varchar(50),
	LastName varchar(50),
	EmailAddress varchar(254),
	Telephone varchar(50),
	DateOfBirth dateTime,
	Password nvarchar(MAX),
	IsEmailVerified bit,
	EmployeeTypeID int REFERENCES EmployeeType(EmployeeTypeID),
	CountryID int REFERENCES Country(CountryID),
	TitleID int REFERENCES Title(TitleID),
	ProvinceID int REFERENCES Province(ProvinceID),
	SuburbID int REFERENCES Suburb(SuburbID),
	AuditTrailID int REFERENCES AuditTrail(AuditTrailID),
	AccessLevelID int REFERENCES AccessLevel(AccessLevelID),
	NationalityID int REFERENCES Nationality(NationalityID),
	CityID int REFERENCES City(CityID),
	Gender int REFERENCES Gender(GenderID)
);



create table DriverType(
	DriverTypeID int identity (1,1) primary key not null,
	DriverTypeDescription varchar(50)
);
create table LicenseType(
	LicenseTypeID int identity (1,1) primary key not null,
	LicenseTypeDescription varchar(50)
);

create table Driver(
	DriverID int identity (1,1) primary key not null,
	LicenseNumber varchar(50),
	LicenseExpiryDate DateTime,
	OutsourceName varchar(50),
	OutsourceNumber varchar(50),
	OutsourseIdentityNumber varchar(50),
	LicenseTypeID int REFERENCES LicenseType(LicenseTypeID),
	DriverTypeID int REFERENCES DriverType(DriverTypeID),
	EmployeeID int REFERENCES Employee(EmployeeID),
);

create table VehicleType(
	VehicleTypeID int identity (1,1) primary key not null,
	VehicleTypeDescription varchar(50)
);
create table VehicleModelType(
	VehicleModelTypeID int identity (1,1) primary key not null,
	VehicleModelTypeDescription varchar(50)
);
create table VehicleBrandType(
	VehicleBrandTypeID int identity (1,1) primary key not null,
	VehicleBrandTypeDescription varchar(50),
	VehicleModelTypeID int REFERENCES VehicleModelType(VehicleModelTypeID)
);

create table VehicleColor(
	VehicleColorID int identity (1,1) primary key not null,
	VehicleColorDescription varchar(50)
);

create table OutsourceVehicleGroupCompanies(
	OutsourceVehicleGroupCompaniesID int identity (1,1) primary key not null,
	OutsourceVehicleGroupCompaniesDescription varchar(50)
);


create table VehicleGroup(
	VehicleGroupID int identity (1,1) primary key not null,
	VehicleGroupDescription varchar(50)
);

create table ZoneRate(
	ZoneRateID int identity (1,1) primary key not null,
	ZoneRateDescription varchar(50)
);

create table Rate(
	RateID int identity (1,1) primary key not null,
	VehicleGroupID int REFERENCES VehicleGroup(VehicleGroupID),
	ZoneRateID int REFERENCES ZoneRate(ZoneRateID)

);

create table Vehicle(
	VehicleID int identity (1,1) primary key not null,
	VehicleLicenseNumber varchar(50),
	VehicleBrandTypeID int REFERENCES VehicleBrandType(VehicleBrandTypeID),
	VehicleColorID int REFERENCES VehicleColor(VehicleColorID),
	VehicleGroupID int REFERENCES VehicleGroup(VehicleGroupID),
	VehicleTypeID int REFERENCES VehicleType(VehicleTypeID),
	OutsourceVehicleGroupCompaniesID INT REFERENCES OutsourceVehicleGroupCompanies(OutsourceVehicleGroupCompaniesID)
);

create table ServiceProvider(
	ServiceProviderID int identity (1,1) primary key not null,
	ServiceProviderName varchar(50),
	Telephone varchar(50),
	EmailAddress varchar(50),
	PhysicalAddress varchar(100)
);

create table VehicleMaintenance(
	VehicleMaintenanceID int identity (1,1) primary key not null,
	KmToMaintenance varchar(50),
	MaintenanceStatus bit,
	MaintenanceDate DateTime,
	VehicleID int REFERENCES Vehicle(VehicleID),
	ServiceProviderID int REFERENCES ServiceProvider(ServiceProviderID)

);

create table Client(
	ClientID int identity (1,1) primary key not null,
	ClientReference varchar(50),
	ClientName varchar(50),
	Telephone varchar(50),
	EmailAddress varchar(50),
	PhysicalAddress varchar(100)
);

use SiyayaTravelAssist
go

create table Location(
	LocationID int identity (1,1) primary key not null,
	LocationDescriptionAddress varchar(50)
);



create table Passenger(
	PassengerID int identity (1,1) primary key not null,
	PassengerDescription varchar(50)
);


create table Quote(
	QuoteID int identity (1,1) primary key not null,
	DateCreated Datetime,
	Price real,
	QuoteStatus bit,
	PickupTime DateTime,
	DropOffTime DateTime,
	TripDate DateTime,
	PassengerID int REFERENCES Passenger(PassengerID),
	PickupLocation int REFERENCES Location(LocationID),
	DropOffLocation int REFERENCES Location(LocationID),
	Distance varchar(50),
	ClientID int REFERENCES Client(ClientID)
);

create table Report(
	ReportID int identity (1,1) primary key not null,
	QuoteID int REFERENCES Quote(QuoteID)
);

create table Trip(
	TripID int identity (1,1) primary key not null,	
	QuoteID int references Quote(QuoteID)
); 
create table BookingType(
	BookingTypeID int identity (1,1) primary key not null,
	BookingTypeDescription varchar(50)
);

create table Booking(
	BookingID int identity (1,1) primary key not null,
	DateCreated Datetime,
	BookingStatus varchar(50),
	BookingReference varchar(50),
	BookingOrder varchar(50),
	numberOfPassengers int,
	PaymentStatus varchar(50),
	AdditionalInformation varchar(100),
	QuoteID int REFERENCES Quote(QuoteID),
	BookingTypeID int REFERENCES BookingType(BookingTypeID)
);





