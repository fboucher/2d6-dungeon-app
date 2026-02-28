---
name: "blazor-animation-pattern"
description: "Pattern for adding CSS/JS animations to Blazor components without external libraries"
domain: "blazor-ui"
confidence: "high"
source: "implementation"
---

## Context
Pattern for adding smooth, performant animations to Blazor components using pure CSS animations and minimal JavaScript interop. No external animation libraries required. Useful for any visual feedback animations (dice rolls, card flips, transitions).

## Patterns

### Component Animation Parameter
Add an optional `Animate` bool parameter to enable/disable animation. Default to `false` for backward compatibility.

```razor
[Parameter]
public bool Animate {get; set;} = false;
```

### Change Detection for Animation Trigger
Track previous values to detect when animation should trigger (e.g., new data arrived):

```razor
private int previousValue = 0;

protected override async Task OnParametersSetAsync()
{
    bool shouldAnimate = Animate && (currentValue != previousValue) && currentValue > 0;
    if (shouldAnimate)
    {
        await TriggerAnimation();
    }
    previousValue = currentValue;
}
```

### CSS Keyframe Animations
Define animations in app.css with multiple keyframes for organic feel:

```css
@keyframes elementRoll {
    0%   { transform: rotate(0deg) scale(1); }
    25%  { transform: rotate(-15deg) scale(1.1) translateY(-8px); }
    50%  { transform: rotate(10deg) scale(1.05); }
    75%  { transform: rotate(-5deg) scale(1.02); }
    100% { transform: rotate(0deg) scale(1); }
}

.element-rolling { animation: elementRoll 0.6s ease-out; }
```

### JavaScript Interop for Frame Cycling
Use JS for operations that need frame-by-frame control:

```javascript
window.myAnimation = {
    animate: async function (elementId, finalValue, duration = 600) {
        const element = document.getElementById(elementId);
        element.classList.add('element-rolling');
        // Cycle through intermediate states
        for (let i = 0; i < 8; i++) {
            element.src = `image${randomValue}.png`;
            await this.sleep(duration / 8);
        }
        element.src = `image${finalValue}.png`;
        element.classList.remove('element-rolling');
    },
    sleep: ms => new Promise(resolve => setTimeout(resolve, ms))
};
```

### Unique Element IDs
Generate unique IDs per component instance:

```razor
private string elementId = $"element-{Guid.NewGuid():N}";
```

## File Structure
- **CSS animations**: `wwwroot/app.css`
- **JS animation controller**: `wwwroot/scripts/{feature}Animation.js`
- **Script reference**: `Components/App.razor`

## Examples

See implementation:
- `Components/Shared/Dice.razor` — Component with Animate parameter
- `wwwroot/scripts/diceAnimation.js` — JS interop for face cycling
- `wwwroot/app.css` — CSS keyframes (diceRoll, diceSettle)

### Multiple Animation Types
When a component needs different animations for different actions, use an enum parameter:

```razor
public enum AnimationType { Roll, Flip }

[Parameter]
public AnimationType AnimateType {get; set;} = AnimationType.Roll;
```

Track animation type at the parent level and pass it down:
```csharp
private Dice.AnimationType diceAnimationType = Dice.AnimationType.Roll;

private void Roll2Dice() {
    diceAnimationType = Dice.AnimationType.Roll;
    // ... roll logic
}

private void ShiftDice() {
    diceAnimationType = Dice.AnimationType.Flip;
    // ... shift logic
}
```

### Celebration Effects
For special events (doubles, critical hits), create burst/sparkle effects dynamically:

```javascript
celebrateDoubles: function (elementIdA, elementIdB) {
    // Add glow class to elements
    element.classList.add('dice-doubles-glow');
    
    // Create sparkle elements dynamically
    const sparkle = document.createElement('div');
    sparkle.style.cssText = `
        animation: sparkle-burst 0.6s ease-out forwards;
        --end-x: ${Math.cos(angle) * radius}px;
        --end-y: ${Math.sin(angle) * radius}px;
    `;
    container.appendChild(sparkle);
    
    // Cleanup after animation
    setTimeout(() => sparkle.remove(), 800);
}
```

Use CSS custom properties for per-element animation parameters:
```css
@keyframes sparkle-burst {
    0%   { transform: translate(-50%, -50%) scale(0); opacity: 1; }
    100% { transform: translate(calc(-50% + var(--end-x)), calc(-50% + var(--end-y))) scale(0); opacity: 0; }
}
```

## Anti-Patterns
- **External animation libraries** — Use pure CSS/JS unless absolutely necessary
- **Animation on every render** — Only animate on actual value changes
- **Blocking animations** — Use async/await, don't block the render thread
- **Hardcoded timing** — Make duration configurable for flexibility
