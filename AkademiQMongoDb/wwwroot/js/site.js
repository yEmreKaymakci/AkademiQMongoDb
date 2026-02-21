// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Şefleri Göster/Gizle Fonksiyonu
function toggleChefs() {
    var extraChefs = document.querySelectorAll('.extra-chef');
    var btn = document.getElementById('btnToggleChefs');

    // Eğer buton sayfada yoksa (başka sayfalarda hata vermemesi için güvenlik kontrolü)
    if (!btn) return;

    extraChefs.forEach(function (chef) {
        chef.classList.toggle('d-none');
    });

    if (btn.innerText.includes("Daha Fazla")) {
        btn.innerHTML = 'Daha Az Göster <i class="fas fa-arrow-up ms-1"></i>';
    } else {
        btn.innerHTML = 'Daha Fazla Göster <i class="fas fa-arrow-down ms-1"></i>';
    }
}

// Sayfa tamamen yüklendiğinde çalışacak kod blokları
// 2. SİSTEM BİLDİRİMLERİ (SWEETALERT KONTROLÜ)
// ==========================================
// DOMContentLoaded: HTML tamamen yüklendikten sonra bu kodları çalıştırır
document.addEventListener("DOMContentLoaded", function () {

    // Layout.cshtml'deki gizli veri köprüsünü buluyoruz
    var notifDiv = document.getElementById('notification-data');

    // Eğer sayfada bu div varsa işlemlere başla
    if (notifDiv) {
        // C#'tan gelen verileri HTML data attributelerinden okuyoruz
        var errorMsg = notifDiv.getAttribute('data-error');
        var successMsg = notifDiv.getAttribute('data-success');

        // Eğer e-posta zaten varsa (Bilgi Popup'ı)
        if (errorMsg && errorMsg.length > 0) {
            Swal.fire({
                title: 'Bilgilendirme',
                text: errorMsg,
                icon: 'info',
                confirmButtonText: 'Tamam',
                confirmButtonColor: '#ffb300' // Uyarı (Turuncu/Sarı)
            });
        }

        // Eğer yeni abone olunduysa (Başarı Popup'ı)
        if (successMsg && successMsg.length > 0) {
            Swal.fire({
                title: 'Harika!',
                text: successMsg,
                icon: 'success',
                confirmButtonText: 'Teşekkürler',
                confirmButtonColor: '#28a745' // Başarılı (Yeşil)
            });
        }
    }
});

// ==========================================
// 3. ŞİFRE GÜVENLİK SEVİYESİ VE GÖSTER/GİZLE
// ==========================================
document.addEventListener("DOMContentLoaded", function () {
    const passwordInput = document.getElementById("passwordInput");

    // GÜVENLİK KİLİDİ: Eğer bulunulan sayfada şifre kutusu yoksa, kodun geri kalanını çalıştırma
    if (!passwordInput) return;

    const toggleBtn = document.getElementById("togglePassword");
    const toggleIcon = document.getElementById("toggleIcon");
    const passText = document.getElementById("passwordText");

    const bars = [
        document.getElementById("bar-1"),
        document.getElementById("bar-2"),
        document.getElementById("bar-3"),
        document.getElementById("bar-4")
    ];

    // 1. Şifre Güvenlik Seviyesi Hesaplama
    passwordInput.addEventListener("input", function () {
        const val = passwordInput.value;
        let strength = 0;

        // Kriterler:
        if (val.length > 5) strength += 1; // Uzunluk 5'ten büyükse
        if (val.match(/[a-z]+/)) strength += 1; // Küçük harf varsa
        if (val.match(/[A-Z]+/)) strength += 1; // Büyük harf varsa
        if (val.match(/[0-9]+/) || val.match(/[$@#&!]+/)) strength += 1; // Rakam veya özel karakter

        // Tüm çubukları sıfırla
        bars.forEach(bar => {
            bar.className = "flex-1 rounded-full bg-white/30 h-full transition-all duration-300";
        });

        // Gücüne göre renkleri ayarla
        if (strength === 1) {
            bars[0].classList.replace("bg-white/30", "bg-red-500");
            passText.innerText = "Zayıf";
            passText.className = "text-[10px] uppercase tracking-widest text-red-500";
        } else if (strength === 2) {
            bars[0].classList.replace("bg-white/30", "bg-yellow-500");
            bars[1].classList.replace("bg-white/30", "bg-yellow-500");
            passText.innerText = "Orta";
            passText.className = "text-[10px] uppercase tracking-widest text-yellow-500";
        } else if (strength === 3) {
            bars[0].classList.replace("bg-white/30", "bg-primary");
            bars[1].classList.replace("bg-white/30", "bg-primary");
            bars[2].classList.replace("bg-white/30", "bg-primary");
            passText.innerText = "Güçlü";
            passText.className = "text-[10px] uppercase tracking-widest text-primary";
        } else if (strength === 4) {
            bars.forEach(bar => bar.classList.replace("bg-white/30", "bg-primary"));
            passText.innerText = "Çok Güçlü";
            passText.className = "text-[10px] uppercase tracking-widest text-primary";
        } else {
            passText.innerText = "Güvenlik Seviyesi";
            passText.className = "text-[10px] uppercase tracking-widest text-[#4d9999]";
        }
    });

    // 2. Şifreyi Göster/Gizle (Göz İkonu)
    if (toggleBtn) {
        toggleBtn.addEventListener("click", function () {
            if (passwordInput.type === "password") {
                passwordInput.type = "text";
                toggleIcon.innerText = "visibility_off";
            } else {
                passwordInput.type = "password";
                toggleIcon.innerText = "visibility";
            }
        });
    }
});

// ==========================================
// 4. ÜRÜN DETAY MODALI (MENÜ SAYFASI)
// ==========================================
// Bu fonksiyon HTML içindeki onclick="openProductModal(this)" tarafından tetiklenir
function openProductModal(element) {
    // Tıklanan butondaki verileri alıyoruz
    var name = element.getAttribute('data-name');
    var price = element.getAttribute('data-price');
    var desc = element.getAttribute('data-desc');
    var img = element.getAttribute('data-img');

    // Modal içindeki hedefleri buluyoruz
    var modalName = document.getElementById('modalName');
    var modalPrice = document.getElementById('modalPrice');
    var modalDesc = document.getElementById('modalDesc');
    var modalImg = document.getElementById('modalImg');

    // GÜVENLİK KİLİDİ: Eğer bulunulan sayfada Modal yoksa işlemi durdur
    if (!modalName || !modalPrice || !modalDesc || !modalImg) return;

    // Verileri Modal'ın içine yerleştiriyoruz
    modalName.innerText = name;
    modalPrice.innerText = price + " ₺";
    modalDesc.innerText = desc;
    modalImg.src = img;

    // Modal'ı ekranda gösteriyoruz (jQuery ve Bootstrap entegrasyonu)
    $('#productDetailModal').modal('show');
}