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

CREATE TABLE itinerary
(
	itinerary_id int identity not null,
	name varchar (50) not null,
	user_id int not null,
	starting_point varchar (100), 
	
	constraint fk_user_id foreign key (user_id) references users(user_id),
	constraint pk_itinerary_id primary key (itinerary_id),
);

CREATE TABLE landmark
(
	landmark_id int identity not null, 
	name varchar (50) not null,
	address varchar (60) not null,
	description varchar (120) not null,
	approved bit not null,
	image varchar (50),
	
	constraint pk_landmark_id primary key (landmark_id),
);

CREATE TABLE landmarks_by_itinerary
(
	itinerary_id int not null,
	landmark_id int not null,
	
	constraint PK_IL primary key (itinerary_id, landmark_id),
	constraint fk_itinerary_id foreign key (itinerary_id) references itinerary(itinerary_id),
	constraint fk_landmark_id foreign key (landmark_id) references landmark(landmark_id),
);

CREATE TABLE reviews
(
	review_id int identity not null,
	rating int not null,
	description varchar (60),
	
	constraint ck_rating CHECK (rating IN ('1', '2', '3', '4', '5')),
	constraint pk_review_id primary key (review_id),
);

CREATE TABLE reviews_by_landmark
(
	landmark_id int not null,
	review_id int not null,

	constraint PK_LR primary key (landmark_id, review_id),
	constraint fk_review_id foreign key (review_id) references reviews(review_id),
	constraint fk_landmark_id2 foreign key (landmark_id) references landmark(landmark_id),
);



COMMIT;



