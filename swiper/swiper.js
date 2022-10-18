var swiper1 = new Swiper(".mySwiper1", {
	slidesPerView: 4,
	spaceBetween: 10,
	slidesPerGroup: 1,
	loop: true,
	loopFillGroupWithBlank: true,
	pagination: {
		el: ".my-custom-pagination-div",
		clickable: true,
		renderBullet: (index, className) => {
			return '<span class="' + className + '">' + "</span>";
		},
	},
	navigation: {
		nextEl: ".swiper-button-next",
		prevEl: ".swiper-button-prev",
	},
});
var swiper2 = new Swiper(".mySwiper2", {
	slidesPerView: 3,
	spaceBetween: 30,
	centeredSlides: true,
	grabCursor: true,
	loop: true,
	loopFillGroupWithBlank: true,
	pagination: {
		el: ".my-custom-pagination-div",
		clickable: true,
		renderBullet: (index, className) => {
			return '<span class="' + className + '">' + "</span>";
		},
	},
	autoplay: {
		delay: 2000,
		disableOnInteraction: false,
	},
});

swiper1.loopDestroy();
swiper1.loopCreate();
swiper2.loopDestroy();
swiper2.loopCreate();
