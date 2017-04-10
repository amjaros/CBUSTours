-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************


BEGIN TRANSACTION

CREATE TABLE users
(
	user_id int identity not null,
	user_name varchar(50) not null,
	user_emailaddress varchar(50) not null,
	user_password varchar(50) not null,
	admin bit not null,
	constraint pk_user_id primary key (user_id),

);

COMMIT;