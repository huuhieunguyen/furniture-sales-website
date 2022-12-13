const plusBtnList = document.querySelectorAll(".plus-btn");
const minusBtnList = document.querySelectorAll(".minus-btn");
const numList = document.querySelectorAll(".num");
const rateList = document.querySelectorAll(".rate");
const amountList = document.querySelectorAll(".amount");
const sumCartEle = document.querySelector(".sum-cart");
const wannaBuyAllBtn = document.getElementsByName("wanna-buy-all");
const wannaBuyBtn = document.getElementsByName("wannaBuy");
// Xử lý khi nhấn nút cộng số lượng sản phẩm
for (let i = 0; i < plusBtnList.length; i++) {
	plusBtnList[i].addEventListener("click", () => {
		numList[i].value++;
		amountList[i].innerHTML = handleSumPrice(rateList[i], numList[i]);
		sumCart();
	});
}
// Xử lý khi nhấn nút trừ số lượng sản phẩm
for (let i = 0; i < minusBtnList.length; i++) {
	minusBtnList[i].addEventListener("click", () => {
		if (numList[i].value > 1) {
			numList[i].value--;
			amountList[i].innerHTML = handleSumPrice(rateList[i], numList[i]);
			sumCart();
		}
	});
}
// Xử lý tính tổng tiền của giỏ hàng
const sumCart = () => {
	let sum = 0;
	for (let i = 0; i < amountList.length; i++) {
		if (wannaBuyBtn[i].checked) {
			sum = sum + parseInt(amountList[i].textContent);
		}
		// sum = sum + parseInt(amountList[i].textContent);
	}
	sumCartEle.innerHTML = String(sum);
};
sumCart();
// Xử lý tính thành tiền của từng sản phẩm
const handleSumPrice = (rate, num) => {
	return String(parseInt(rate.textContent) * num.value);
};
// Xử lý khi nhấn nút All
const handleClickSelectAll = function (state, allChecked) {
	// Trường hợp muốn hủy CheckAll
	if (allChecked == false) {
		for (let i = 0; i < wannaBuyAllBtn.length; i++) {
			wannaBuyAllBtn[i].checked = false;
		}
		// Trường hợp muốn CheckAll
	} else {
		for (let i = 0; i < wannaBuyAllBtn.length; i++) {
			wannaBuyAllBtn[i].checked = state;
		}
		for (let i = 0; i < wannaBuyBtn.length; i++) {
			wannaBuyBtn[i].checked = state;
		}
	}
	sumCart();
};
// Kiểm tra tất cả các checkbox có được check chưa
const verifyCheckedAll = function () {
	for (let i = 0; i < wannaBuyBtn.length; i++) {
		if (wannaBuyBtn[i].checked == false) {
			// Nếu có 1 check box là false thì sẽ hủy checkboxAll
			return handleClickSelectAll(null, false);
		}
	}
	// Nếu tất cả checkbox là true thì kích hoạt CheckAll
	return handleClickSelectAll(true, true);
};

// Xử lý khi chọn checkbox sản phẩm để mua
for (let i = 0; i < wannaBuyBtn.length; i++) {
	wannaBuyBtn[i].onchange = function () {
		verifyCheckedAll();
		sumCart();
	};
}
// Xử lý khi chọn checkbox all sản phẩm để mua
for (let i = 0; i < wannaBuyAllBtn.length; i++) {
	wannaBuyAllBtn[i].onchange = function () {
		handleClickSelectAll(wannaBuyAllBtn[i].checked, true);
	};
}
