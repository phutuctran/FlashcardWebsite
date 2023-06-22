create database YVFlashCard
drop database YVFlashCard
alter database YVFlashCard set offline
use YVFlashCard
go

create table [Setting] (
	[Name] varchar(32) primary key clustered,
	[Value] nvarchar(128) not null,
)

create table Accounts(
	UserName varchar(36) primary key,
	PassWord varchar(20),
	DateCreate Datetime default GETDATE()
)
--alter table [Accounts] drop column DateCreate
--alter table [Accounts] add [DateCreate] datetime default GETDATE()
-- add field [role] to [Accounts]
alter table [Accounts] --A is activate, B is block, W is wait approval
	add [State] varchar(1) default 'A'
alter table [Accounts] -- REGULAR / ADMIN
	add [Role] varchar(1) default 'R'
-- end add field
create table Themes(
	ThemeID int identity(1,1) primary key,
	ThemeName nvarchar(max),
	Mean nvarchar(max),
	IllustrationImg varbinary(max),
	Author varchar(36)
	constraint FK_Theme_Acc foreign key(Author) references Accounts(UserName))


alter table [Themes] -- REGULAR / ADMIN
	add [Role] varchar(1) default 'R'
alter table [Themes]
	add [TotalLevel] int default 1

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
alter table [Dictionary]
	add [Role] varchar(1) default 'R'

alter table [Dictionary]
	ALTER COLUMN [IPA] varchar(max) COLLATE Latin1_General_100_CI_AI_SC_UTF8;
alter table [Dictionary]
	add [Example] varchar(max)
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
	
ALTER TABLE UserInfos
DROP COLUMN AvatarData

alter table UserInfos
	add AvatarData varbinary(max)

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
--drop trigger addTotalWord
CREATE TRIGGER addTotalWord ON [Dictionary]
FOR INSERT
AS
begin
	update Setting
	set Setting.Value = CAST(Cast(value as int) + 1 as nvarchar)
	where Setting.Name = 'TW'
end
--end
--select 
--end
--add total account to setting
--drop trigger addTotalAccounts
CREATE TRIGGER addTotalAccounts ON [Accounts]
FOR INSERT
AS
begin 
	update Setting
	set Setting.Value =  CAST(Cast(value as int) + 1 as nvarchar)
	where Setting.Name = 'TA'
end
--end


create procedure DeleteUser
	@username varchar(36)
as
	begin
		exec DeleteAllStudyByUser @username
		exec DeleteAllWordsOfUser @username
		exec DeleteAllThemesByUser @username
		Delete from [UserInfos] where UserName = @username
		Delete from [Accounts] where UserName  = @username
	end
go
		
create procedure DeleteAllStudyByUser
	@username varchar(36)
as
	begin 
		Delete [ForgetWords] from [ForgetWords] inner join [Studies] on ([ForgetWords].StudyID = [Studies].StudyID and [Studies].UserName = @username)
		Delete from [Studies] where [Studies].UserName = @username
	end
go
 


create procedure DeleteAllWordsOfUser
	@username varchar(36)
as 
	begin
		Delete Synonyms from [Synonyms] inner join [Dictionary] on ([Synonyms].WordID1 = [Dictionary].WordID or [Synonyms].WordID2 = [Dictionary].WordID) and [Dictionary].Author = @username
		Delete from [Dictionary] where Author = @username
	end
go

drop procedure DeleteAllThemesByUser

exec DeleteUser admin2

create procedure DeleteAllThemesByUser
	@username varchar(36)
as 
	begin 
		declare @themeid int
		declare @count int
		set @count = 1;
		while @count <= (select count(*) from [Themes] where Author = @username)
		begin
			select @themeid = ThemeID
			from [Themes]
			where Author = @username
			
			exec DeleteTheme @themeid
	end
end
go
 


create procedure CreateNewTheme
	@themeName nvarchar(max),
	@mean nvarchar(max),
	@img varbinary(max),
	@author varchar(36),
	@role varchar(1)
as
	begin
	INSERT INTO Themes(Themename, Mean, IllustrationImg, Author, Role, DateCreate, Lastupdate) VALUES (@themeName, @mean, @img, @author, @role, GETDATE(), GETDATE())
	end
go



CREATE TRIGGER addLastUpdateWhenUpadateTheme ON [Themes]
After insert, update
AS
begin 
	update Themes
	set Lastupdate = getdate()
	from Themes
	inner join inserted on Themes.ThemeID = inserted.ThemeID
end
--end

create procedure DeleteTheme
	@themeid int
as
	begin
	exec DeleteThemeIdInAllWords @themeid
	delete from [Themes] where ThemeID = @themeid
	end
go

drop procedure DeleteThemeIdInAllWords

CREATE procedure DeleteThemeIdInAllWords
	@themeid int
as
	begin 
		print @themeid
		update [Dictionary]
		set Dictionary.ThemeID = NULL
		from [Dictionary]
		where Dictionary.ThemeID = @themeid;
	end
go


create procedure CreateNewAccount 
	@userName varchar(36), 
	@passWord varchar(20), 
	@role varchar(1) 
as
	begin
	INSERT INTO Accounts (UserName, PassWord, Role, DateCreate) VALUES (@userName, @passWord, @role, GETDATE())
	end
go

drop table ForgetWords
drop table Studies
drop table UserInfos
drop table Synonyms
drop table Dictionary
drop table SpeechParts
drop table Themes
drop table Accounts
drop table Setting