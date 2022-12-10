const plusBtnList = document.querySelectorAll(".plus-btn");
const minusBtnList = document.querySelectorAll(".minus-btn");
const numList = document.querySelectorAll(".num");
const rateList = document.querySelectorAll(".rate");
const amountList = document.querySelectorAll(".amount");
const sumCartEle = document.querySelector(".sum-cart");
const wannaBuyAllBtn = document.getElementById("wanna-buy-all");

wannaBuyAllBtn.onclick = function () {
	checkboxes = document.getElementsByName("wannaBuy");
	for (var i = 0, n = checkboxes.length; i < n; i++) {
		checkboxes[i].checked = wannaBuyAllBtn.checked;
	}
};

const sumCart = () => {
	let sum = 0;
	for (let i = 0; i < amountList.length; i++) {
		sum = sum + parseInt(amountList[i].textContent);
	}
	sumCartEle.innerHTML = String(sum);
};
sumCart();
const handleClick = (rate, num) => {
	console.log(String(parseInt(rate.textContent) * num.value));
	return String(parseInt(rate.textContent) * num.value);
};
for (let i = 1; i <= plusBtnList.length; i++) {
	plusBtnList[i].addEventListener("click", () => {
		numList[i].value++;
		console.log(handleClick(rateList[i], numList[i]));
		amountList[i].innerHTML = handleClick(rateList[i], numList[i]);
		sumCart();
	});
}
for (let i = 0; i < minusBtnList.length; i++) {
	minusBtnList[i].addEventListener("click", () => {
		if (numList[i].value > 0) {
			numList[i].value--;
			amountList[i].innerHTML = handleClick(rateList[i], numList[i]);
			sumCart();
		}
	});
}
