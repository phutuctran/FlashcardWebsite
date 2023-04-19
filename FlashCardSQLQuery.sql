create database YVFlashCard
drop database YVFlashCard
alter database YVFlashCard set offline
use YVFlashCard
go



-- add field [role] to [Accounts]


--add user info when insert new account
CREATE TRIGGER addUserInfo ON [Accounts]
FOR INSERT
AS

INSERT INTO UserInfos
        (UserName)
    SELECT UserName FROM inserted
go
--end

--add total number of word to setting
drop trigger addTotalWord
CREATE TRIGGER addTotalWord ON [Dictionary]
FOR INSERT
AS
begin
	update Setting
	set Setting.Value = CAST(Cast(value as int) + 1 as nvarchar)
	where Setting.Name = 'TW'
end
--end
select 
--end
--add total account to setting
drop trigger addTotalAccounts
CREATE TRIGGER addTotalAccounts ON [Accounts]
FOR INSERT
AS
begin 
	update Setting
	set Setting.Value =  CAST(Cast(value as int) + 1 as nvarchar)
	where Setting.Name = 'TA'
end
--end

create table [Setting] (
	[Name] varchar(32) primary key clustered,
	[Value] nvarchar(128) not null,
)

create table Accounts(
	UserName varchar(36) primary key,
	PassWord varchar(20),
	DateCreate Datetime
)
--alter table [Accounts]
--	drop column CreateDate
alter table [Accounts]
	add [DateCreate] datetime default GETDATE()

alter table [Accounts] -- REGULAR / ADMIN
	add [Role] varchar(1) default 'R'
-- end add field
create table Themes(
	ThemeID int identity(1,1) primary key,
	ThemeName varchar(max),
	Mean varchar(max),
	IllustrationImg varbinary(max),
	Author varchar(36)
	constraint FK_Theme_Acc foreign key(Author) references Accounts(UserName))

create table SpeechParts(
	SpeechPartName varchar(20) primary key,
	Mean varchar(max))


/*alter table Dictionary 
drop constraint FK_Dic_Themes
alter table Dictionary 
drop constraint FK_Dic_SpeechParts
alter table Dictionary 
drop constraint FK_Dic_Acc
drop table Dictionary*/
create table Dictionary(
	WordID int IDENTITY(1,1) primary key,
	WordText varchar(max),
	Mean varchar(max),
	SpeechPart varchar(20),
	ThemeID int,
	Level int,
	IllustrationImg varbinary(max),
	Author varchar(36),
	constraint FK_Dic_Themes foreign key(ThemeID) references Themes(ThemeID),
	constraint FK_Dic_SpeechParts foreign key(SpeechPart) references SpeechParts(SpeechPartName),
	constraint FK_Dic_Acc foreign key(Author) references Accounts(UserName))

--add DateCreate field
alter table [Dictionary]
	add [DateCreate] smalldatetime default GETDATE()
--end add

create table Synonyms(
	SynonymID int identity(1,1) primary key,
	WordID1 int, 
	WordID2 int,
	constraint FK_Syn_Dic_Word1 foreign key(WordID1) references Dictionary(WordID),
	constraint FK_Syn_Dic_Word2 foreign key(WordID2) references Dictionary(WordID))

create table UserInfos(
	UserName varchar(36) primary key,
	FirstName nvarchar(max),
	LastName nvarchar(max),
	PhoneNumber varchar(10),
	Address nvarchar(max),
	Email varchar(max),
	Age int,
	Sex varchar(6),
	AvatarData varbinary(max)
	constraint FK_User_Acc foreign key(UserName) references Accounts(UserName))

create table Studies(
	StudyID int identity(1,1) primary key,
	UserName varchar(36),
	ThemeID char(36),
	CurrentLevel int
	constraint FK_Study_User foreign key(UserName) references Accounts(UserName))

Create table ForgetWords(
	ForgetWordID int identity(1,1) primary key,
	StudyID int, 
	WordID int,
	ForgetCount int
	constraint FK_Forget_Study foreign key(StudyID) references Studies(StudyID),
	constraint FK_Forget_Word  foreign key(WordID) references Dictionary(WordID))

drop table ForgetWords
drop table Studies
drop table UserInfos
drop table Synonyms
drop table Dictionary
drop table SpeechParts
drop table Themes
drop table Accounts
drop table Setting