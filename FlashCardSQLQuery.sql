create database YVFlashCard
drop database YVFlashCard
alter database YVFlashCard set offline
use YVFlashCard
go

drop table VisitCounts

create table [Setting] (
	[Name] varchar(32) primary key clustered,
	[Value] nvarchar(128) not null,
)

/*
tbl_setting (
	[name],
	[value]
)

Setting setting = new Setting()
setting.name = A";
setting.value = (Integer.Parse(setting.value) + 1).ToString();
*/

create table Accounts(
	UserName varchar(36) primary key,
	PassWord varchar(20),
	CreateDate Datetime
)
go

-- add field [role] to [Accounts]
alter table [Accounts] -- REGULAR / ADMIN
	add [Role] varchar(1) default 'R'
-- end add field

create table Themes(
	ThemeID char(36) primary key,
	ThemeName varchar(max),
	Mean varchar(max),
	IllustrationImg varbinary(max),
	Author varchar(36)
	constraint FK_Theme_Acc foreign key(Author) references Accounts(UserName))

create table SpeechParts(
	SpeechPartName varchar(20) primary key,
	Mean varchar(max))
	.Role
create table Dictionary(
	WordID char(36) primary key,
	WordText varchar(max),
	Mean varchar(max),
	SpeechPart varchar(20),
	Theme varchar(36),
	Level int,
	IllustrationImg varbinary(max),
	Author varchar(36),
	constraint FK_Dic_Themes foreign key(WordID) references Themes(ThemeID),
	constraint FK_Dic_SpeechParts foreign key(SpeechPart) references SpeechParts(SpeechPartName),
	constraint FK_Dic_Acc foreign key(Author) references Accounts(UserName))

create table Synonyms(
	SynonymID char(36) primary key,
	WordID1 char(36),
	WordID2 char(36)
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
	StudyID char(36) primary key,
	UserName varchar(36),
	ThemeID char(36),
	CurrentLevel int
	constraint FK_Study_User foreign key(UserName) references Accounts(UserName))

Create table ForgetWords(
	ForgetWordID char(36) primary key,
	StudyID char(36), 
	WordID char(36),
	ForgetCount int
	constraint FK_Forget_Study foreign key(StudyID) references Studies(StudyID),
	constraint FK_Forget_Word  foreign key(WordID) references Dictionary(WordID))

