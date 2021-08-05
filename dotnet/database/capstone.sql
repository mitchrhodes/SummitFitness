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
	CONSTRAINT PK_user PRIMARY KEY (user_id)
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
	distance_progress int,
	time_progress int
	)

CREATE TABLE user_events(
	event_id int NOT NULL,
	user_id int NOT NULL, 
	time_progress int,
	distance_progress int,
	CONSTRAINT pk_user_events_event_id_user_id PRIMARY KEY (event_id, user_id)
)

--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'theofficialbobojones@gmail.com');
--admin/password
INSERT INTO users (username, password_hash, salt, user_role, email) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 'theofficialbobojones@gmail.com');

INSERT INTO events (name, description, type, period_in_days) VALUES ('pellytonya', 'big ol bike ride', 'cycling', 7);

INSERT INTO goals (goal_name, goal_description, goal_type, period_in_days, user_id) VALUES ('Marathon', 'Run a marathon', 'speedwalking', 5, 1);

INSERT INTO user_events(event_id,user_id) VALUES (1,1)

ALTER TABLE goals ADD FOREIGN KEY(user_id)
REFERENCES users(user_id)

ALTER TABLE user_events ADD FOREIGN KEY(user_id)
REFERENCES users(user_id)

ALTER TABLE user_events ADD FOREIGN KEY(event_id)
REFERENCES events(event_id)

GO