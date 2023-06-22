
declare @i int
declare @username varchar(10)
declare @pass varchar(10);
    set @i = 9
	set @pass = '123'
    while (@i < 1000)


    Begin

    set @username = CONCAT('user', @i);
	print(@username)
	--print(@pass)
	update UserInfos set FirstName = N'Phú Túc', LastName = N'Trần Trương', PhoneNumber = '0941736331', Address = N'105/3 đường 138, Tân Phú, quận 9', Email = 'phutuc2002@gmail.com', Age = '21', Sex = 'Male'
	where UserName = @username;
    --insert into Accounts(UserName, PassWord) values(@username, @pass)
    SET @i = @i + 1
    end

declare @i int
declare @wordtext varchar(10)
declare @mean varchar(10);
    set @i = 1
    while (@i < 10)


    Begin

    set @wordtext = CONCAT('word', @i);
	set @mean = CONCAT('mean', @i);
	print(@wordtext)
	--print(@pass)
	Update Dictionary set Role = 'A'
	where WordText = @wordtext
    --insert into Dictionary(WordText, Mean, ThemeID, Level) values(@wordtext, @mean, 22, 1)
    SET @i = @i + 1
    end

--Add speech part
insert into SpeechParts(SpeechPartName, Mean) values('Noun', N'Danh từ')
insert into SpeechParts(SpeechPartName, Mean) values('Pronoun', N'Đại từ')
insert into SpeechParts(SpeechPartName, Mean) values('Adjective', N'Tính từ')
insert into SpeechParts(SpeechPartName, Mean) values('Verb', N'Động từ')
insert into SpeechParts(SpeechPartName, Mean) values('Adverb', N'Trạng từ')
insert into SpeechParts(SpeechPartName, Mean) values('Determiner', N'Từ hạn định')
insert into SpeechParts(SpeechPartName, Mean) values('Preposition', N'Giới từ')
insert into SpeechParts(SpeechPartName, Mean) values('Conjunction', N'Liên từ')
insert into SpeechParts(SpeechPartName, Mean) values('Interjection', N'Thán từ')

select * from Themes
--Add themes
insert into Themes(ThemeName, Mean, Author, Role) values('Animals', N'Động vật', 'admin', 'A')
insert into Themes(ThemeName, Mean, Author, Role) values('Fruits', N'Trái cây', 'admin', 'A')

--Add Vob----------------
SELECT DATABASEPROPERTYEX('YVFlashCard', 'Collation') AS DatabaseCollation;
select * from Dictionary
delete from Dictionary
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('Cat', N'Con mèo', N'/kæt/', 'Noun', '24', '1', 'Cat can not talk', 'admin', 'A')
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('Dog', N'Con chó', N'/dɒɡ/', 'Noun', '24', '1', 'Dog is friendly', 'admin', 'A')
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('Bird', N'Con chim', N'/bɜːd/', 'Noun', '24', '1', 'Bird can fly', 'admin', 'A')
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('Duck', N'Con vịt', N'/dʌk/', 'Noun', '24', '1', 'Duck love swimming in the water', 'admin', 'A')
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('Chicken', N'Con gà', N'/ˈtʃɪk.ɪn/', 'Noun', '24', '1', 'Chicken cant not fly', 'admin', 'A')
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('Fish', N'Con cá', N'/fɪʃ/', 'Noun', '24', '1', 'Fish can not walk', 'admin', 'A')
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('Pig', N'Con heo', N'/pɪɡ/', 'Noun', '24', '1', 'Pig is big', 'admin', 'A')
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('Dolphin', N'Con cá heo', N'/ˈdɑːl.fɪn/', 'Noun', '24', '1', 'Dolphin can swim fastly', 'admin', 'A')
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('Ant', N'Con kiến', N'/ænt/', 'Noun', '24', '1', 'Ant like eating sugar', 'admin', 'A')
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('Mouse', N'Con chuột', N'/maʊs/', 'Noun', '24', '1', 'Mouse likes dark', 'admin', 'A')
insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values('nan', N'nan', N'nan', 'nan', '1', '2', 'nan', 'admin', 'A')