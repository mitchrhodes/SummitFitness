USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	email varchar(50)NOT NULL, 
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_users PRIMARY KEY (user_id)
)

CREATE TABLE events (
	event_id int IDENTITY(1,1) NOT NULL,
	name varchar(255) NOT NULL,
	description varchar(255) NOT NULL,
	type varchar(50) NOT NULL,
	period_in_days int NOT NULL,
	)

CREATE TABLE goals(
	goal_id int IDENTITY(1,1) NOT NULL,
	user_id int NOT NULL,
	goal_name varchar(50) NOT NULL,
	goal_description varchar (255) NOT NULL,
	goal_type varchar(50) NOT NULL,
	period_in_days int NOT NULL,
	distance int,
	time int,
	distance_progress int DEFAULT 0,
	time_progress int
	)

CREATE TABLE user_events(
	event_id int NOT NULL,
	user_id int NOT NULL, 
	time_progress int,
	distance_progress int DEFAULT 0,
	date_time datetime,
	CONSTRAINT pk_user_events_event_id_user_id PRIMARY KEY (event_id, user_id)
)

CREATE TABLE user_log(
	user_log_entry_id int IDENTITY(1,1),
	date_time datetime,
	user_id int,
	event_id int,
	goal_id int,
	time_progress int,
	distance_progress int DEFAULT 0,
	CONSTRAINT PK_user_log PRIMARY KEY (user_log_entry_id)
)

--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'theofficialbobojones@gmail.com');
--admin/password
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('Billy Hamilton','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','user', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('Mike Johansen','gYax/nldlps+n/IL3paG1tnX0Jk= ', 'rDaoxV0X3rg=','user', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('John Smith','aFfNx8CzaVHSfFjSfM4Zx/ehF0c= ', 'lFYlQhiR3/Q=','user', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('Sarah Walker','tF8wj5J9u9pEt7qg9sMi46i5Vwg= ', 'bB2hzm+kWxw=','user', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('Mia Porter','O0WnyUuipLQayYpF5G4ncL/oR4Q=', 'F4y+FwW1P+Q=','user', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('Luke Doncic','I8YxsZAwEcz4Oiy/4v6H5nUZ6C8=', 'VG1l+Xiboi8=','user', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('Kurt Warner','kv6yYuRQmHKJ5aFq5B6qNwZG8+g=', 'FUEq3Hb//qw=','user', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('Teresa Cole','3uzzKuAjxA0A/a4a15RtOLxGvyM=', 'kaTEMu7zNjw=','admin', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('Tom Delong','sZUFmSEGWD7TRygtc68rreWiP9o', 'Ys9CrV56YSg=','user', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('Andrew Thompson','pipfCNqnyaPHTPKxoVQ1+Yn7qks=', 'oeY7C+qU448=','user', 'theofficialbobojones@gmail.com');
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('Audra Herring','qIkLG7VXclqW1COmZdaFR7WVpuY=', 'UaIVI1N6CfQ=','user', 'theofficialbobojones@gmail.com');


--Events
INSERT INTO events (name, description, type, period_in_days) VALUES ('Pellytonya', 'Ride with the peloton, reach your dreams', 'Cycling', 7);

INSERT INTO events (name, description, type, period_in_days) VALUES ('Mega-Marathon', 'Walk 500 Miles in the month of August', 'Walking', 15);

INSERT INTO events (name, description, type, period_in_days) VALUES ('400m Medley', 'All four swimming strokes in your lane', 'Swimming', 4);

INSERT INTO events (name, description, type, period_in_days) VALUES ('Charity Walk for Arthritis', 'Local Hospital fundraiser. Exercise and Charity? Check!', 'Walking', 1);

INSERT INTO events (name, description, type, period_in_days) VALUES ('High School Fun Run', 'Revisit your old stomping grounds and run with friends', 'Running', 1);

INSERT INTO events (name, description, type, period_in_days) VALUES ('Swim Lake Erie', 'Cleveland Browns are hosting a swim for heart health', 'Swimming', 2);

INSERT INTO events (name, description, type, period_in_days) VALUES ('Cycle Across the USA', 'Can you cycle from California to Maine?', 'Cycling', 15);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Marathon', 'Run a marathon', 'Running', 1, 1, 26);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('10K', 'Run 6.2 Miles', 'Running', 1, 1, 6);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Half Marathon', 'Run a half marathon', 'Running ', 1, 1, 13);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('100K', 'Run 60.2 Miles', 'Running', 5, 1, 60);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('CycloMadness', 'Long Distance Cylco-Cross Through Columbus', 'Cycling', 5, 2, 200);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Disco INFERNO', 'Funky Dance Competition', 'Aerobics', 5, 2, 50);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Pirate Themed Fun Run', 'Race for the buried treasure!', 'Running', 5, 3, 20);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Roller Derby', 'Get the Pads on and Blades rolling', 'Inline Skating', 5, 3, 30);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Softball Tournement', 'Hit the Diamond and bring some sunflower seeds', 'Softball', 5, 4, 10);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Billy Idol Sing Along', 'Sing some 80s music!', 'Aerobics', 5, 4, 15);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Curling', 'SWEEP SWEEP!', 'Skating', 5, 5, 20);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Richard Simmons Dance Off', 'Im a maniac!', 'Aerobics', 5, 5, 25);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Ballet Met', 'Dance on your tippy toes', 'Aerobics', 5, 6, 10);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Race against Michael Johnson', '100 Meter Dash', 'Fun Run', 5, 6, 10);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Usain Bolt Run off', 'Try to run away from Usain Bolt', 'Fun Run', 5, 7, 70);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Football Game', 'Classic Gridiron clash', 'Fun Run', 5, 7, 25);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Unicycle Across Texas', 'Grow your mustache and eat steak while on your uni', 'Cycling', 5, 8, 35);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Swim LA', 'Back to School Swimming meet in Downtown LA!', 'Swimming', 5, 8, 40);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('WindSurf', 'Rental Eqipment Available!', 'Extreme Sport', 5, 9, 60);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Hike Angels Landing', 'Zion National Parks greatest hike', 'Hiking', 5, 9, 75);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Hike Old Mans Cave', 'Break out your hiking boots', 'Hiking', 5, 10, 100);
INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id, distance) VALUES ('Learn to Ride a Horse', 'Instructors will be ready with equipment!', 'Equestrian', 5, 10, 45);



INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (1,1, 5)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (3,1, 5)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (2,1, 4)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (4,1, 3)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (5,3, 6)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (2,3, 7)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (3,3, 3)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (4,9, 4)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (1,8, 7)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (2,9, 5)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (2,8, 19)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (5,11, 0)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (4,11, 3)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (2,11, 2)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (5,12, 8)
INSERT INTO user_events(event_id,user_id, distance_progress) VALUES (4,12, 9)





ALTER TABLE goals ADD FOREIGN KEY(user_id)
REFERENCES users(user_id)

ALTER TABLE user_events ADD FOREIGN KEY(user_id)
REFERENCES users(user_id)

ALTER TABLE user_events ADD FOREIGN KEY(event_id)
REFERENCES events(event_id)

ALTER TABLE user_log ADD FOREIGN KEY (user_id)
REFERENCES users(user_id)

GO