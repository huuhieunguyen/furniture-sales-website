var swiper1 = new Swiper(".mySwiper1", {
    loop: true,
    pagination: {
        el: ".my-custom-pagination-div",
        clickable: true,
        renderBullet: (index, className) => {
            return '<span class="' + className + '">' + "</span>";
        },
    },/*Tạo cái đếm trang mới, cái này mới có thể thêm margin top được*/
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
    slidesPerView: 1,/*Số Slide hiện trên 1 View*/
    spaceBetween: 30,/*Khoảng cách các slide*/
    grabCursor: true,/*Tạo con trỏ chuột có hình bàn tay*/
    loop: true,/*Vòng lặp quay về sản phẩm đầu*/
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
    breakpoints: {
        768: {
            slidesPerView: 1,
            spaceBetween: 30,
        },
        1024: {
            slidesPerView: 3,
            spaceBetween: 30,
        },
    },/*Responsive*/
});

/*swiper1.loopDestroy();
swiper1.loopCreate();
swiper2.loopDestroy();
swiper2.loopCreate();
*/