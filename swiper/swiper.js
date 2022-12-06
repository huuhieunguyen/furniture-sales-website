var swiper1 = new Swiper(".mySwiper1", {
	slidesPerView: 1,
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
	breakpoints: {
		768: {
			slidesPerView: 2,
			spaceBetween: 10,
		},
		1024: {
			slidesPerView: 4,
			spaceBetween: 30,
		},
	},
});
var swiper2 = new Swiper(".mySwiper2", {
	slidesPerView: 1,

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
		delay: 1500,
		disableOnInteraction: false,
	},
	breakpoints: {
		768: {
			slidesPerView: 1,
			spaceBetween: 30,
		},
		1024: {
			slidesPerView: 3,
			spaceBetween: 30,
		},
	},
});

swiper1.loopDestroy();
swiper1.loopCreate();
swiper2.loopDestroy();
swiper2.loopCreate();
