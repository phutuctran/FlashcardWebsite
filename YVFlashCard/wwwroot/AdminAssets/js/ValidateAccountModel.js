
/*=================Check validInfo when Create new user=================*/
function validateModalWhenCreate() {
	//alert("here");
	if (!checkExistsUsername())
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
		if (password == null || confirmPassword == null) {
			alert("Require password!!");
			return false;
		}
		if (password != null || confirmPassword != null) {
			if (password != confirmPassword) {

				if (_alert != null) {
					_alert.remove();
				}
				if (require) {

					var parentDiv = document.getElementById("divRepasswordNew");
					var inputElement = document.getElementById("repasswordNew");
					var newDiv = document.createElement("div");
					newDiv.innerHTML = '<div class="alert alert-danger" role="alert" id="passwordalert">Invalid Password!!!</div>';
					parentDiv.insertBefore(newDiv, inputElement);
				}
				else {
					var parentDiv = document.getElementById("divRepassword");
					var inputElement = document.getElementById("repassword");
					var newDiv = document.createElement("div");
					newDiv.innerHTML = '<div class="alert alert-danger" role="alert" id="passwordalert">Invalid Password!!!</div>';
					parentDiv.insertBefore(newDiv, inputElement);
                }
				
				return false;
			}
		}

		return true;
	}
}


/*================Check exists username=============*/

function checkExistsUsername() {
	var username = document.getElementById("userNameNew").value;
	// Kiểm tra giá trị nhập vào
	if (!username) {
		alert('Username không được để trống');
		return false;
	}

	// Gửi yêu cầu AJAX để kiểm tra giá trị bị trùng
	$.ajax({
		url: 'admin/UserInfos/CheckUsernameExist',
		method: 'POST',
		data: { userName: username },
		success: function (response) {
			if (response === 'true') {
				alert('Username đã tồn tại');
				return false;
			} else {
				alert("okiii");
				return true;
			}
		},
		error: function () {
			alert('Error!!');
		}
	});
}