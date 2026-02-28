// Dice rolling animation controller
// Cycles through random dice faces before settling on the final value

window.diceAnimation = {
    // Roll animation that cycles through random faces
    rollDice: async function (elementId, finalValue, color, duration = 600) {
        const element = document.getElementById(elementId);
        if (!element) return;

        const frameCount = 8; // Number of face changes during animation
        const frameDelay = duration / frameCount;
        
        // Add rolling animation class
        element.classList.add('dice-rolling');
        
        // Cycle through random faces
        for (let i = 0; i < frameCount; i++) {
            const randomFace = Math.floor(Math.random() * 6) + 1;
            element.src = `dice/${color}-dice${randomFace}.png`;
            await this.sleep(frameDelay);
        }
        
        // Settle on final value
        element.src = `dice/${color}-dice${finalValue}.png`;
        element.classList.remove('dice-rolling');
        element.classList.add('dice-settled');
        
        // Remove settled class after animation completes
        setTimeout(() => {
            element.classList.remove('dice-settled');
        }, 200);
    },

    // Flip animation for shift buttons - single rotation to show new face
    flipDice: async function (elementId, fromValue, toValue, color, direction = 'up') {
        const element = document.getElementById(elementId);
        if (!element) return;

        // Determine flip direction based on shift direction
        const flipClass = direction === 'up' ? 'dice-flip-up' : 'dice-flip-down';
        
        // Add flip animation class
        element.classList.add(flipClass);
        
        // Change face at midpoint of flip (when dice is "edge-on")
        await this.sleep(150);
        element.src = `dice/${color}-dice${toValue}.png`;
        
        // Wait for animation to complete
        await this.sleep(150);
        element.classList.remove(flipClass);
    },

    // Doubles celebration - creates sparkle/burst effect around both dice
    celebrateDoubles: function (elementIdA, elementIdB) {
        const diceA = document.getElementById(elementIdA);
        const diceB = document.getElementById(elementIdB);
        
        if (!diceA || !diceB) return;

        // Add glow effect to dice
        diceA.classList.add('dice-doubles-glow');
        diceB.classList.add('dice-doubles-glow');

        // Create sparkle container around the dice pair
        const container = diceA.closest('.dice-container')?.parentElement;
        if (!container) {
            this.cleanupDoubles(diceA, diceB, null);
            return;
        }

        // Create sparkles wrapper
        const sparklesWrapper = document.createElement('div');
        sparklesWrapper.className = 'doubles-celebration';
        sparklesWrapper.style.position = 'absolute';
        sparklesWrapper.style.top = '0';
        sparklesWrapper.style.left = '0';
        sparklesWrapper.style.width = '100%';
        sparklesWrapper.style.height = '100%';
        sparklesWrapper.style.pointerEvents = 'none';
        sparklesWrapper.style.overflow = 'visible';

        // Make container position relative for absolute positioning
        const originalPosition = container.style.position;
        container.style.position = 'relative';
        container.appendChild(sparklesWrapper);

        // Create burst of sparkles
        const sparkleCount = 12;
        const colors = ['#FFD700', '#FFA500', '#FFFF00', '#FFF8DC', '#FFFACD'];
        
        for (let i = 0; i < sparkleCount; i++) {
            const sparkle = document.createElement('div');
            sparkle.className = 'sparkle';
            
            // Position around center
            const angle = (i / sparkleCount) * Math.PI * 2;
            const startRadius = 20;
            const endRadius = 60 + Math.random() * 30;
            
            sparkle.style.cssText = `
                position: absolute;
                left: 50%;
                top: 50%;
                width: 8px;
                height: 8px;
                background: ${colors[i % colors.length]};
                border-radius: 50%;
                transform: translate(-50%, -50%);
                animation: sparkle-burst 0.6s ease-out forwards;
                --start-x: ${Math.cos(angle) * startRadius}px;
                --start-y: ${Math.sin(angle) * startRadius}px;
                --end-x: ${Math.cos(angle) * endRadius}px;
                --end-y: ${Math.sin(angle) * endRadius}px;
                animation-delay: ${Math.random() * 0.1}s;
            `;
            sparklesWrapper.appendChild(sparkle);
        }

        // Add some star shapes
        for (let i = 0; i < 6; i++) {
            const star = document.createElement('div');
            star.className = 'star-sparkle';
            const angle = (i / 6) * Math.PI * 2 + Math.PI / 6;
            const endRadius = 50 + Math.random() * 40;
            
            star.innerHTML = '✦';
            star.style.cssText = `
                position: absolute;
                left: 50%;
                top: 50%;
                font-size: 16px;
                color: ${colors[i % colors.length]};
                transform: translate(-50%, -50%);
                animation: star-burst 0.7s ease-out forwards;
                --end-x: ${Math.cos(angle) * endRadius}px;
                --end-y: ${Math.sin(angle) * endRadius}px;
                animation-delay: ${0.05 + Math.random() * 0.1}s;
            `;
            sparklesWrapper.appendChild(star);
        }

        // Cleanup after animation
        setTimeout(() => {
            this.cleanupDoubles(diceA, diceB, sparklesWrapper);
            container.style.position = originalPosition;
        }, 800);
    },

    cleanupDoubles: function(diceA, diceB, sparklesWrapper) {
        if (diceA) diceA.classList.remove('dice-doubles-glow');
        if (diceB) diceB.classList.remove('dice-doubles-glow');
        if (sparklesWrapper) sparklesWrapper.remove();
    },
    
    sleep: function (ms) {
        return new Promise(resolve => setTimeout(resolve, ms));
    }
};
