const form = document.querySelector('.contact__form');
const contactSection = document.getElementById('contact');

form.addEventListener('submit', async function (event) {
    event.preventDefault();
    const formData = new FormData(form);
    const response = await fetch('/Index?handler=Ajax', {
        method: 'POST',
        body: formData
    });
    if (response.ok) {
        contactSection.innerHTML = '<div class="contact__success">Спасибо! Мы приняли вашу заявку и перезвоним в ближайшее время.</div>';
    } else {
        const errorText = await response.text();
        alert(errorText);
    }
});

