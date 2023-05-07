/*====================Create new user when valid data===========*/
async function CreatNewUserAsync(event) {
	event.preventDefault(); // Ngăn chặn form submit mặc định
	let check = await validateModalWhenCreateAsync(event);
	if (check) {
		const form = event.target;
		const formData = new FormData(form);
		//event.target.submit();
		const response = await fetch(form.action, {
			method: form.method,
			body: formData
		});
		if (response.ok) {
			alert("Đã tạo User mới!");
			location.reload();
			return true;
		}
		else {
			alert("Lỗi khi tạo User!");
		}
		return false;
	}
}


/*=================Check validInfo when Create new user=================*/
async function validateModalWhenCreateAsync(event) {
	
    
	//alert(formData);
	let isExists = await checkExistsUsername();
	if (isExists)
		return false;

	if (!validatePassword(true))
		return false;

	var inputPhoneNumber = String(document.getElementById("phoneNumberNew").value);
	if (ValidatePhoneNumber(inputPhoneNumber) === false && inputPhoneNumber) {
		alert("Wrong phone number!!!");
		return false;
	}
	
	var inputEmail = String(document.getElementById("emailNew").value);
	if (ValidateEmail(inputEmail) === false && inputEmail) {
		alert("Wrong Email!!!");
		return false;
	}

	var inputAge = String(document.getElementById("ageNew").value);
	if (ValidateAge(inputAge) === false && inputAge) {
		alert("Wrong Age!!!");
		return false;
	}
	
	var inputSex = String(document.getElementById("sexSelectNew").value);
	if (ValidateSex(inputSex) === false && inputSex) {
		alert("Wrong Sex!!!")
		return false;
	}
	
	return true;

}




/*=================Check validInfo======================*/
function validateModal() {
	var inputPhoneNumber = String(document.getElementById("phoneNumber").value);
	if (ValidatePhoneNumber(inputPhoneNumber) === false && inputPhoneNumber) {
		alert("Wrong phone number!!!");
		return false;
	}
	var inputEmail = String(document.getElementById("email").value);
	if (ValidateEmail(inputEmail) === false && inputEmail) {
		alert("Wrong Email!!!");
		return false;
	}
	var inputAge = String(document.getElementById("age").value);
	if (ValidateAge(inputAge) === false && inputAge) {
		alert("Wrong Age!!!");
		return false;
	}
	var inputSex = String(document.getElementById("sexSelect").value);
	if (ValidateSex(inputSex) === false && inputSex) {
		alert("Wrong Sex!!!")
		return false;
	}
	return validatePassword(false);

}


/*===========Check Sex=================*/
function ValidateSex(Sex) {
	return (Sex === "Male" || Sex === "Female");

}

/*=========Check Age=========*/
function ValidateAge(Age) {
	if (/^\d+$/.test(Age)) {
		let parsedAge = Number.parseInt(Age);
		return (parsedAge >= 5 && parsedAge <= 90);
	}
	return false;

}

/*============Check Phone Number======*/
function ValidatePhoneNumber(phone) {
	return /^\d{10}$/.test(phone);
	//return phone.match(/\d/g).length === 10 && /^\d+$/.test(phone);
}

/*========Check Email ==============*/
function ValidateEmail(mail) {
	if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(mail)) {
		return (true)
	}
	return (false)
}

/*================Check Password===================*/


function validatePassword(require) {
	var password = "";
	var confirmPassword = "";
	if (require) {
		password = document.getElementById("passwordNew").value;
		confirmPassword = document.getElementById("repasswordNew").value;
	}
	else {
		password = document.getElementById("password").value;
		confirmPassword = document.getElementById("repassword").value;
	}
	
	if (require == true) {
		if (password == "" || confirmPassword == "") {
			alert("Wrong password!!");
			return false;
		}
	}

	if (password != "" || confirmPassword != "") {
		if (password != confirmPassword) {
			alert("Wrong Comfirm Password!")
			return false;
		}
	}

	return true;
	
}


/*================Check exists username=============*/

async function checkExistsUsername() {
	var username = document.getElementById("userNameNew").value;
	// Kiểm tra giá trị nhập vào
	if (!username) {
		alert('Username không được để trống');
		return true;
	}
	await $.ajax({
		url: 'NewUser/Check-Username',
		type: 'POST',
		data: { username: username },
		success: function (result) {
			if (result == true) {
				alert("Username đã tồn tại!");
				return true;
			} else {
				return false;
			}
		},
		error: function (xhr, status, error) {
			console.log("Request failed:", error);
			return true;
		}
	});
	return false;

}