-- *****************************************************************************
-- This script contains INSERT statements for populating tables with seed data
-- *****************************************************************************


BEGIN TRANSACTION;

CREATE TABLE users
(
	user_id int identity not null,
	user_name varchar(1000) not null,
	user_emailaddress varchar(1000) not null,
	user_password varchar(1000) not null,
	admin bit not null,
	
	constraint pk_user_id primary key (user_id),
);

CREATE TABLE itinerary
(
	itinerary_id int identity not null,
	name varchar (1000) not null,
	user_id int not null,
	starting_point varchar (1000), 
	
	constraint fk_user_id foreign key (user_id) references users(user_id),
	constraint pk_itinerary_id primary key (itinerary_id),
);

CREATE TABLE landmark
(
	landmark_id int identity not null,
	name varchar (1000) not null,
	address varchar (1000) not null,
	description varchar (1000) not null,
	approved bit not null, 
	image varchar (1000),
	
	
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
	landmark_id int NOT NULL,
	rating bit not null,
	description varchar (1000),

	constraint pk_review_id primary key (review_id),
	constraint fk_reviews_landmark_id foreign key (landmark_id) REFERENCES landmark(landmark_id)
);

CREATE TABLE reviews_by_landmark
(
	landmark_id int not null,
	review_id int not null,

	constraint PK_LR primary key (landmark_id, review_id),
	constraint fk_review_id foreign key (review_id) references reviews(review_id),
	constraint fk_landmark_id2 foreign key (landmark_id) references landmark(landmark_id),
);

INSERT INTO users VALUES ('User', 'emailaddress@gmail.com', 'P@ssword1', 1)
INSERT INTO landmark VALUES ('Easton Town Center', '160 Easton Town Center, Columbus, OH 43219', 'Easton Town Center is an indoor and outdoor shopping complex. Included in the design are fountains, streets laid out in a grid pattern surrounded by a continuous loop, and metered storefront parking', 1, 'Easton.jpg')
INSERT INTO landmark VALUES ('Columbus Museum of Art', '480 E Broad St, Columbus, OH 43215', 'The museum collection includes outstanding late nineteenth and early twentieth-century American and European modern works of art. It houses the world�s largest collections of works by beloved local artists Aminah Brenda Lynn Robinson, Elijah Pierce, and George Bellows. There is also a focus on contemporary art, folk art, glass, and photography.', 1, 'COMA.jpg')
INSERT INTO landmark VALUES ('Columbus Zoo and Aquarium', '4850 W Powell Rd, Powell, OH 43065', 'One of the top zoos in the country, in part made famous by the efforts of director Jack Hanna. The Columbus Zoo is home to more than 7,000 animals representing over 800 species and sees over 2.3 million visitors annually. The animal exhibits are divided into regions of the world.', 1, 'Zoo.jpg')
INSERT INTO landmark VALUES ('Ohio Stadium', '411 Woody Hayes Dr Columbus, OH 43210', 'Ohio Stadium, also known as the Horseshoe, is a football stadium on the campus of The Ohio State University completed in 1922. Its primary purpose is the home venue of the Ohio State Buckeyes football team. The current capacity is 104,944.', 1, 'OhioStadium.jpg')
INSERT INTO landmark VALUES ('North Market', '59 Spruce St, Columbus, OH 43215', 'Established in 1876, the North Market is Columbus� only remaining true public market. More than 30 merchants vend a wide variety of fresh, local, authentic food. Offerings include organic produce, grass-fed beef, pork, lamb and goat, pastured poultry, sustainably raised seafood, locally roasted coffee, baked goods, cheeses, flowers and other artisan food items.', 1, 'NorthMarket.jpg')
INSERT INTO landmark VALUES ('German Village', 'German Village, Columbus, OH', 'German Village is a historic neighborhood in Columbus, Ohio, just south of downtown. It was settled in the early-to-mid-19th century by a large number of German immigrants. It was added to the National Register of Historic Places in 1974. The district is home to many bars and restaurants, including Katzingers Delicatessen and Schmidts Sausage Haus.', 1, 'GermanVillage.jpg')
INSERT INTO landmark VALUES ('COSI', '333 W Broad St, Columbus, OH 43215', 'COSI (Center of Science and Industry) Columbus is a dynamic hands-on science center located in Central Ohio that is fun for all ages.', 1, 'COSI.jpg')
INSERT INTO landmark VALUES ('Short North Arts District', 'Short North, Columbus, OH', 'The Short North is heavily populated with art galleries, specialty shops, pubs, nightclubs, and coffee houses. Most of its tightly packed brick buildings date from at least the early 20th century, with traditional storefronts along High Street. The city installed 17 lighted metal archways extending across High Street throughout the Short North. The area is also known to be a very gay and lesbian friendly neighborhood which hosts the annual Columbus gay pride parade.', 1, 'ShortNorth.jpg')
INSERT INTO landmark VALUES ('Franklin Park Conversatory', '1777 E Broad St, Columbus, OH 43203', 'Franklin Park Conservatory and Botanical Gardens is a premier horticulture institution showcasing artfully designed gardens, exotic plant collections and lush floral displays.', 1, 'FranklinParkConservatory.jpg')
INSERT INTO landmark VALUES ('Ohio Statehouse', '1 Capitol Square, Columbus, OH 43215', 'The house of government for the state of Ohio. Completed in 1861, this impressive building is in the Greek revival style. Tours are available throughout the day.', 1, 'OhioStatehouse.jpg')
INSERT INTO landmark VALUES ('Ohio Theatre', '39 East State St Columbus, OH 43215', 'From classical music to modern dance, yearly family traditions to hot concerts, the worlds best artists come to the 2,791-seat Ohio Theatre. The historic 1928 movie palace was saved from demolition in 1969 and completely restored.', 1, 'OhioTheatre.jpg')
INSERT INTO landmark VALUES ('Nationwide Arena', '200 W Nationwide Blvd, Columbus, OH 43215', 'Nationwide Arena is the home of the NHL Columbus Blue Jackets and a wide variety of world-class entertainment events. The arena seats 18,500 for hockey and up to 20,000 for concerts', 1, 'NationwideArena.jpg')
INSERT INTO landmark VALUES ('The Ohio State University', 'The Ohio State University, Columbus, OH 43210', 'The Ohio State University is a large, public university in Columbus, Ohio. Founded in 1871, it has since grown into the third-largest university campus in the United States.', 1, 'OSU.jpg')
INSERT INTO itinerary VALUES ('My CBUS adventure', 1, 'Ohio Theatre' )
INSERT INTO landmarks_by_itinerary VALUES (1,1)
INSERT INTO landmarks_by_itinerary VALUES (1,2)

COMMIT TRANSACTION;