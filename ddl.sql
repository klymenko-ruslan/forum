create database forum;
use forum;

create table roles(id int IDENTITY(1,1) PRIMARY KEY, name varchar(255));

create table users(id int IDENTITY(1,1) PRIMARY KEY, username varchar(255), password varchar(255), roleid int,CONSTRAINT user_role_fk FOREIGN KEY (roleid) REFERENCES roles (id));

create table topics(id int IDENTITY(1,1) PRIMARY KEY, name varchar(255), authorid int ,CONSTRAINT user_fk FOREIGN KEY (authorid) REFERENCES users (id));

create table posts(id int IDENTITY(1,1) PRIMARY KEY, message varchar(255), timestamp bigint, topicid int, authorid int, 
CONSTRAINT topc_id_fk FOREIGN KEY (topicid) REFERENCES topics (id), 
CONSTRAINT user_author_fk FOREIGN KEY (authorid) REFERENCES users (id));

insert into roles(name) values('admin');
insert into roles(name) values('user');

