

        const bubbleField = document.getElementById('bubbleField');

        if(bubbleField) {

            const BUBBLE_COUNT = 14;   
            const bubbles = [];        

            for (let i = 0; i < BUBBLE_COUNT; i++) {
                const el = document.createElement('div'); 
                el.className = 'bubble';                   

                const size = 20 + Math.random() * 60;      // случайный размер 20-80px
                el.style.width = size + 'px';
                el.style.height = size + 'px';
                el.style.left = Math.random() * 100 + '%'; // случайная позиция по горизонтали
                el.style.bottom = Math.random() * 60 + 'px'; // рождение у низа (в зоне пены)

                bubbleField.appendChild(el); 

                bubbles.push({
                    el: el,
                    speed: 0.3 + Math.random() * 0.7,        // множитель скорости подъёма при скролле
                    wobbleSpeed: 0.5 + Math.random() * 1.5,   // скорость покачивания
                    wobbleAmount: 5 + Math.random() * 15,     // амплитуда покачивания (px)
                    phase: Math.random() * Math.PI * 2        // стартовая фаза синусоиды (чтобы качались вразнобой)
                });
            }

            function updateBubbles() {
                const scrollY = window.scrollY;              // насколько прокручена страница
                const time = performance.now() / 1000;       // время в секундах (для покачивания)

                bubbles.forEach(b => {
                    const lift = scrollY * b.speed;

                    // Покачивание по горизонтали: синус от времени
                    const wobble = Math.sin(time * b.wobbleSpeed + b.phase) * b.wobbleAmount;

                    // Применяем: сдвиг вверх (минус по Y) и вбок
                    b.el.style.transform = 'translateY(' + (-lift) + 'px) translateX(' + wobble + 'px)';
                });

                requestAnimationFrame(updateBubbles); 
            }

            updateBubbles(); 
        }
