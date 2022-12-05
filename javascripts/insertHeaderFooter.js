const header = `
<header
class="hidden lg:block sticky top-0 bg-white shadow-[0px_5px_6px_rgba(0,_0,_0,_0.25)]"
>
<div class="container py-[25px] flex items-center justify-between">
  <div class="flex items-center justify-center gap-x-2 cursor-pointer">
    <img srcset="/assets/img/logo.png 2x" alt="#" />
    <span class="font-medium text-[18px]">
      BiSys - Yêu ngôi nhà của bạn
    </span>
  </div>
  <div
    class="flex items-center justify-center gap-x-[60px] font-medium text-[18px] cursor-pointer"
  >
    <span>Sản phẩm</span>
    <span>Về chúng tôi</span>
    <span>Tin tức</span>
    <span>Liên hệ</span>
  </div>
  <div
    class="flex items-center justify-center gap-x-6 text-[18px] cursor-pointer"
  >
    <span>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke-width="1.5"
        stroke="currentColor"
        class="w-6 h-6"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          d="M15.75 10.5V6a3.75 3.75 0 10-7.5 0v4.5m11.356-1.993l1.263 12c.07.665-.45 1.243-1.119 1.243H4.25a1.125 1.125 0 01-1.12-1.243l1.264-12A1.125 1.125 0 015.513 7.5h12.974c.576 0 1.059.435 1.119 1.007zM8.625 10.5a.375.375 0 11-.75 0 .375.375 0 01.75 0zm7.5 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z"
        />
      </svg>
    </span>
    <span class="flex items-center justify-center gap-x-2 cursor-pointer">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke-width="1.5"
        stroke="currentColor"
        class="w-6 h-6"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          d="M15.75 6a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0zM4.501 20.118a7.5 7.5 0 0114.998 0A17.933 17.933 0 0112 21.75c-2.676 0-5.216-.584-7.499-1.632z"
        />
      </svg>

      <span class="font-bold">User name</span>
    </span>
  </div>
</div>
</header>

<header
class="z-50 sticky top-0 lg:hidden bg-white shadow-[0px_1px_2px_rgba(0,_0,_0,_0.1)]"
>
<div class="w-full mx-auto p-5 flex justify-between">
  <div class="flex items-center justify-start gap-x-2 cursor-pointer">
    <img srcset="/assets/img/logo.png 2.5x" alt="#" />
    <span class="font-medium text-[18px]"> BiSys </span>
  </div>
  <input
    hidden
    type="checkbox"
    class="nav__input"
    id="nav-mobile-input"
  />
  <label for="nav-mobile-input" class="z-50 label-moblie">
    <svg
      xmlns="http://www.w3.org/2000/svg"
      fill="none"
      viewBox="0 0 24 24"
      stroke-width="1.5"
      stroke="currentColor"
      class="w-6 h-6"
    >
      <path
        stroke-linecap="round"
        stroke-linejoin="round"
        d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5"
      />
    </svg>
  </label>

  <label for="nav-mobile-input" class="overlay"></label>

  <div class="menu-content">
    <ul>
      <li class="menu-item">
        <span>Sản phẩm</span>
      </li>
      <li class="menu-item">
        <span>Về chúng tôi</span>
      </li>
      <li class="menu-item">
        <span>Tin tức</span>
      </li>
      <li class="menu-item">
        <span>Liên hệ</span>
      </li>
    </ul>

    <div class="absolute pl-[30px] bottom-10">
      <!-- <button class="px-[16px] py-[8px] text-white bg-[#518581]">
        Đăng nhập
      </button> -->
      <!-- After login -->
      <div
        class="flex items-center justify-center gap-x-3 text-[18px] cursor-pointer"
      >
        <span>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke-width="1.5"
            stroke="currentColor"
            class="w-6 h-6"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M15.75 10.5V6a3.75 3.75 0 10-7.5 0v4.5m11.356-1.993l1.263 12c.07.665-.45 1.243-1.119 1.243H4.25a1.125 1.125 0 01-1.12-1.243l1.264-12A1.125 1.125 0 015.513 7.5h12.974c.576 0 1.059.435 1.119 1.007zM8.625 10.5a.375.375 0 11-.75 0 .375.375 0 01.75 0zm7.5 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z"
            />
          </svg>
        </span>
        <span
          class="flex items-center justify-center gap-x-1 cursor-pointer"
        >
          <svg
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke-width="1.5"
            stroke="currentColor"
            class="w-6 h-6"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              d="M15.75 6a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0zM4.501 20.118a7.5 7.5 0 0114.998 0A17.933 17.933 0 0112 21.75c-2.676 0-5.216-.584-7.499-1.632z"
            />
          </svg>
          <span class="font-bold text-sm truncate max-w-[70px]"
            >User name</span
          >
        </span>
      </div>
    </div>
  </div>
</div>
</header>
`;

const footer = `
<footer
class="hidden lg:block container bg-white py-[60px] border-t border-t-[#ECE4DE]"
>
<div class="flex items-center justify-center gap-y-[23px] flex-col">
  <div class="flex items-center justify-center gap-x-2 cursor-pointer">
    <img srcset="/assets/img/logo.png 2x" alt="logo" />
    <span class="font-medium text-[18px]">
      BiSys - Yêu ngôi nhà của bạn
    </span>
  </div>
  <div
    class="flex items-center justify-center gap-x-[41px] cursor-pointer"
  >
    <img src="/assets/icons/facebook.png" alt="facebook" />
    <img src="/assets/icons/instagram.png" alt="instagram" />
    <img src="/assets/icons/twitter.png" alt="twitter" />
  </div>
  <span class="font-medium text-2xl"
    >Hãy theo dõi chúng tôi để cập nhật tin mới nhất !</span
  >
</div>
</footer>

<footer class="block lg:hidden p-5">
<div class="border-t border-t-[#AD7E5C]">
  <div
    class="flex items-center justify-start gap-x-2 cursor-pointer my-5"
  >
    <img srcset="/assets/img/logo.png 2.5x" alt="#" />
    <span class="font-medium text-[18px]"> BiSys </span>
  </div>
  <p class="font-medium text-sm text-[#AFADB5] my-5">
    BiSys is digital agency that help you make better experience iaculis
    cras in.
  </p>

  <div class="flex items-start justify-between gap-x-[35px]">
    <div class="flex flex-col items-start justify-center gap-y-[14px]">
      <span class="font-bold">Product</span>
      <div class="flex flex-col items-start justify-center gap-y-[6px]">
        <span class="font-medium text-sm text-[#AFADB5]"
          >New Arrivals</span
        >
        <span class="font-medium text-sm text-[#AFADB5]"
          >Best Selling</span
        >
        <span class="font-medium text-sm text-[#AFADB5]">Home Decor</span>
        <span class="font-medium text-sm text-[#AFADB5]"
          >Kitchen Set</span
        >
      </div>
    </div>

    <div class="flex flex-col items-start justify-center gap-y-[14px]">
      <span class="font-bold">Services</span>
      <div class="flex flex-col items-start justify-center gap-y-[6px]">
        <span class="font-medium text-sm text-[#AFADB5]">Catalog</span>
        <span class="font-medium text-sm text-[#AFADB5]">Blog</span>
        <span class="font-medium text-sm text-[#AFADB5]">Faq</span>
        <span class="font-medium text-sm text-[#AFADB5]">Pricing</span>
      </div>
    </div>

    <div class="flex flex-col items-start justify-center gap-y-[14px]">
      <span class="font-bold">Follow Us</span>
      <div class="flex flex-col items-start justify-center gap-y-[6px]">
        <span class="font-medium text-sm text-[#AFADB5]">Facebook</span>
        <span class="font-medium text-sm text-[#AFADB5]">Instagram</span>
        <span class="font-medium text-sm text-[#AFADB5]">Twitter</span>
      </div>
    </div>
  </div>
</div>
</footer>
`;

document.body.insertAdjacentHTML("afterbegin", header);
document.body.insertAdjacentHTML("beforeend", footer);
