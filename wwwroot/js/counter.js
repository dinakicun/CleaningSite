const statsSection = document.getElementById('stats');

if (statsSection) {

    function animateNumber(el) {
        const target = parseInt(el.dataset.target); 
        const duration = 1500;                       // длительность анимации
        const start = performance.now();             

        function tick(now) {
            const progress = Math.min((now - start) / duration, 1); 
            // ease-out: быстро в начале, замедление в конце (визуально приятнее линейного)
            const eased = 1 - Math.pow(1 - progress, 3);
            el.textContent = Math.round(target * eased); 

            if (progress < 1) requestAnimationFrame(tick); 
        }
        requestAnimationFrame(tick);
    }

   
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) { // секция видна на экране
                statsSection.querySelectorAll('.stat-item__number')
                    .forEach(animateNumber);
                observer.disconnect(); // отключаем наблюдение — анимация одноразовая
            }
        });
    }, { threshold: 0.3 }); // сработать, когда видно 30% секции

    observer.observe(statsSection);
}