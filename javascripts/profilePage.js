const myProfile_btn = document.querySelector(".myProfile_btn");
const myOrder_btn = document.querySelector(".myOrder_btn");
const changePw_btn = document.querySelector(".changePw_btn");
const logOut_btn = document.querySelector(".logOut_btn");
const title = document.querySelector(".title");
const desc = document.querySelector(".desc");

myProfile_btn.addEventListener("click", () => {
  myOrder_btn.classList.remove("opacity-[0.5]");
  changePw_btn.classList.remove("opacity-[0.5]");
  logOut_btn.classList.remove("opacity-[0.5]");

  myProfile_btn.classList.add("opacity-[0.5]");

  title.textContent = "Hồ sơ của tôi";
  desc.textContent = "Chỉnh sửa hồ sơ tài khoản";

  document.querySelector(".myProfile").classList.remove("hidden");
  document.querySelector(".myProfile").classList.add("flex");
  document.querySelector(".myProfile").classList.add("lg:grid");

  document.querySelector(".myOrder").classList.remove("flex");
  document.querySelector(".myOrder").classList.add("hidden");

  document.querySelector(".changePw").classList.remove("grid");
  document.querySelector(".changePw").classList.add("hidden");
});

myOrder_btn.addEventListener("click", () => {
  myProfile_btn.classList.remove("opacity-[0.5]");
  changePw_btn.classList.remove("opacity-[0.5]");
  logOut_btn.classList.remove("opacity-[0.5]");

  myOrder_btn.classList.add("opacity-[0.5]");

  title.textContent = "Đơn hàng của tôi";
  desc.textContent = "Xem chi tiết đơn hàng của tôi";

  document.querySelector(".myOrder").classList.remove("hidden");
  document.querySelector(".myOrder").classList.add("flex");

  document.querySelector(".myProfile").classList.remove("flex");
  document.querySelector(".myProfile").classList.remove("lg:grid");
  document.querySelector(".myProfile").classList.add("hidden");

  document.querySelector(".changePw").classList.remove("grid");
  document.querySelector(".changePw").classList.add("hidden");
});

changePw_btn.addEventListener("click", () => {
  myProfile_btn.classList.remove("opacity-[0.5]");
  myOrder_btn.classList.remove("opacity-[0.5]");
  logOut_btn.classList.remove("opacity-[0.5]");

  changePw_btn.classList.add("opacity-[0.5]");

  title.textContent = "Thay đổi mật khẩu";
  desc.textContent = "";

  document.querySelector(".changePw").classList.remove("hidden");
  document.querySelector(".changePw").classList.add("grid");

  document.querySelector(".myProfile").classList.add("hidden");
  document.querySelector(".myProfile").classList.remove("flex");
  document.querySelector(".myProfile").classList.remove("lg:grid");

  document.querySelector(".myOrder").classList.add("hidden");
  document.querySelector(".myOrder").classList.remove("flex");
});

logOut_btn.addEventListener("click", () => {
  myProfile_btn.classList.remove("opacity-[0.5]");
  myOrder_btn.classList.remove("opacity-[0.5]");
  changePw_btn.classList.remove("opacity-[0.5]");

  logOut_btn.classList.add("opacity-[0.5]");

  const logOut = confirm("Bạn có muốn đăng xuất không?");
  if (logOut === true) {
    alert("Đăng xuất thành công!");
  }
});
