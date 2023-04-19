'use strict';

/* ===== Enable Bootstrap Popover (on element  ====== */

var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-toggle="popover"]'))
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
  return new bootstrap.Popover(popoverTriggerEl)
})

/* ==== Enable Bootstrap Alert ====== */
var alertList = document.querySelectorAll('.alert')
alertList.forEach(function (alert) {
  new bootstrap.Alert(alert)
});


/* ===== Responsive Sidepanel ====== */
const sidePanelToggler = document.getElementById('sidepanel-toggler'); 
const sidePanel = document.getElementById('app-sidepanel');  
const sidePanelDrop = document.getElementById('sidepanel-drop'); 
const sidePanelClose = document.getElementById('sidepanel-close'); 

window.addEventListener('load', function(){
	responsiveSidePanel(); 
});

window.addEventListener('resize', function(){
	responsiveSidePanel(); 
});

function responsiveSidePanel() {
    let w = window.innerWidth;
	if(w >= 1200) {
	    // if larger 
	    //console.log('larger');
		sidePanel.classList.remove('sidepanel-hidden');
		sidePanel.classList.add('sidepanel-visible');
		
	} else {
	    // if smaller
	    //console.log('smaller');
	    sidePanel.classList.remove('sidepanel-visible');
		sidePanel.classList.add('sidepanel-hidden');
	}
};

sidePanelToggler.addEventListener('click', () => {
	if (sidePanel.classList.contains('sidepanel-visible')) {
		console.log('visible');
		sidePanel.classList.remove('sidepanel-visible');
		sidePanel.classList.add('sidepanel-hidden');
		
	} else {
		console.log('hidden');
		sidePanel.classList.remove('sidepanel-hidden');
		sidePanel.classList.add('sidepanel-visible');
	}
});



sidePanelClose.addEventListener('click', (e) => {
	e.preventDefault();
	sidePanelToggler.click();
});

sidePanelDrop.addEventListener('click', (e) => {
	sidePanelToggler.click();
});



/* ====== Mobile search ======= */
const searchMobileTrigger = document.querySelector('.search-mobile-trigger');
const searchBox = document.querySelector('.app-search-box');

searchMobileTrigger.addEventListener('click', () => {

	searchBox.classList.toggle('is-visible');
	
	let searchMobileTriggerIcon = document.querySelector('.search-mobile-trigger-icon');
	
	if(searchMobileTriggerIcon.classList.contains('fa-search')) {
		searchMobileTriggerIcon.classList.remove('fa-search');
		searchMobileTriggerIcon.classList.add('fa-times');
	} else {
		searchMobileTriggerIcon.classList.remove('fa-times');
		searchMobileTriggerIcon.classList.add('fa-search');
	}
	
		
	
});


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
	return validatePassword();
	
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


function validatePassword() {
	var password = document.getElementById("password").value;
	var confirmPassword = document.getElementById("repassword").value;
	if (password != null || confirmPassword != null) {
		if (password != confirmPassword) {
			var _alert = document.getElementById("passwordalert");
			if (_alert != null) {
				_alert.remove();
			}
			var parentDiv = document.getElementById("divRepassword");
			var inputElement = document.getElementById("repassword");
			var newDiv = document.createElement("div");
			newDiv.innerHTML = '<div class="alert alert-danger" role="alert" id="passwordalert">Invalid Password!!!</div>';
			parentDiv.insertBefore(newDiv, inputElement);
			return false;
		}
    }
	
	return true;
}
