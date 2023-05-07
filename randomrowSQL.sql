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